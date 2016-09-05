using Google.Protobuf;
using PoGo.ApiClient.Authentication;
using PoGo.ApiClient.Enums;
using PoGo.ApiClient.Exceptions;
using PoGo.ApiClient.Helpers;
using PoGo.ApiClient.Interfaces;
using PoGo.ApiClient.Rpc;
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
        /// <remarks>
        /// We're getting a new RequestBuilder every time we call this property.
        /// </remarks>
        internal RequestBuilder RequestBuilder => new RequestBuilder(AuthenticatedUser, CurrentPosition, DeviceProfile, StartTime);

        /// <summary>
        /// 
        /// </summary>
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
        public IApiSettings ApiSettings { get; }

        /// <summary>
        /// 
        /// </summary>
        public string ApiUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AuthenticatedUser AuthenticatedUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public GeoCoordinate CurrentPosition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IAuthenticationProvider CurrentProvider { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public IDeviceProfile DeviceProfile { get; }

        /// <summary>
        /// 
        /// </summary>
        public IDownloadClient Download { get; }

        /// <summary>
        /// 
        /// </summary>
        public IEncounterClient Encounter { get; }

        /// <summary>
        /// 
        /// </summary>
        public IFortClient Fort { get; }

        /// <summary>
        /// 
        /// </summary>
        public IInventoryClient Inventory { get; }

        /// <summary>
        /// 
        /// </summary>
        public IMapClient Map { get; }

        /// <summary>
        /// 
        /// </summary>
        public IPlayerClient Player { get; }

        /// <summary>
        /// 
        /// </summary>
        internal BlockingCollection<RequestEnvelope> RequestQueue { get; }

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset StartTime { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public PokemonGoApiClient() : base(Handler)
        {
            DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", Constants.HttpClientUserAgent);
            DefaultRequestHeaders.ExpectContinue = false;
            DefaultRequestHeaders.TryAddWithoutValidation("Connection", Constants.HttpClientConnection);
            DefaultRequestHeaders.TryAddWithoutValidation("Accept", Constants.HttpClientAccept);
            DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", Constants.HttpClientContentType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="deviceProfile"></param>
        /// <param name="authenticatedUser"></param>
        public PokemonGoApiClient(IApiSettings settings, IDeviceProfile deviceProfile, AuthenticatedUser authenticatedUser = null) : this()
        {
            StartTime = DateTimeOffset.UtcNow;
            CancellationTokenSource = new CancellationTokenSource();
            RequestQueue = new BlockingCollection<RequestEnvelope>();

            Player = new PlayerClient(this);
            Download = new DownloadClient(this);
            Inventory = new InventoryClient(this);
            Map = new MapClient(this);
            Fort = new FortClient(this);
            Encounter = new EncounterClient(this);

            ApiSettings = settings;
            DeviceProfile = deviceProfile;

            SetAuthenticationProvider();
            AuthenticatedUser = authenticatedUser;
            Player.SetCoordinates(ApiSettings.DefaultPosition.Latitude, ApiSettings.DefaultPosition.Longitude, ApiSettings.DefaultPosition.Accuracy);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task AuthenticateAsync()
        {
            CancelPendingRequests();
            if (AuthenticatedUser == null || AuthenticatedUser.IsExpired)
            {
                AuthenticatedUser = await CurrentProvider.GetAuthenticatedUser().ConfigureAwait(false);
            }

            // @robertmclaws: We're going to bypass the queue here.
            var envelope = RequestBuilder.GetInitialRequestEnvelope(
                new Request
                {
                    RequestType = RequestType.GetPlayer,
                    RequestMessage = new GetPlayerMessage().ToByteString()
                },
                new Request
                {
                    RequestType = RequestType.CheckChallenge,
                    RequestMessage = new CheckChallengeMessage().ToByteString()
                }
            );
            var result = await PostProtoPayload(ApiUrl, envelope);
            ProcessMessages(result);
            // @robertmclaws: Not sure if this is right, but should allow the queue to start filling back up.
            CancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public async Task AuthenticateAsync(PoGoCredentials credentials)
        {
            ApiSettings.Credentials = credentials;
            await AuthenticateAsync();
        }

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
            var envelope = BuildRequestEnvelope(requestType, message);
            return RequestQueue.TryAdd(envelope);

        }

        /// <summary>
        /// 
        /// </summary>
        public void SetAuthenticationProvider()
        {
            switch (ApiSettings.Credentials.AuthenticationProvider)
            {
                case AuthenticationProviderTypes.Google:
                    CurrentProvider = new GoogleAuthenticationProvider(ApiSettings.Credentials.Username, ApiSettings.Credentials.Password);
                    break;
                case AuthenticationProviderTypes.PokemonTrainerClub:
                    CurrentProvider = new PtcAuthenticationProvider(ApiSettings.Credentials.Username, ApiSettings.Credentials.Password);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ApiSettings.Credentials.AuthenticationProvider), "Unknown AuthType");
            }
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

                     var response = await PostProtoPayload(ApiUrl, workItem);
                     // robertmclaws: If the request cancelled out for some reason, let's move on.
                     if (response == null) continue;
                     ProcessMessages(response);
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
        internal RequestEnvelope BuildRequestEnvelope(RequestType requestType, IMessage message)
        {
            RequestEnvelope envelope = null;
            if (_singleRequests.Contains(requestType))
            {
                envelope =  RequestBuilder.GetRequestEnvelope(
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
                var getInventoryMessage = new GetInventoryMessage
                {
                    LastTimestampMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                };
                var downloadSettingsMessage = new DownloadSettingsMessage
                {
                    Hash = Download.DownloadSettingsHash
                };

                envelope =  RequestBuilder.GetRequestEnvelope(
                    new Request
                    {
                        RequestType = requestType,
                        RequestMessage = message.ToByteString()
                    },
                    new Request
                    {
                        RequestType = RequestType.GetHatchedEggs,
                        RequestMessage = new GetHatchedEggsMessage().ToByteString()
                    },
                    new Request
                    {
                        RequestType = RequestType.GetInventory,
                        RequestMessage = getInventoryMessage.ToByteString()
                    },
                    new Request
                    {
                        RequestType = RequestType.CheckAwardedBadges,
                        RequestMessage = new CheckAwardedBadgesMessage().ToByteString()
                    },
                    new Request
                    {
                        RequestType = RequestType.DownloadSettings,
                        RequestMessage = downloadSettingsMessage.ToByteString()
                    },
                    new Request
                    {
                        RequestType = RequestType.CheckChallenge,
                        RequestMessage = new CheckChallengeMessage().ToByteString()
                    }

                );
            }
            envelope.ExpectedResponseTypes = new List<Type>(ResponseMessageMapper.GetExpectedResponseTypes(envelope.Requests));
            return envelope;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestEnvelope"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        internal async Task<IMessage[]> PostProtoPayload(string url, RequestEnvelope requestEnvelope)
        {
            // robertmclaws: Start by preparing the results array based on the types we're expecting to be returned.
            var result = new IMessage[requestEnvelope.ExpectedResponseTypes.Count - 1];
            for (var i = 0; i < requestEnvelope.ExpectedResponseTypes.Count - 1; i++)
            {
                result[i] = Activator.CreateInstance(requestEnvelope.ExpectedResponseTypes[i]) as IMessage;
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
            for (var i = 0; i < requestEnvelope.ExpectedResponseTypes.Count - 1; i++)
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
            if (AuthenticatedUser == null || AuthenticatedUser.IsExpired)
            {
                // @robertmclaws: Calling "Authenticate" cancels all current requests and fires off a complex login routine.
                //                More than likely, we just want to refresh the tokens.
                await CurrentProvider.GetAuthenticatedUser().ConfigureAwait(false);
            }

            var result = await PostAsync(url, payload, token);

            var response = new ResponseEnvelope();
            var responseData = await result.Content.ReadAsByteArrayAsync();

            using (var codedStream = new CodedInputStream(responseData))
            {
                response.MergeFrom(codedStream);
            }

            switch ((StatusCodes)response.StatusCode)
            {
                case StatusCodes.ValidResponse:
                    if (response.AuthTicket != null)
                    {
                        Logger.Write("Received a new AuthTicket from the Api!");
                        AuthenticatedUser.AuthTicket = response.AuthTicket;
                        // robertmclaws to do: See if we need to clone the AccessToken so we don't have a threading violation.
                        RaiseAuthenticatedUserUpdated(AuthenticatedUser);
                    }
                    return response;

                case StatusCodes.AccessDenied:
                    Logger.Write("Account has been banned. Our condolences for your loss.");
                    CancelCurrentRequests();
                    //RequestQueue.CompleteAdding();
                    // robertmclaws to do: Allow you to stop adding events to the queue, and re-initialize the queue if needed.
                    throw new AccountLockedException();

                case StatusCodes.Redirect:
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

                case StatusCodes.InvalidToken:
                    Logger.Write("Received StatusCode 102, reauthenticating.");
                    AuthenticatedUser?.Expire();
                    // robertmclaws: trigger a retry here. We'll automatically try to log in again on the next request.
                    await Task.Delay(retryPolicy.DelayInSeconds * 1000);
                    return await PostProto(response.ApiUrl, payload, retryPolicy, token, attemptCount, redirectCount);

                case StatusCodes.ServerOverloaded:
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

        #endregion

    }

}