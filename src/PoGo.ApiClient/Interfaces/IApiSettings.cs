using PoGo.ApiClient.Authentication;
using PoGo.ApiClient.Enums;

namespace PoGo.ApiClient.Interfaces
{

    /// <summary>
    /// 
    /// </summary>
    public interface IApiSettings
    {

        /// <summary>
        /// 
        /// </summary>
        AuthenticationProviderTypes AuthenticationProvider { get; set; }

        /// <summary>
        /// The <see cref="PoGoCredentials"/> objects that stores the username and password to be used 
        /// against the current <see cref="AuthenticationProvider"/>.
        /// </summary>
        PoGoCredentials Credentials { get; set; }

        /// <summary>
        /// 
        /// </summary>
        GeoCoordinate DefaultPosition { get; set; }

    }

}