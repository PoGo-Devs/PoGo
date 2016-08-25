using Google.Protobuf;
using PoGo.ApiClient.Enums;
using PoGo.ApiClient.Extensions;
using PoGo.ApiClient.Helpers;
using PoGo.ApiClient.HttpClient;
using PoGo.ApiClient.Interfaces;
using PoGo.ApiClient.Rpc;
using PoGo.ApiClient.Session;
using POGOProtos.Networking.Envelopes;
using POGOProtos.Networking.Requests;
using POGOProtos.Networking.Requests.Messages;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using POGOProtos.Inventory;

namespace PoGo.ApiClient
{

    /// <summary>
    /// 
    /// </summary>
    public class PokemonGoApiClient : IPokemonGoApiClient
    {

        #region Private Members

        /// <summary>
        /// 
        /// </summary>
        internal readonly PokemonHttpClient PokemonHttpClient = new PokemonHttpClient();

        /// <summary>
        /// 
        /// </summary>
        internal CancellationTokenSource CancellationTokenSource;

        /// <summary>
        /// 
        /// </summary>
        internal RequestBuilder RequestBuilder => new RequestBuilder(AuthToken, AuthType, CurrentLatitude, CurrentLongitude,
            CurrentAltitude, DeviceInfo, AuthTicket);

        /// <summary>
        /// 
        /// </summary>
        private readonly List<RequestType> _wrappableRequests = new List<RequestType>
        {
            RequestType.GetMapObjects,
        };

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public string AuthToken => AccessToken?.Token;

        /// <summary>
        /// 
        /// </summary>
        public AuthType AuthType => Settings.AuthType;

        /// <summary>
        /// 
        /// </summary>
        public IApiFailureStrategy ApiFailure { get; }

        /// <summary>
        /// 
        /// </summary>
        public string ApiUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AuthTicket AuthTicket => AccessToken?.AuthTicket;

        /// <summary>
        /// 
        /// </summary>
        public AccessToken AccessToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double CurrentLatitude { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public double CurrentLongitude { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public double CurrentAltitude { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public IDeviceInfo DeviceInfo { get; }

        /// <summary>
        /// 
        /// </summary>
        public IDownload Download { get; }

        /// <summary>
        /// 
        /// </summary>
        public IEncounter Encounter { get; }

        /// <summary>
        /// 
        /// </summary>
        public IFort Fort { get; }

        /// <summary>
        /// 
        /// </summary>
        public IInventory Inventory { get; }

        /// <summary>
        /// 
        /// </summary>
        public Rpc.LoginClient Login { get; }

        /// <summary>
        /// 
        /// </summary>
        public IMap Map { get; }

        /// <summary>
        /// 
        /// </summary>
        public Misc Misc { get; }

        /// <summary>
        /// 
        /// </summary>
        public IPlayer Player { get; }

        /// <summary>
        /// 
        /// </summary>
        internal BlockingCollection<RequestEnvelope> RequestQueue { get; }

        /// <summary>
        /// 
        /// </summary>
        public ISettings Settings { get; }

        #endregion

        #region Events
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public event EventHandler<InventoryDelta> InventoryReceived;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        void RaiseInventoryReceived(InventoryDelta value) => InventoryReceived?.Invoke(this, value);  

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="apiFailureStrategy"></param>
        /// <param name="deviceInfo"></param>
        /// <param name="accessToken"></param>
        public PokemonGoApiClient(ISettings settings, IApiFailureStrategy apiFailureStrategy, IDeviceInfo deviceInfo, AccessToken accessToken = null)
        {
            Settings = settings;
            ApiFailure = apiFailureStrategy;
            AccessToken = accessToken;

            CancellationTokenSource = new CancellationTokenSource();
            RequestQueue = new BlockingCollection<RequestEnvelope>();

            Login = new Rpc.LoginClient(this);
            Player = new PlayerClient(this);
            Download = new DownloadClient(this);
            Inventory = new InventoryClient(this);
            Map = new MapClient(this);
            Fort = new FortClient(this);
            Encounter = new EncounterClient(this);
            Misc = new Misc(this);
            DeviceInfo = deviceInfo;

            Player.SetCoordinates(Settings.DefaultLatitude, Settings.DefaultLongitude, Settings.DefaultAltitude);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Triggers any currently-executing requests to cancel ASAP. This will also have the effect of clearing the <see cref="RequestQueue"/>.
        /// </summary>
        public void CancelCurrentRequests()
        {
            CancellationTokenSource.Cancel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="requestType"></param>
        /// <returns></returns>
        public bool QueueRequest(IMessage message, RequestType requestType)
        {
            RequestEnvelope envelope = null;
            if (_wrappableRequests.Contains(requestType))
            {
                envelope = BuildBatchRequestEnvelope(message, requestType);
            }
            else
            {
                var request = new Request
                {
                    RequestType = requestType,
                    RequestMessage = message.ToByteString()
                };
                envelope = RequestBuilder.GetRequestEnvelope(request);

            }
            return RequestQueue.TryAdd(envelope);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task StartProcessingRequests()
        {
             return Task.Factory.StartNew(() =>
             {
                 foreach (var workItem in RequestQueue.GetConsumingEnumerable())
                 {
                     if (CancellationTokenSource.IsCancellationRequested) continue;
                     //TODO: RWM: We'll do the real work here. Below is just a placeholder.
                     Task.Delay(1).Wait();
                 }
             }, TaskCreationOptions.LongRunning);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="requestType"></param>
        /// <returns></returns>
        private RequestEnvelope BuildBatchRequestEnvelope(IMessage message, RequestType requestType)
        {

            var getHatchedEggsMessage = new GetHatchedEggsMessage();
            var getInventoryMessage = new GetInventoryMessage
            {
                LastTimestampMs = DateTime.UtcNow.ToUnixTime()
            };
            var checkAwardedBadgesMessage = new CheckAwardedBadgesMessage();
            var downloadSettingsMessage = new DownloadSettingsMessage
            {
                Hash = "05daf51635c82611d1aac95c0b051d3ec088a930"
            };

            return RequestBuilder.GetRequestEnvelope(
                new Request
                {
                    RequestType = requestType,
                    RequestMessage = message.ToByteString()
                },
                new Request
                {
                    RequestType = RequestType.GetHatchedEggs,
                    RequestMessage = getHatchedEggsMessage.ToByteString()
                }, new Request
                {
                    RequestType = RequestType.GetInventory,
                    RequestMessage = getInventoryMessage.ToByteString()
                }, new Request
                {
                    RequestType = RequestType.CheckAwardedBadges,
                    RequestMessage = checkAwardedBadgesMessage.ToByteString()
                }, new Request
                {
                    RequestType = RequestType.DownloadSettings,
                    RequestMessage = downloadSettingsMessage.ToByteString()
                });

        }

        #endregion

    }

}