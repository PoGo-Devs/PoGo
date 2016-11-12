using Newtonsoft.Json;

namespace PoGo.ApiClient.Authentication
{

    /// <summary>
    /// 
    /// </summary>
    internal class PtcAuthenticationParameters
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lt")]
        public string Lt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("execution")]
        public string Execution { get; set; }

    }

}