using PoGo.ApiClient.Interfaces;

namespace PoGo.GameServices
{

    /// <summary>
    /// Manages the game logic for managing your credentials
    /// </summary>
    public class AuthenticationService : GameServiceBase
    {

        #region Constructors

        public AuthenticationService(IPokemonGoApiClient apiClient) : base(apiClient)
        {
        }

        #endregion

    }

}