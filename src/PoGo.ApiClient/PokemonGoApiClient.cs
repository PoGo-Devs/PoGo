using Google.Protobuf;
using PoGo.ApiClient.Enums;
using PoGo.ApiClient.Exceptions;
using PoGo.ApiClient.Helpers;
using PoGo.ApiClient.Interfaces;
using PoGo.ApiClient.Rpc;
using PoGo.ApiClient.Session;
using POGOProtos.Inventory;
using POGOProtos.Networking.Envelopes;
using POGOProtos.Networking.Requests;
using POGOProtos.Networking.Requests.Messages;
using POGOProtos.Networking.Responses;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace PoGo.ApiClient
{

    /// <summary>
    /// 
    /// </summary>
    public partial class PokemonGoApiClient : HttpClient, IPokemonGoApiClient
    {

        #region Private Members

        /// <summary>
        /// 
        /// </summary>
        internal CancellationTokenSource CancellationTokenSource;

        /// <summary>
        /// 
        /// </summary>
        internal RequestBuilder RequestBuilder => new RequestBuilder(AuthToken, AuthType, CurrentLatitude, CurrentLongitude, CurrentAccuracy, DeviceInfo, AuthTicket);

        /// <summary>
        /// 
        /// </summary>
        private readonly List<RequestType> _singleRequests = new List<RequestType>
        {
            RequestType.GetPlayer,
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
        public double CurrentAccuracy { get; internal set; }


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

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="deviceInfo"></param>
        /// <param name="accessToken"></param>
        public PokemonGoApiClient(ISettings settings, IDeviceInfo deviceInfo, AccessToken accessToken = null)
        {
            Settings = settings;
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
        /// <remarks>
        /// robertmclaws: Every request will have a minimum of two payloads. So no single-payload results anymore.
        /// </remarks>
        public bool QueueRequest(IMessage message, RequestType requestType)
        {
            RequestEnvelope envelope = null;
            if (_singleRequests.Contains(requestType))
            {
                envelope = RequestBuilder.GetRequestEnvelope(
                    new Request
                    {
                        RequestType = requestType,
                        RequestMessage = message.ToByteString()
                    },
                    new Request
                    {
                        RequestType = RequestType.CheckChallenge,
                        RequestMessage = new CheckChallengeMessage().ToByteString()
                    }
                );
            }
            else
            {
                envelope = BuildBatchRequestEnvelope(message, requestType);
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
                     // robertmclaws: The line below should collapse the queue quickly.
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

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="url"></param>
        /// <param name="requestEnvelope"></param>
        /// <param name="responseTypes"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public async Task<IMessage[]> PostProtoPayload<TRequest>(string url, RequestEnvelope requestEnvelope, params Type[] responseTypes)
            where TRequest : IMessage<TRequest>
        {
            // robertmclaws: Start by preparing the results array based on the types we're expecting to be returned.
            var result = new IMessage[responseTypes.Length];
            for (var i = 0; i < responseTypes.Length; i++)
            {
                result[i] = Activator.CreateInstance(responseTypes[i]) as IMessage;
                if (result[i] == null)
                {
                    throw new ArgumentException($"ResponseType {i} is not an IMessage");
                }
            }

            // robertmclaws: We're not using the strategy pattern here anymore. Specific requests will be retried as needed.
            //               For example, there's no need to retry a map request when another will come along in 5 seconds.
            var response = await PostProto<TRequest>(url, requestEnvelope, RetryPolicyManager.GetRetryPolicy(requestEnvelope.Requests[0].RequestType));

            switch ((StatusCode)response.StatusCode)
            {
                case StatusCode.Success:
                    if (response.AuthTicket != null)
                    {
                        Logger.Write("Received a new AuthTicket from the Api!");
                        AccessToken.AuthTicket = response.AuthTicket;
                        // robertmclaws to do: See if we need to clone the AccessToken so we don't have a threading violation.
                        RaiseAccessTokenUpdated(AccessToken);
                    }
                    break;

                case StatusCode.AccessDenied:
                    Logger.Write("Account has been banned. Our condolences for your loss.");
                    CancelCurrentRequests();
                    //RequestQueue.CompleteAdding();
                    // robertmclaws to do: Allow you to sop adding events to the queue, and re-initialize the queue if needed.
                    throw new AccountLockedException();

                case StatusCode.Redirect:
                    if (!Regex.IsMatch(response.ApiUrl, "pgorelease\\.nianticlabs\\.com\\/plfe\\/\\d+"))
                    {
                        throw new Exception($"Received an incorrect API url '{response.ApiUrl}', status code was '{response.StatusCode}'.");
                    }
                    ApiUrl = $"https://{response.ApiUrl}/rpc";
                    Logger.Write($"Received an updated API url = {ApiUrl}");
                    // robertmclaws to do: See if we need to retry the request.
                    break;

                case StatusCode.InvalidToken:
                    Logger.Write("Received StatusCode 102, reauthenticating.");
                    AccessToken?.Expire();
                    // robertmclaws to do: trigger a retry here. We'll automatically try to log in again on the next request.
                    break;

                case StatusCode.ServerOverloaded:
                    // Per @wallycz, on code 52, wait 11 seconds before sending the request again.
                    Logger.Write("Server says to slow the hell down. Try again in 11 sec.");
                    await Task.Delay(11000);
                    // robertmclaws to do: trigger a retry here. We'll automatically try to log in again on the next request.
                    break;

                default:
                    Logger.Write($"Unknown status code: {response.StatusCode}");
                    break;
            }

            // robertmclaws: Now marry up the results from the service whith the type instances we already created.
            for (var i = 0; i < responseTypes.Length; i++)
            {
                var item = response.Returns[i];
                result[i].MergeFrom(item);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="url"></param>
        /// <param name="requestEnvelope"></param>
        /// <param name="retryPolicy"></param>
        /// <param name="attemptCount"></param>
        /// <returns></returns>
        public async Task<ResponseEnvelope> PostProto<TRequest>(string url, RequestEnvelope requestEnvelope, RetryPolicy retryPolicy, int attemptCount = 0)
            where TRequest : IMessage<TRequest>
        {
            attemptCount++;
            // robertmclaws: Let's be pro-active about token failures, instead of reactive.
            if (AccessToken == null || AccessToken.IsExpired)
            {
                await Login.DoLogin();
            }

            //Encode payload and put in envelop, then send
            var data = requestEnvelope.ToByteString();
            var result = await PostAsync(url, new ByteArrayContent(data.ToByteArray()));

            //Decode message
            var responseData = await result.Content.ReadAsByteArrayAsync();
            var decodedResponse = new ResponseEnvelope();

            using (var codedStream = new CodedInputStream(responseData))
            {
                decodedResponse.MergeFrom(codedStream);
            }

            return decodedResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        private async Task<bool> ProcessMessages(IMessage[] messages)
        {
            foreach (var inner in messages)
            {

            }

            return false;
        }

    }

}