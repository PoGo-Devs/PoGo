using POGOProtos.Enums;
using POGOProtos.Inventory.Item;

namespace PoGo.ApiClient.Interfaces
{

    /// <summary>
    /// 
    /// </summary>
    public interface IEncounter
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encounterId"></param>
        /// <param name="spawnPointGuid"></param>
        /// <returns></returns>
        bool QueueEncounterPokemonRequest(ulong encounterId, string spawnPointGuid);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encounterId"></param>
        /// <param name="itemId"></param>
        /// <param name="spawnPointId"></param>
        /// <returns></returns>
        bool QueueUseCaptureItemRequest(ulong encounterId, ItemId itemId, string spawnPointId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encounterId"></param>
        /// <param name="spawnPointGuid"></param>
        /// <param name="pokeballItemId"></param>
        /// <param name="normalizedRecticleSize"></param>
        /// <param name="spinModifier"></param>
        /// <param name="normalizedHitPos"></param>
        /// <param name="hitPokemon"></param>
        /// <returns></returns>
        bool QueueCatchPokemonRequest(ulong encounterId, string spawnPointGuid, ItemId pokeballItemId, double normalizedRecticleSize = 1.950, 
            double spinModifier = 1, double normalizedHitPos = 1, bool hitPokemon = true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encounterId"></param>
        /// <param name="encounterLocation"></param>
        /// <returns></returns>
        bool QueueEncounterIncensePokemonRequest(ulong encounterId, string encounterLocation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encounterId"></param>
        /// <param name="fortId"></param>
        /// <returns></returns>
        bool QueueEncounterLuredPokemonRequest(ulong encounterId, string fortId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        bool QueueEncounterTutorialCompleteRequest(PokemonId pokemonId);
    }
}