using System;
using System.Threading.Tasks;
using Windows.System;
using DankMemes.GPSOAuthSharp;
using PoGo.ApiClient.Session;
using PoGo.ApiClient.Exceptions;
using PoGo.ApiClient.Enums;
using PoGo.ApiClient.Interfaces;

namespace PoGo.ApiClient.Login
{

    /// <summary>
    /// 
    /// </summary>
    public class GoogleLogin : ILoginProvider
    {

        private readonly string _email;
        private readonly string _password;

        public GoogleLogin(string email, string password)
        {
            _email = email;
            _password = password;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<AccessToken> GetAccessToken()
        {
            var client = new GPSOAuthClient(_email, _password);
            var response = await client.PerformMasterLogin(Constants.GoogleOAuthAndroidId);

            if (response.ContainsKey("Error"))
            {
                if (response.ContainsKey("Url"))
                {
                    await Launcher.LaunchUriAsync(new Uri(response["Url"]));
                }
                else
                {
                    throw new GoogleException(response["Error"]);
                }
            }

            //Todo: captcha/2fa implementation

            if (!response.ContainsKey("Auth"))
                throw new GoogleOfflineException();

            var oauthResponse = await client.PerformOAuth(response["Token"], Constants.GoogleOAuthService, Constants.GoogleOAuthAndroidId, 
                Constants.GoogleOAuthApp, Constants.GoogleOAuthClientSig);

            if (!oauthResponse.ContainsKey("Auth"))
            {
                throw new GoogleOfflineException();
            }

            return new AccessToken
            {
                Username = _email,
                Token = oauthResponse["Auth"],
                ExpiresUtc = DateTimeOffset.FromUnixTimeSeconds(long.Parse(oauthResponse["Expiry"])).UtcDateTime,
                AuthType = AuthType.Google
            };
        }
    }
}