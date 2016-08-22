using System.Threading.Tasks;
using POGOProtos.Enums;
using POGOProtos.Inventory.Item;
using POGOProtos.Networking.Responses;

namespace PoGo.ApiClient.Interfaces
{
    public interface IEncounter
    {
        Task<EncounterResponse> EncounterPokemon(ulong encounterId, string spawnPointGuid);
        Task<UseItemCaptureResponse> UseCaptureItem(ulong encounterId, ItemId itemId, string spawnPointId);

        Task<CatchPokemonResponse> CatchPokemon(ulong encounterId, string spawnPointGuid,
            ItemId pokeballItemId, double normalizedRecticleSize = 1.950, double spinModifier = 1,
            double normalizedHitPos = 1, bool hitPokemon = true);

        Task<IncenseEncounterResponse> EncounterIncensePokemon(ulong encounterId, string encounterLocation);
        Task<DiskEncounterResponse> EncounterLurePokemon(ulong encounterId, string fortId);
        Task<EncounterTutorialCompleteResponse> EncounterTutorialComplete(PokemonId pokemonId);
    }
}