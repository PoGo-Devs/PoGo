using Newtonsoft.Json;
using PoGo.ApiClient.Enums;
using POGOProtos.Networking.Envelopes;
using System;

namespace PoGo.ApiClient.Authentication
{
    /// <summary>
    /// Data used to access to current session
    /// </summary>
    public class AuthenticatedUser
    {

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public AuthTicket AuthTicket { get; internal set; }

        /// <summary>
        /// The <see cref="AuthenticationProviderTypes">authentication system</see> used to generate this AccessToken.  
        /// </summary>
        [JsonProperty("providerType", Required = Required.Always)]
        public AuthenticationProviderTypes ProviderType { get; internal set; }

        /// <summary>
        /// The time this token expired in UTC.
        /// </summary>
        [JsonProperty("expiresUtc", Required = Required.Always)]
        public DateTime ExpiresUtc { get; internal set; }

        /// <summary>
        /// Returns whether or not this token is currently valid, with a large enough time-buffer to account for network latency.
        /// </summary>
        [JsonIgnore]
        public bool IsExpired => ExpiresUtc.AddSeconds(-60) <= DateTime.UtcNow;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("accessToken", Required = Required.Always)]
        public string AccessToken { get; internal set; }

        /// <summary>
        /// The logged-in user's Username.
        /// </summary>
        [JsonProperty("username", Required = Required.Always)]
        public string Username { get; internal set; }

        #endregion

        #region Methods

        /// <summary>
        /// Expires the current AccessToken so that a new one can be issued.
        /// </summary>
        public void Expire()
        {
            ExpiresUtc = DateTime.UtcNow.AddSeconds(-60);
            AuthTicket = null;
        }

        #endregion

    }

}
