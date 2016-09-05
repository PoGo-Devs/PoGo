using Newtonsoft.Json;
using PoGo.ApiClient.Enums;
using PoGo.ApiClient.Exceptions;
using PoGo.ApiClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Foundation;

namespace PoGo.ApiClient.Authentication
{

    /// <summary>
    /// 
    /// </summary>
    internal class PtcAuthenticationProvider : IAuthenticationProvider
    {

        #region Private Members

        /// <summary>
        /// 
        /// </summary>
        private static HttpClient HttpClient;

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
        static PtcAuthenticationProvider()
        {
            HttpClient = new HttpClient(
                new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip,
                    AllowAutoRedirect = false
                }
            );
            HttpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(Constants.LoginUserAgent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public PtcAuthenticationProvider(string username, string password)
        {
            Username = username;
            Password = password;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<AuthenticatedUser> GetAuthenticatedUser()
        {
            var loginData = await GetLoginParameters().ConfigureAwait(false);
            var authTicket = await GetAuthenticationTicket(loginData).ConfigureAwait(false);
            var accessToken = await GetOAuthToken(authTicket).ConfigureAwait(false);
            return accessToken;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Responsible for retrieving login parameters for <see cref="GetAuthenticationTicket" />.
        /// </summary>
        /// <returns><see cref="PtcAuthenticationParameters" /> for <see cref="GetAuthenticationTicket" />.</returns>
        internal async Task<PtcAuthenticationParameters> GetLoginParameters()
        {
            var response = await HttpClient.GetAsync(Constants.LoginUrl);
            var loginData = JsonConvert.DeserializeObject<PtcAuthenticationParameters>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            return loginData;
        }

        /// <summary>
        /// Authenticates against the PTC login service and acquires an Authentication Ticket.
        /// </summary>
        /// <param name="loginData">The <see cref="PtcAuthenticationParameters" /> to use from this request. Obtained by calling <see cref="GetLoginParameters(HttpClient)"/>.</param>
        /// <returns></returns>
        internal async Task<string> GetAuthenticationTicket(PtcAuthenticationParameters loginData)
        {
            var requestData = new Dictionary<string, string>
                {
                    {"lt", loginData.Lt},
                    {"execution", loginData.Execution},
                    {"_eventId", Constants.PtcAuthTicketEventId},
                    {"username", Username},
                    {"password", Password}
                };

            var responseMessage = await HttpClient.PostAsync(Constants.LoginUrl, new FormUrlEncodedContent(requestData)).ConfigureAwait(false);

            // robertmclaws: No need to even read the string if we have results from the location query.
            if (responseMessage.Headers.Location != null)
            {
                var decoder = new WwwFormUrlDecoder(responseMessage.Headers.Location.Query);
                if (decoder.Count == 0)
                {
                    if (Debugger.IsAttached) Debugger.Break();
                    throw new LoginFailedException();
                }
                return decoder.GetFirstValueByName("ticket");
            }

            var responseContent = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            var response = JsonConvert.DeserializeObject<PtcAuthenticationTicketResponse>(responseContent);

            var loginFailedWords = new string[] { "incorrect", "disabled" };

            var loginFailed = loginFailedWords.Any(failedWord => response.Errors.Any(error => error.Contains(failedWord)));
            if (loginFailed)
            {
                throw new LoginFailedException(responseMessage);
            }
            throw new Exception($"Pokemon Trainer Club responded with the following error(s): '{string.Join(", ", response.Errors)}'");
        }

        /// <summary>
        /// Retrieves an OAuth 2.0 token for a given Authentication ticket.
        /// </summary>
        /// <param name="authTicket">The Authentication Ticket to use for this request. Obtained by calling <see cref="GetAuthenticationTicket(PtcAuthenticationParameters)"/>.</param>
        /// <returns></returns>
        internal async Task<AuthenticatedUser> GetOAuthToken(string authTicket)
        {
            var requestData = new Dictionary<string, string>
                {
                    {"client_id", Constants.PtcOAuthClientId},
                    {"redirect_uri", Constants.PtcOAuthRedirectUri},
                    {"client_secret", Constants.PtcOAuthClientSecret},
                    {"grant_type", Constants.PtcOAuthGrantType},
                    {"code", authTicket}
                };

            var responseMessage = await HttpClient.PostAsync(Constants.LoginOAuthUrl, new FormUrlEncodedContent(requestData)).ConfigureAwait(false);
            var responseContent = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (string.IsNullOrWhiteSpace(responseContent))
            {
                throw new Exception("Your login was OK, but we could not get an API Token.");
            }

            var decoder = new WwwFormUrlDecoder(responseContent);
            if (decoder.Count == 0)
            {
                throw new Exception("Your login was OK, but we could not get an API Token.");
            }

            return new AuthenticatedUser
            {
                Username = this.Username,
                AccessToken = decoder.GetFirstValueByName("access_token"),
                // @robertmclaws: Subtract 1 hour from the token to solve this issue: https://github.com/pogodevorg/pgoapi/issues/86
                ExpiresUtc = DateTime.UtcNow.AddSeconds(int.Parse(decoder.GetFirstValueByName("expires")) - 3600),
                ProviderType = AuthenticationProviderTypes.PokemonTrainerClub
            };
        }

        #endregion

    }

}