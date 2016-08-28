using PoGo.ApiClient.Interfaces;
using POGOProtos.Data;
using System.Collections.ObjectModel;

namespace PoGo.GameServices
{

    /// <summary>
    /// Manages the game logic for your current location and what is nearby.
    /// </summary>
    public class LocationService : GameServiceBase
    {

        #region Private Members

        private ObservableCollectionPlus<PokemonData> _catchablePokemon = default(ObservableCollectionPlus<PokemonData>);
        private ObservableCollectionPlus<PokemonData> _nearbyPokemon = default(ObservableCollectionPlus<PokemonData>);
        private ObservableCollectionPlus<PokemonData> _nearbyPokestops = default(ObservableCollectionPlus<PokemonData>);

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollectionPlus<PokemonData> CatchablePokemon
        {
            get { return _catchablePokemon; }
            set { Set(ref _catchablePokemon, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollectionPlus<PokemonData> NearbyPokemon
        {
            get { return _nearbyPokemon; }
            set { Set(ref _nearbyPokemon, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollectionPlus<PokemonData> NearbyPokestops
        {
            get { return _nearbyPokestops; }
            set { Set(ref _nearbyPokestops, value); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="PokedexService"/>. 
        /// </summary>
        /// <param name="apiClient">The <see cref="IPokemonGoApiClient"/> instance to use for any Pokemon Go API requests.</param>

        public LocationService(IPokemonGoApiClient apiClient) : base(apiClient)
        {
            CatchablePokemon = new ObservableCollectionPlus<PokemonData>();
            NearbyPokemon = new ObservableCollectionPlus<PokemonData>();
            NearbyPokestops = new ObservableCollectionPlus<PokemonData>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public override void ResetState()
        {
            CatchablePokemon.Clear();
            NearbyPokemon.Clear();
            NearbyPokestops.Clear();
        }

        #endregion

    }

}