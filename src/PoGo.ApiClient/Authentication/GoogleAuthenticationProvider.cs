using System;
using System.Threading.Tasks;
using Windows.System;
using DankMemes.GPSOAuthSharp;
using PoGo.ApiClient.Exceptions;
using PoGo.ApiClient.Enums;
using PoGo.ApiClient.Interfaces;

namespace PoGo.ApiClient.Authentication
{

    /// <summary>
    /// 
    /// </summary>
    public class GoogleAuthenticationProvider : IAuthenticationProvider
    {

        #region Private Members

        /// <summary>
        /// The Password for the user currently attempting  to authenticate.
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// The Username for the user currenrtly attempting to authenticate.
        /// </summary>
        public string Username { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public GoogleAuthenticationProvider(string email, string password)
        {
            Username = email;
            Password = password;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<AuthenticatedUser> GetAuthenticatedUser()
        {
            var client = new GPSOAuthClient(Username, Password);
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

            return new AuthenticatedUser
            {
                Username = Username,
                AccessToken = oauthResponse["Auth"],
                ExpiresUtc = DateTimeOffset.FromUnixTimeSeconds(long.Parse(oauthResponse["Expiry"])).UtcDateTime,
                ProviderType = AuthenticationProviderTypes.Google
            };
        }
    }
}