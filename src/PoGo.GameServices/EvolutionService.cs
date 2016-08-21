using PoGo.ApiClient.Interfaces;
using POGOProtos.Inventory;
using System.Collections.ObjectModel;

namespace PoGo.GameServices
{

    /// <summary>
    /// Manages the game logic for evolving Pokemon, including managing Stardust and Candy.
    /// </summary>
    public class EvolutionService : GameServiceBase
    {

        #region Private Members

        ObservableCollectionPlus<Candy> _pokemonCandies;

        #endregion

        #region Properties



        /// <summary>
        /// Stores the player's current Candies.
        /// </summary>
        public ObservableCollectionPlus<Candy> PokemonCandies
        {
            get { return _pokemonCandies; }
            set { Set(ref _pokemonCandies, value); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiClient"></param>
        public EvolutionService(IPokemonGoApiClient apiClient) : base(apiClient)
        {
            PokemonCandies = new ObservableCollectionPlus<Candy>();
        }

        #endregion

    }

}