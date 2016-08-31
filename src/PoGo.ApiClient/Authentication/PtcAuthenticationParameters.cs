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
        [JsonProperty("lt", Required = Required.Always)]
        public string Lt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("execution", Required = Required.Always)]
        public string Execution { get; set; }

    }

}