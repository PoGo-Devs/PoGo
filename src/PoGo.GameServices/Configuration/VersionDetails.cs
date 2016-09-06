using Newtonsoft.Json;

namespace PoGo.GameServices.Configuration
{

    /// <summary>
    /// 
    /// </summary>
    public class VersionDetails
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("dependencies")]
        public string[] Dependencies { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("setup_file")]
        public string SetupFile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }

    }

}