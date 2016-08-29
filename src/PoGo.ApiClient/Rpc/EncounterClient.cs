using PoGo.ApiClient.Interfaces;
using POGOProtos.Enums;
using POGOProtos.Inventory.Item;
using POGOProtos.Networking.Requests;
using POGOProtos.Networking.Requests.Messages;

namespace PoGo.ApiClient.Rpc
{

    /// <summary>
    /// 
    /// </summary>
    public class EncounterClient : BaseRpc, IEncounter
    {

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public EncounterClient(PokemonGoApiClient client) : base(client)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encounterId"></param>
        /// <param name="spawnPointGuid"></param>
        /// <returns></returns>
        public bool QueueEncounterPokemonRequest(ulong encounterId, string spawnPointGuid)
        {
            var message = new EncounterMessage
            {
                EncounterId = encounterId,
                SpawnPointId = spawnPointGuid,
                PlayerLatitude = Client.CurrentLatitude,
                PlayerLongitude = Client.CurrentLongitude
            };

            return Client.QueueRequest(RequestType.Encounter, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encounterId"></param>
        /// <param name="itemId"></param>
        /// <param name="spawnPointId"></param>
        /// <returns></returns>
        public bool QueueUseCaptureItemRequest(ulong encounterId, ItemId itemId, string spawnPointId)
        {
            var message = new UseItemCaptureMessage
            {
                EncounterId = encounterId,
                ItemId = itemId,
                SpawnPointId = spawnPointId
            };

            return Client.QueueRequest(RequestType.UseItemCapture, message);
        }

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
        public bool QueueCatchPokemonRequest(ulong encounterId, string spawnPointGuid, ItemId pokeballItemId, double normalizedRecticleSize = 1.950, 
            double spinModifier = 1, double normalizedHitPos = 1, bool hitPokemon = true)
        {
            var message = new CatchPokemonMessage
            {
                EncounterId = encounterId,
                Pokeball = pokeballItemId,
                SpawnPointId = spawnPointGuid,
                HitPokemon = hitPokemon,
                NormalizedReticleSize = normalizedRecticleSize,
                SpinModifier = spinModifier,
                NormalizedHitPosition = normalizedHitPos
            };

            return Client.QueueRequest(RequestType.CatchPokemon, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encounterId"></param>
        /// <param name="encounterLocation"></param>
        /// <returns></returns>
        public bool QueueEncounterIncensePokemonRequest(ulong encounterId, string encounterLocation)
        {
            var message = new IncenseEncounterMessage
            {
                EncounterId = encounterId,
                EncounterLocation = encounterLocation
            };

            return Client.QueueRequest(RequestType.IncenseEncounter, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encounterId"></param>
        /// <param name="fortId"></param>
        /// <returns></returns>
        public bool QueueEncounterLuredPokemonRequest(ulong encounterId, string fortId)
        {
            var message = new DiskEncounterMessage
            {
                EncounterId = encounterId,
                FortId = fortId,
                PlayerLatitude = Client.CurrentLatitude,
                PlayerLongitude = Client.CurrentLongitude
            };

            return Client.QueueRequest(RequestType.DiskEncounter, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        public bool QueueEncounterTutorialCompleteRequest(PokemonId pokemonId)
        {
            var message = new EncounterTutorialCompleteMessage
            {
                PokemonId = pokemonId
            };

            return Client.QueueRequest(RequestType.EncounterTutorialComplete, message);
        }

        #endregion

    }

}