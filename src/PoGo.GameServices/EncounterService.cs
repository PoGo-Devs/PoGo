using PoGo.ApiClient.Interfaces;
using POGOProtos.Inventory.Item;
using System.Collections.ObjectModel;

namespace PoGo.GameServices
{

    /// <summary>
    /// Manages all of the game logic for catching a Pokemon, including available items.
    /// </summary>
    public class EncounterService : GameServiceBase
    {

        #region Private Members

        ObservableCollectionPlus<ItemData> _usableItems;

        #endregion

        #region Properties

        /// <summary>
        /// The items that can be used in the current encounter.
        /// </summary>
        public ObservableCollectionPlus<ItemData> UsableItems
        {
            get { return _usableItems; }
            set { Set(ref _usableItems, value); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiClient"></param>
        public EncounterService(IPokemonGoApiClient apiClient) : base(apiClient)
        {
            _usableItems = new ObservableCollectionPlus<ItemData>();
        }

        #endregion

    }

}