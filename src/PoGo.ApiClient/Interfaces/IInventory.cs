using System.Threading.Tasks;
using POGOProtos.Inventory.Item;
using POGOProtos.Networking.Responses;

namespace PoGo.ApiClient.Interfaces
{
    public interface IInventory
    {
        Task<ReleasePokemonResponse> TransferPokemon(ulong pokemonId);
        Task<EvolvePokemonResponse> EvolvePokemon(ulong pokemonId);
        Task<UpgradePokemonResponse> UpgradePokemon(ulong pokemonId);
        Task<GetInventoryResponse> GetInventory();
        Task<RecycleInventoryItemResponse> RecycleItem(ItemId itemId, int amount);
        Task<UseItemXpBoostResponse> UseItemXpBoost();
        Task<UseItemEggIncubatorResponse> UseItemEggIncubator(string itemId, ulong pokemonId);
        Task<GetHatchedEggsResponse> GetHatchedEgg();
        Task<UseItemPotionResponse> UseItemPotion(ItemId itemId, ulong pokemonId);
        Task<UseItemEggIncubatorResponse> UseItemRevive(ItemId itemId, ulong pokemonId);
        Task<UseIncenseResponse> UseIncense(ItemId incenseType);
        Task<UseItemGymResponse> UseItemInGym(string gymId, ItemId itemId);
        Task<NicknamePokemonResponse> NicknamePokemon(ulong pokemonId, string nickName);
        Task<SetFavoritePokemonResponse> SetFavoritePokemon(long pokemonId, bool isFavorite);
    }
}