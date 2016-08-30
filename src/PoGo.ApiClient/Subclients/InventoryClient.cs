using PoGo.ApiClient.Interfaces;
using POGOProtos.Inventory.Item;
using POGOProtos.Networking.Requests;
using POGOProtos.Networking.Requests.Messages;

namespace PoGo.ApiClient.Rpc
{

    /// <summary>
    /// 
    /// </summary>
    public class InventoryClient : ClientBase, IInventoryClient
    {

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public InventoryClient(PokemonGoApiClient client) : base(client)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        public bool QueueTransferPokemonRequest(ulong pokemonId)
        {
            var message = new ReleasePokemonMessage
            {
                PokemonId = pokemonId
            };

            return Client.QueueRequest(RequestType.ReleasePokemon, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        public bool QueueEvolvePokemonRequest(ulong pokemonId)
        {
            var message = new EvolvePokemonMessage
            {
                PokemonId = pokemonId
            };

            return Client.QueueRequest(RequestType.EvolvePokemon, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        public bool QueueUpgradePokemonRequest(ulong pokemonId)
        {
            var message = new UpgradePokemonMessage
            {
                PokemonId = pokemonId
            };

            return Client.QueueRequest(RequestType.UpgradePokemon, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool QueueGetInventoryRequest()
        {
            return Client.QueueRequest(RequestType.GetInventory, new GetInventoryMessage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool QueueRecycleItemRequest(ItemId itemId, int amount)
        {
            var message = new RecycleInventoryItemMessage
            {
                ItemId = itemId,
                Count = amount
            };

            return Client.QueueRequest(RequestType.RecycleInventoryItem, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool QueueUseItemXpBoostRequest()
        {
            var message = new UseItemXpBoostMessage
            {
                ItemId = ItemId.ItemLuckyEgg
            };

            return Client.QueueRequest(RequestType.UseItemXpBoost, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        public bool QueueUseItemEggIncubatorRequest(string itemId, ulong pokemonId)
        {
            var message = new UseItemEggIncubatorMessage
            {
                ItemId = itemId,
                PokemonId = pokemonId
            };

            return Client.QueueRequest(RequestType.UseItemEggIncubator, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool QueueGetHatchedEggRequest()
        {
            return Client.QueueRequest(RequestType.GetHatchedEggs, new GetHatchedEggsMessage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        public bool QueueUseItemPotionRequest(ItemId itemId, ulong pokemonId)
        {
            var message = new UseItemPotionMessage
            {
                ItemId = itemId,
                PokemonId = pokemonId
            };

            return Client.QueueRequest(RequestType.UseItemPotion, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        public bool QueueUseItemReviveRequest(ItemId itemId, ulong pokemonId)
        {
            var message = new UseItemReviveMessage
            {
                ItemId = itemId,
                PokemonId = pokemonId
            };

            return Client.QueueRequest(RequestType.UseItemEggIncubator, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="incenseType"></param>
        /// <returns></returns>
        public bool QueueUseIncenseRequest(ItemId incenseType)
        {
            var message = new UseIncenseMessage
            {
                IncenseType = incenseType
            };

            return Client.QueueRequest(RequestType.UseIncense, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gymId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public bool QueueUseItemInGymRequest(string gymId, ItemId itemId)
        {
            var message = new UseItemGymMessage
            {
                ItemId = itemId,
                GymId = gymId,
                PlayerLatitude = Client.CurrentPosition.Latitude,
                PlayerLongitude = Client.CurrentPosition.Longitude
            };

            return Client.QueueRequest(RequestType.UseItemGym, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pokemonId"></param>
        /// <param name="nickName"></param>
        /// <returns></returns>
        public bool QueueNicknamePokemonRequest(ulong pokemonId, string nickName)
        {
            var message = new NicknamePokemonMessage
            {
                PokemonId = pokemonId,
                Nickname = nickName
            };

            return Client.QueueRequest(RequestType.NicknamePokemon, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pokemonId"></param>
        /// <param name="isFavorite"></param>
        /// <returns></returns>
        public bool QueueSetFavoritePokemonRequest(long pokemonId, bool isFavorite)
        {
            var message = new SetFavoritePokemonMessage
            {
                PokemonId = pokemonId,
                IsFavorite = isFavorite
            };

            return Client.QueueRequest(RequestType.SetFavoritePokemon, message);
        }

        #endregion

    }

}