using Google.Protobuf;
using PoGo.ApiClient.Enums;
using PoGo.ApiClient.Exceptions;
using PoGo.ApiClient.Interfaces;
using PoGo.ApiClient.Login;
using POGOProtos.Networking.Requests;
using POGOProtos.Networking.Requests.Messages;
using System;
using System.Threading.Tasks;

namespace PoGo.ApiClient.Rpc
{

    /// <summary>
    /// 
    /// </summary>
    public class UserClient : BaseRpc
    {
        private readonly ILoginProvider login;

        public UserClient(PokemonGoApiClient client) : base(client)
        {
            login = SetLoginType(client.Settings);
        }

        private static ILoginProvider SetLoginType(IApiSettings settings)
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

        public async Task DoLoginAsync()
        {
            if (Client.AccessToken == null || Client.AccessToken.IsExpired)
            {
                Client.AccessToken = await login.GetAccessToken().ConfigureAwait(false);
            }
            ///robertmclaws: Is it really necessary to put this in a separate function?
            await SetServerAsync().ConfigureAwait(false);                        
        }

        private async Task SetServerAsync()
        {

            var serverRequest = Client.RequestBuilder.GetInitialRequestEnvelope(
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

            var serverResponse = await Client.PostProto<Request>(Resources.RpcUrl, serverRequest);

            if(serverRequest.StatusCode == (int) StatusCode.AccessDenied)
            {
                throw new AccountLockedException();
            }

            if (serverResponse.AuthTicket == null)
            {
                Client.AccessToken = null;
                throw new AccessTokenExpiredException();
            }

            Client.AccessToken.AuthTicket = serverResponse.AuthTicket;

            if (serverResponse.StatusCode == (int)StatusCode.Redirect)
            {
                Client.ApiUrl = serverResponse.ApiUrl;
            }
        }
    }
}