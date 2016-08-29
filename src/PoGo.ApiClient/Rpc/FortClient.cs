using PoGo.ApiClient.Interfaces;
using POGOProtos.Data.Battle;
using POGOProtos.Inventory.Item;
using POGOProtos.Networking.Requests;
using POGOProtos.Networking.Requests.Messages;
using System.Collections.Generic;

namespace PoGo.ApiClient.Rpc
{

    /// <summary>
    /// 
    /// </summary>
    public class FortClient : BaseRpc, IFort
    {

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public FortClient(PokemonGoApiClient client) : base(client)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fortId"></param>
        /// <param name="fortLatitude"></param>
        /// <param name="fortLongitude"></param>
        /// <returns></returns>
        public bool QueueGetFortRequest(string fortId, double fortLatitude, double fortLongitude)
        {
            var message = new FortDetailsMessage
            {
                FortId = fortId,
                Latitude = fortLatitude,
                Longitude = fortLongitude
            };

            return Client.QueueRequest(RequestType.FortDetails, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fortId"></param>
        /// <param name="fortLat"></param>
        /// <param name="fortLng"></param>
        /// <returns></returns>
        public bool QueueSearchFortRequest(string fortId, double fortLat, double fortLng)
        {
            var message = new FortSearchMessage
            {
                FortId = fortId,
                FortLatitude = fortLat,
                FortLongitude = fortLng,
                PlayerLatitude = Client.CurrentLatitude,
                PlayerLongitude = Client.CurrentLongitude
            };

            return Client.QueueRequest(RequestType.FortSearch, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fortId"></param>
        /// <param name="modifierType"></param>
        /// <returns></returns>
        public bool QueueAddFortModifierRequest(string fortId, ItemId modifierType)
        {
            var message = new AddFortModifierMessage
            {
                FortId = fortId,
                ModifierType = modifierType,
                PlayerLatitude = Client.CurrentLatitude,
                PlayerLongitude = Client.CurrentLongitude
            };

            return Client.QueueRequest(RequestType.AddFortModifier, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fortId"></param>
        /// <param name="battleId"></param>
        /// <param name="battleActions"></param>
        /// <param name="lastRetrievedAction"></param>
        /// <returns></returns>
        public bool QueueAttackGymRequest(string fortId, string battleId, List<BattleAction> battleActions, BattleAction lastRetrievedAction)
        {
            var message = new AttackGymMessage
            {
                BattleId = battleId,
                GymId = fortId,
                LastRetrievedActions = lastRetrievedAction,
                PlayerLatitude = Client.CurrentLatitude,
                PlayerLongitude = Client.CurrentLongitude,
                AttackActions = {battleActions}
            };

            message.AttackActions.AddRange(battleActions);

            return Client.QueueRequest(RequestType.AttackGym, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fortId"></param>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        public bool QueueFortDeployPokemonRequest(string fortId, ulong pokemonId)
        {
            var message = new FortDeployPokemonMessage
            {
                PokemonId = pokemonId,
                FortId = fortId,
                PlayerLatitude = Client.CurrentLatitude,
                PlayerLongitude = Client.CurrentLongitude
            };

            return Client.QueueRequest(RequestType.FortDeployPokemon, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fortId"></param>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        public bool QueueFortRecallPokemonRequest(string fortId, ulong pokemonId)
        {
            var message = new FortRecallPokemonMessage
            {
                PokemonId = pokemonId,
                FortId = fortId,
                PlayerLatitude = Client.CurrentLatitude,
                PlayerLongitude = Client.CurrentLongitude
            };

            return Client.QueueRequest(RequestType.FortRecallPokemon, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gymId"></param>
        /// <param name="gymLat"></param>
        /// <param name="gymLng"></param>
        /// <returns></returns>
        public bool QueueGetGymDetailsRequest(string gymId, double gymLat, double gymLng)
        {
            var message = new GetGymDetailsMessage
            {
                GymId = gymId,
                GymLatitude = gymLat,
                GymLongitude = gymLng,
                PlayerLatitude = Client.CurrentLatitude,
                PlayerLongitude = Client.CurrentLongitude
            };

            return Client.QueueRequest(RequestType.GetGymDetails, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gymId"></param>
        /// <param name="defendingPokemonId"></param>
        /// <param name="attackingPokemonIds"></param>
        /// <returns></returns>
        public bool QueueStartGymBattleRequest(string gymId, ulong defendingPokemonId, IEnumerable<ulong> attackingPokemonIds)
        {
            var message = new StartGymBattleMessage
            {
                GymId = gymId,
                DefendingPokemonId = defendingPokemonId,
                AttackingPokemonIds = {attackingPokemonIds},
                PlayerLatitude = Client.CurrentLatitude,
                PlayerLongitude = Client.CurrentLongitude
            };

            return Client.QueueRequest(RequestType.StartGymBattle, message);
        }

        #endregion

    }

}