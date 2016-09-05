using PoGo.ApiClient.Interfaces;
using Template10.Mvvm;

namespace PoGo.GameServices
{

    /// <summary>
    /// The base class for all GameService functionality.
    /// </summary>
    public class GameServiceBase : BindableBase
    {

        #region Internal Properties

        /// <summary>
        /// The <see cref="IPokemonGoApiClient"/> instance to use to use to get the player's data.
        /// </summary>
        internal IPokemonGoApiClient ApiClient { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="PokedexService"/>. 
        /// </summary>
        /// <param name="apiClient">The <see cref="IPokemonGoApiClient"/> instance to use for any Pokemon Go API requests.</param>

        public GameServiceBase(IPokemonGoApiClient apiClient)
        {
            ApiClient = apiClient;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public virtual void RegisterClientEvents()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void ResetState()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void UnregisterClientEvents()
        {
        }

        #endregion

    }

}