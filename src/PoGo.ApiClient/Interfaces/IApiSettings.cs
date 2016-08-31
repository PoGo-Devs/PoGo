using PoGo.ApiClient.Authentication;

namespace PoGo.ApiClient.Interfaces
{

    /// <summary>
    /// 
    /// </summary>
    public interface IApiSettings
    {

        /// <summary>
        /// The <see cref="PoGoCredentials"/> objects that stores the username and password to be used 
        /// against the given <see cref="IAuthenticationProvider"/>.
        /// </summary>
        PoGoCredentials Credentials { get; set; }

        /// <summary>
        /// 
        /// </summary>
        GeoCoordinate DefaultPosition { get; set; }

    }

}