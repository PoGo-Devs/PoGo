using PoGo.ApiClient.Interfaces;
using POGOProtos.Data;
using System.Collections.ObjectModel;

namespace PoGo.GameServices
{

    /// <summary>
    /// Manages the game logic for Pokestops, including Lure Modules and claiming rewards.
    /// </summary>
    public class PokestopService : GameServiceBase
    {

        #region Private Members

        private ObservableCollectionPlus<PokemonData> _luredPokemon = default(ObservableCollectionPlus<PokemonData>);

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollectionPlus<PokemonData> LuredPokemon
        {
            get { return _luredPokemon; }
            set { Set(ref _luredPokemon, value); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="PokedexService"/>. 
        /// </summary>
        /// <param name="apiClient">The <see cref="IPokemonGoApiClient"/> instance to use for any Pokemon Go API requests.</param>

        public PokestopService(IPokemonGoApiClient apiClient) : base(apiClient)
        {
            LuredPokemon = new ObservableCollectionPlus<PokemonData>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public override void ResetState()
        {
            LuredPokemon.Clear();
        }

        #endregion

    }

}