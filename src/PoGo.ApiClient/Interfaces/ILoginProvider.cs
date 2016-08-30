using System.Threading.Tasks;
using PoGo.ApiClient.Session;

namespace PoGo.ApiClient.Interfaces
{

    /// <summary>
    ///     Interface for the login into the game using either Google or PTC
    /// </summary>
    internal interface ILoginProvider
    {

        /// <summary>
        ///     Gets the access token.
        /// </summary>
        /// <returns></returns>
        Task<AccessToken> GetAccessToken();

    }

}