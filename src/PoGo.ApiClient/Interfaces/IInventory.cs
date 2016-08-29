using System.Threading.Tasks;
using POGOProtos.Inventory.Item;
using POGOProtos.Networking.Responses;

namespace PoGo.ApiClient.Interfaces
{

    /// <summary>
    /// 
    /// </summary>
    public interface IInventory
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        bool QueueTransferPokemonRequest(ulong pokemonId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        bool QueueEvolvePokemonRequest(ulong pokemonId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        bool QueueUpgradePokemonRequest(ulong pokemonId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool QueueGetInventoryRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        bool QueueRecycleItemRequest(ItemId itemId, int amount);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool QueueUseItemXpBoostRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        bool QueueUseItemEggIncubatorRequest(string itemId, ulong pokemonId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool QueueGetHatchedEggRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        bool QueueUseItemPotionRequest(ItemId itemId, ulong pokemonId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        bool QueueUseItemReviveRequest(ItemId itemId, ulong pokemonId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="incenseType"></param>
        /// <returns></returns>
        bool QueueUseIncenseRequest(ItemId incenseType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gymId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        bool QueueUseItemInGymRequest(string gymId, ItemId itemId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pokemonId"></param>
        /// <param name="nickName"></param>
        /// <returns></returns>
        bool QueueNicknamePokemonRequest(ulong pokemonId, string nickName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pokemonId"></param>
        /// <param name="isFavorite"></param>
        /// <returns></returns>
        bool QueueSetFavoritePokemonRequest(long pokemonId, bool isFavorite);

    }

}