using PoGo.ApiClient.Interfaces;
using POGOProtos.Inventory.Item;
using System.Collections.Generic;
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

        /// <summary>
        ///     List of items that can be used when trying to catch a Pokemon
        /// </summary>
        private static readonly List<ItemId> UsableItemIds = new List<ItemId>
        {
            ItemId.ItemPokeBall,
            ItemId.ItemGreatBall,
            ItemId.ItemBlukBerry,
            ItemId.ItemMasterBall,
            ItemId.ItemNanabBerry,
            ItemId.ItemPinapBerry,
            ItemId.ItemRazzBerry,
            ItemId.ItemUltraBall,
            ItemId.ItemWeparBerry
        };

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

        #region Public Members



        #endregion

    }

}