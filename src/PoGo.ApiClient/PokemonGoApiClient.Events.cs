using PoGo.ApiClient.Authentication;
using POGOProtos.Inventory;
using System;

namespace PoGo.ApiClient
{
    public partial class PokemonGoApiClient
    {

        #region Events

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public event EventHandler<AuthenticatedUser> AuthenticatedUserUpdated;

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
        public void RaiseAuthenticatedUserUpdated(AuthenticatedUser value) => AuthenticatedUserUpdated?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseInventoryDeltaReceived(InventoryDelta value) => InventoryDeltaReceived?.Invoke(this, value);

        #endregion

    }

}