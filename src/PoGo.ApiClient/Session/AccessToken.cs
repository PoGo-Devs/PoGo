using Newtonsoft.Json;
using PoGo.ApiClient.Enums;
using POGOProtos.Networking.Envelopes;
using System;

namespace PoGo.ApiClient.Session
{
    /// <summary>
    /// Data used to access to current session
    /// </summary>
    public class AccessToken
    {

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public string Uid => $"{Username}-{AuthType}";

        /// <summary>
        /// The logged-in user's Username.
        /// </summary>
        [JsonProperty("username", Required = Required.Always)]
        public string Username { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("token", Required = Required.Always)]
        public string Token { get; internal set; }

        /// <summary>
        /// The time this token expired in UTC.
        /// </summary>
        [Obsolete("This property is left for existing token storage compatibility. Use ExpiresUtc instead.", false)]
        [JsonProperty("expiry")]
        public DateTime Expiry
        {
            get { return ExpiresUtc; }
            set { ExpiresUtc = value; }
        }

        /// <summary>
        /// The time this token expired in UTC.
        /// </summary>
        [JsonProperty("expiresUtc", Required = Required.Always)]
        public DateTime ExpiresUtc { get; internal set; }

        /// <summary>
        /// The <see cref="AuthType">authentication system</see> used to generate this AccessToken.  
        /// </summary>
        [JsonProperty("auth_type", Required = Required.Always)]
        public AuthType AuthType { get; internal set; }

        /// <summary>
        /// Returns whether or not this token is currently valid, with a large enough time-buffer to account for network latency.
        /// </summary>
        [JsonIgnore]
        public bool IsExpired => ExpiresUtc.AddSeconds(-60) <= DateTime.UtcNow;

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public AuthTicket AuthTicket { get; internal set; }

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
