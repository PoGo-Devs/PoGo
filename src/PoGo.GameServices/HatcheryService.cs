using PoGo.ApiClient.Interfaces;
using PoGo.ApiClient.Wrappers;
using POGOProtos.Inventory;
using System.Collections.ObjectModel;

namespace PoGo.GameServices
{

    /// <summary>
    /// Manages the game logic for Eggs, Incubators and Hatching.
    /// </summary>
    public class HatcheryService : GameServiceBase
    {

        #region Private Members

        ObservableCollectionPlus<PokemonData> _eggs;
        ObservableCollectionPlus<EggIncubator> _incubatorsFree;
        ObservableCollectionPlus<EggIncubator> _incubatorsUsed;

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollectionPlus<PokemonData> Eggs
        {
            get { return _eggs; }
            set { Set(ref _eggs, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollectionPlus<EggIncubator> IncubatorsFree
        {
            get { return _incubatorsFree; }
            set { Set(ref _incubatorsFree, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollectionPlus<EggIncubator> IncubatorsUsed
        {
            get { return _incubatorsUsed; }
            set { Set(ref _incubatorsUsed, value); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="PokedexService"/>. 
        /// </summary>
        /// <param name="apiClient">The <see cref="IPokemonGoApiClient"/> instance to use for any Pokemon Go API requests.</param>

        public HatcheryService(IPokemonGoApiClient apiClient) : base(apiClient)
        {
            Eggs = new ObservableCollectionPlus<PokemonData>();
            IncubatorsFree = new ObservableCollectionPlus<EggIncubator>();
            IncubatorsUsed = new ObservableCollectionPlus<EggIncubator>();
        }

        #endregion


    }

}