using Google.Protobuf;
using PoGo.ApiClient.Enums;
using PoGo.ApiClient.Exceptions;
using PoGo.ApiClient.Helpers;
using PoGo.ApiClient.Interfaces;
using PoGo.ApiClient.Rpc;
using PoGo.ApiClient.Session;
using POGOProtos.Networking.Envelopes;
using POGOProtos.Networking.Requests;
using POGOProtos.Networking.Requests.Messages;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
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

        private static readonly HttpClientHandler Handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            AllowAutoRedirect = false
        };

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
        public PokemonGoApiClient() : base(Handler)
        {
            DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Niantic App");
            DefaultRequestHeaders.ExpectContinue = false;
            DefaultRequestHeaders.TryAddWithoutValidation("Connection", "keep-alive");
            DefaultRequestHeaders.TryAddWithoutValidation("Accept", "*/*");
            DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
        }

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
        public bool QueueRequest(RequestType requestType, IMessage message)
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
             return Task.Factory.StartNew(async () =>
             {
                 foreach (var workItem in RequestQueue.GetConsumingEnumerable())
                 {
                     // robertmclaws: The line below should collapse the queue quickly.
                     if (CancellationTokenSource.IsCancellationRequested)
                     {
                         Logger.Write("A queued request was cancelled before it was processed.");
                         continue;
                     }

                     var response = await PostProtoPayload(ApiUrl, workItem, null);
                     if (response == null) continue;
                     await ProcessMessages(response);
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
        internal RequestEnvelope BuildBatchRequestEnvelope(IMessage message, RequestType requestType)
        {

            var getHatchedEggsMessage = new GetHatchedEggsMessage();
            var getInventoryMessage = new GetInventoryMessage
            {
                LastTimestampMs = DateTime.UtcNow.ToUnixTime()
            };
            var checkAwardedBadgesMessage = new CheckAwardedBadgesMessage();
            var downloadSettingsMessage = new DownloadSettingsMessage
            {
                Hash = Download.DownloadSettingsHash
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
        /// <param name="url"></param>
        /// <param name="requestEnvelope"></param>
        /// <param name="responseTypes"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        internal async Task<IMessage[]> PostProtoPayload(string url, RequestEnvelope requestEnvelope, params Type[] responseTypes)
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
            //               Since the function we're calling is now recursive, let's make sure we only encode the payload once.
            var byteArrayContent = new ByteArrayContent(requestEnvelope.ToByteString().ToByteArray());
            var retryPolicy = RetryPolicyManager.GetRetryPolicy(requestEnvelope.Requests[0].RequestType);
            var response = await PostProto(url, byteArrayContent, retryPolicy, CancellationTokenSource.Token);

            if (response == null || response.Returns.Count == 0)
            {
                // robertmclaws: We didn't get anything back after several attempts. Let's bounce.
                return null;
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
        /// <param name="url"></param>
        /// <param name="payload"></param>
        /// <param name="retryPolicy"></param>
        /// <param name="token"></param>
        /// <param name="attemptCount"></param>
        /// <param name="redirectCount"></param>
        /// <returns></returns>
        internal async Task<ResponseEnvelope> PostProto(string url, ByteArrayContent payload, RetryPolicy retryPolicy, CancellationToken token,
            int attemptCount = 0, int redirectCount = 0)
        {

            // robertmclaws: If someone wants us to be done, we're done.
            if (token.IsCancellationRequested)
            {
                Logger.Write("The request was cancelled. (PostProto cancellation check)");
                return null;
            }
            
            attemptCount++;

            // robertmclaws: If we've exceeded the maximum number of attempts, we're done.
            if (attemptCount > retryPolicy.MaxFailureAttempts)
            {
                Logger.Write("The request exceeded the number of retries allowed and has been cancelled.");
                return null;
            }
            if (redirectCount > retryPolicy.MaxRedirectAttempts)
            {
                Logger.Write("The request exceeded the number of redirect attempts allowed and has been cancelled.");
                return null;
            }

            // robertmclaws: We're gonna keep going, so let's be pro-active about token failures, instead of reactive.
            if (AccessToken == null || AccessToken.IsExpired)
            {
                await Login.DoLoginAsync();
            }

            var result = await PostAsync(url, payload, token);

            var response = new ResponseEnvelope();
            var responseData = await result.Content.ReadAsByteArrayAsync();

            using (var codedStream = new CodedInputStream(responseData))
            {
                response.MergeFrom(codedStream);
            }

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
                    return response;

                case StatusCode.AccessDenied:
                    Logger.Write("Account has been banned. Our condolences for your loss.");
                    CancelCurrentRequests();
                    //RequestQueue.CompleteAdding();
                    // robertmclaws to do: Allow you to stop adding events to the queue, and re-initialize the queue if needed.
                    throw new AccountLockedException();

                case StatusCode.Redirect:
                    if (!Regex.IsMatch(response.ApiUrl, "pgorelease\\.nianticlabs\\.com\\/plfe\\/\\d+"))
                    {
                        throw new Exception($"Received an incorrect API url '{response.ApiUrl}', status code was '{response.StatusCode}'.");
                    }
                    ApiUrl = $"https://{response.ApiUrl}/rpc";
                    Logger.Write($"Received an updated API url = {ApiUrl}");
                    // robertmclaws to do: Check to see if redirects should count against the RetryPolicy.
                    await Task.Delay(retryPolicy.DelayInSeconds * 1000);
                    redirectCount++;
                    return await PostProto(response.ApiUrl, payload, retryPolicy, token, attemptCount, redirectCount);

                case StatusCode.InvalidToken:
                    Logger.Write("Received StatusCode 102, reauthenticating.");
                    AccessToken?.Expire();
                    // robertmclaws: trigger a retry here. We'll automatically try to log in again on the next request.
                    await Task.Delay(retryPolicy.DelayInSeconds * 1000);
                    return await PostProto(response.ApiUrl, payload, retryPolicy, token, attemptCount, redirectCount);

                case StatusCode.ServerOverloaded:
                    // Per @wallycz, on code 52, wait 11 seconds before sending the request again.
                    Logger.Write("Server says to slow the hell down. Try again in 11 sec.");
                    await Task.Delay(11000);
                    return await PostProto(response.ApiUrl, payload, retryPolicy, token, attemptCount, redirectCount);

                default:
                    Logger.Write($"Unknown status code: {response.StatusCode}");
                    break;
            }

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        internal async Task<bool> ProcessMessages(IMessage[] messages)
        {
            foreach (var inner in messages)
            {

            }

            return false;
        }

        #endregion

    }

}