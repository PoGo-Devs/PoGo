using System.Threading.Tasks;
using PoGo.ApiClient.Authentication;

namespace PoGo.ApiClient.Interfaces
{

    /// <summary>
    /// Interface for the login into the game using either Google or PTC
    /// </summary>
    public interface IAuthenticationProvider
    {

        /// <summary>
        /// 
        /// </summary>
        string Password { get; }

        /// <summary>
        /// 
        /// </summary>
        string Username { get; }

        /// <summary>
        ///     Gets the access token.
        /// </summary>
        /// <returns></returns>
        Task<AuthenticatedUser> GetAuthenticatedUser();

    }

}