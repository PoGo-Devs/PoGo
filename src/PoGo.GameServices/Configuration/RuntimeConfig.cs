using Newtonsoft.Json;
using System;
using Windows.ApplicationModel;

namespace PoGo.GameServices.Configuration
{

    /// <summary>
    /// 
    /// </summary>
    /// <example>
    // {
    //  "minimum_version": "1.0.29",
    //  "unknown25": 7363665268261374000,
    //  "seed1": 1634035250,
    //  "version_number": 3500,
    //  "latest_release": {
    //    "version": "1.0.29",
    //    "setup_file": "https://github.com/ST-Apps/PoGo-UWP/releases/download/v1.1.0-RC2/PokemonGo-UWP_1.0.29.0_{arch}.appxbundle",
    //    "dependencies": [
    //    ]
    //   }
    // }
    /// </example>
    public class RuntimeConfig
    {

        /// <summary>
        /// The version of the official client to report to the API.
        /// </summary>
        [JsonProperty("version_number")]
        public string ApiVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("latest_release")]
        public VersionDetails LatestRelease { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("seed1")]
        public string LocationHashSeed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("minimum_version")]
        public string MinimumVersionString { get; set; }

        /// <summary>
        /// A PackageVersion object to be used for comparison.
        /// </summary>
        [JsonIgnore]
        public PackageVersion MinumumVersion {
            get
            {
                Version versionResult;
                var parsed = Version.TryParse(MinimumVersionString, out versionResult);
                return parsed ? versionResult.ToPackageVersion() : new PackageVersion();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("unknown25")]
        public string VersionHash { get; set; }

    }

}