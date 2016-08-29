using PoGo.ApiClient.Session;
using POGOProtos.Inventory;
using POGOProtos.Networking.Envelopes;
using POGOProtos.Networking.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoGo.ApiClient
{
    public partial class PokemonGoApiClient
    {

        #region Events

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public event EventHandler<AccessToken> AccessTokenUpdated;

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public event EventHandler<CheckAwardedBadgesResponse> AwardedBadgesReceived;

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public event EventHandler<GetHatchedEggsResponse> HatchedEggsReceived;


        /// <summary>
        /// 
        /// </summary>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public event EventHandler<InventoryDelta> InventoryDeltaReceived;

        #endregion

        #region RaiseEvents

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        void RaiseAccessTokenUpdated(AccessToken value) => AccessTokenUpdated?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        void RaiseAwardedBadgesReceived(CheckAwardedBadgesResponse value) => AwardedBadgesReceived?.Invoke(this, value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        void RaiseHatchedEggsReceived(GetHatchedEggsResponse value) => HatchedEggsReceived?.Invoke(this, value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        void RaiseInventoryDeltaReceived(InventoryDelta value) => InventoryDeltaReceived?.Invoke(this, value);

        #endregion

    }

}