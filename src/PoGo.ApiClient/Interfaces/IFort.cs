using POGOProtos.Data.Battle;
using POGOProtos.Inventory.Item;
using System.Collections.Generic;

namespace PoGo.ApiClient.Interfaces
{

    /// <summary>
    /// 
    /// </summary>
    public interface IFort
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fortId"></param>
        /// <param name="fortLatitude"></param>
        /// <param name="fortLongitude"></param>
        /// <returns></returns>
        bool QueueGetFortRequest(string fortId, double fortLatitude, double fortLongitude);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fortId"></param>
        /// <param name="fortLat"></param>
        /// <param name="fortLng"></param>
        /// <returns></returns>
        bool QueueSearchFortRequest(string fortId, double fortLat, double fortLng);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fortId"></param>
        /// <param name="modifierType"></param>
        /// <returns></returns>
        bool QueueAddFortModifierRequest(string fortId, ItemId modifierType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fortId"></param>
        /// <param name="battleId"></param>
        /// <param name="battleActions"></param>
        /// <param name="lastRetrievedAction"></param>
        /// <returns></returns>
        bool QueueAttackGymRequest(string fortId, string battleId, List<BattleAction> battleActions, BattleAction lastRetrievedAction);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fortId"></param>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        bool QueueFortDeployPokemonRequest(string fortId, ulong pokemonId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fortId"></param>
        /// <param name="pokemonId"></param>
        /// <returns></returns>
        bool QueueFortRecallPokemonRequest(string fortId, ulong pokemonId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gymId"></param>
        /// <param name="gymLat"></param>
        /// <param name="gymLng"></param>
        /// <returns></returns>
        bool QueueGetGymDetailsRequest(string gymId, double gymLat, double gymLng);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gymId"></param>
        /// <param name="defendingPokemonId"></param>
        /// <param name="attackingPokemonIds"></param>
        /// <returns></returns>
        bool QueueStartGymBattleRequest(string gymId, ulong defendingPokemonId, IEnumerable<ulong> attackingPokemonIds);

    }

}