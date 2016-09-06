using Newtonsoft.Json;
using PoGo.GameServices.Configuration;
using System;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace PoGo.GameServices
{

    /// <summary>
    /// 
    /// </summary>
    public class ConfigurationService
    {

        #region Private Members

        private const string VersionFileUrl = @"https://raw.githubusercontent.com/PoGo-Devs/PoGo/master/version.json";

        #endregion

        #region Properties

        /// <summary>
        /// The current RuntimeConfig loaded from GitHub.
        /// </summary>
        public RuntimeConfig RuntimeConfig { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public async Task LoadConfigFromGitHubAsync()
        {
            var httpFilter = new HttpBaseProtocolFilter();
            httpFilter.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;

            // @robertmclaws to do: Do we need to unwrap thike we had to with the other API Clients?
            using (var client = new HttpClient(httpFilter))
            {
                using (var response = await client.GetAsync(new Uri(VersionFileUrl), HttpCompletionOption.ResponseContentRead))
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var runtimeConfig = JsonConvert.DeserializeObject<RuntimeConfig>(json);
                    if (runtimeConfig == null)
                    {
                        throw new Exception("Could not retrieve remote configuration. Cannot guarantee that requests will mirror the Pokemon API.");
                    }
                    RuntimeConfig = runtimeConfig;
                }
            }
        }

        #endregion

    }

}