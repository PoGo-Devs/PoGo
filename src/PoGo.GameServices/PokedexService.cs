using PoGo.ApiClient.Interfaces;
using PoGo.ApiClient.Wrappers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PoGo.GameServices
{

    /// <summary>
    /// Manages the game logic for dealing with Pokemon inventory and previous Pokemon encounters.
    /// </summary>
    public class PokedexService : GameServiceBase
    {

        #region Private Members 

        private ObservableCollectionPlus<PokemonData> _pokedexInventory;
        private ObservableCollectionPlus<PokemonData> _pokemonInventory;

        #endregion

        #region Public Properties

        /// <summary>
        /// An <see cref="ObservableCollectionPlus{PokemonData}"/> containing the list of all Pokemon the current user
        /// has ever encountered.
        /// </summary>
        public ObservableCollectionPlus<PokemonData> PokedexInventory
        {
            get { return _pokedexInventory; }
            set { Set(ref _pokedexInventory, value); }
        }

        /// <summary>
        /// An <see cref="ObservableCollectionPlus{PokemonData}"/> containing the list of all Pokemon the current user
        /// currently possesses.
        /// </summary>
        public ObservableCollectionPlus<PokemonData> PokemonInventory
        {
            get { return _pokemonInventory; }
            set { Set(ref _pokemonInventory, value); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="PokedexService"/>. 
        /// </summary>
        /// <param name="apiClient">The <see cref="IPokemonGoApiClient"/> instance to use for any Pokemon Go API requests.</param>

        public PokedexService(IPokemonGoApiClient apiClient) : base(apiClient)
        {
            PokedexInventory = new ObservableCollectionPlus<PokemonData>();
            PokemonInventory = new ObservableCollectionPlus<PokemonData>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the PokemonInventory for the current user and loads it into <see cref="PokemonInventory"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> containing the results of the awaitable call.</returns>
        public async Task GetPokedexInventory()
        {
            //var results = await ApiClient.GetPokedexInventoryAsync();
            //PokedexInventory.AddRange(results);
        }

        /// <summary>
        /// Gets the PokemonInventory for the current user and loads it into <see cref="PokemonInventory"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> containing the results of the awaitable call.</returns>
        public async Task GetPokemonInventory()
        {
            //var results = await ApiClient.GetPokemonInventoryAsync();
            //PokemonInventory.AddRange(results);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void ResetState()
        {
            PokedexInventory.Clear();
            PokemonInventory.Clear();
        }

        #endregion

        #region Private Methods

        //RWM: Add any internal helper methods here.

        #endregion

    }

}