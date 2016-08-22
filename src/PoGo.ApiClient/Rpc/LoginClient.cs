using Google.Protobuf;
using PoGo.ApiClient.Enums;
using PoGo.ApiClient.Exceptions;
using PoGo.ApiClient.Extensions;
using PoGo.ApiClient.Login;
using POGOProtos.Networking.Requests;
using POGOProtos.Networking.Requests.Messages;
using System;
using System.Threading.Tasks;
using PoGo.ApiClient.Interfaces;
using PoGo.ApiClient.Proto;
using POGOProtos.Networking.Responses;

namespace PoGo.ApiClient.Rpc
{
    public delegate void GoogleDeviceCodeDelegate(string code, string uri);

    public class LoginClient : BaseRpc
    {
        //public event GoogleDeviceCodeDelegate GoogleDeviceCodeEvent;
        private readonly ILoginType login;

        public LoginClient(PokemonGoApiClient client) : base(client)
        {
            login = SetLoginType(client.Settings);
        }

        private static ILoginType SetLoginType(ISettings settings)
        {
            switch (settings.AuthType)
            {
                case AuthType.Google:
                    return new GoogleLogin(settings.GoogleUsername, settings.GooglePassword);
                case AuthType.Ptc:
                    return new PtcLogin(settings.PtcUsername, settings.PtcPassword);
                default:
                    throw new ArgumentOutOfRangeException(nameof(settings.AuthType), "Unknown AuthType");
            }
        }

        public async Task DoLogin()
        {
            if (Client.AccessToken == null || Client.AccessToken.IsExpired)
                Client.AccessToken = await login.GetAccessToken().ConfigureAwait(false);            
            await SetServer().ConfigureAwait(false);                        
        }

        private async Task<ResponseContainer<GetPlayerResponse>> SetServer()
        {
            #region Standard intial request messages in right Order

            var getPlayerMessage = new GetPlayerMessage();
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

            #endregion

            var serverRequest = RequestBuilder.GetInitialRequestEnvelope(
                new Request
                {
                    RequestType = RequestType.GetPlayer,
                    RequestMessage = getPlayerMessage.ToByteString()
                }, new Request
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


            var serverResponse = await PostProto<Request>(Resources.RpcUrl, serverRequest);

            //LastRpcRequest = DateTime.Now;
            //var response = await PostProtoPayload<Request, GetPlayerResponse, GetHatchedEggsResponse,
            //GetInventoryResponse, CheckAwardedBadgesResponse, DownloadSettingsResponse>(serverRequest);

            if (serverResponse.AuthTicket == null)
            {
                Client.AccessToken = null;
                throw new AccessTokenExpiredException();
            }

            Client.AccessToken.AuthTicket = serverResponse.AuthTicket;
            Client.ApiUrl = serverResponse.ApiUrl;

            //return new ResponseContainer<GetPlayerResponse>(response.Item1, response.Item2, response.Item3, response.Item4, response.Item5);
            return null;
        }
    }
}