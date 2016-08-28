using System.Collections.Generic;
using System.Threading.Tasks;
using POGOProtos.Data.Battle;
using POGOProtos.Inventory.Item;
using POGOProtos.Networking.Responses;

namespace PoGo.ApiClient.Interfaces
{
    public interface IFort
    {
        Task<FortDetailsResponse> GetFort(string fortId, double fortLatitude, double fortLongitude);
        Task<FortSearchResponse> SearchFort(string fortId, double fortLat, double fortLng);
        Task<AddFortModifierResponse> AddFortModifier(string fortId, ItemId modifierType);

        Task<AttackGymResponse> AttackGym(string fortId, string battleId, List<BattleAction> battleActions,
            BattleAction lastRetrievedAction);

        Task<FortDeployPokemonResponse> FortDeployPokemon(string fortId, ulong pokemonId);
        Task<FortRecallPokemonResponse> FortRecallPokemon(string fortId, ulong pokemonId);
        Task<GetGymDetailsResponse> GetGymDetails(string gymId, double gymLat, double gymLng);

        Task<StartGymBattleResponse> StartGymBattle(string gymId, ulong defendingPokemonId,
            IEnumerable<ulong> attackingPokemonIds);
    }
}