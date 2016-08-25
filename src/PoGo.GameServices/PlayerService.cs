using PoGo.ApiClient.Interfaces;
using POGOProtos.Data.Player;
using POGOProtos.Inventory;

namespace PoGo.GameServices
{

    /// <summary>
    /// Manages the game logic for dealing with the player, including Achievements, Stats, and Level Rewards.
    /// </summary>
    public class PlayerService : GameServiceBase
    {

        #region Private Members

        private InventoryDelta _levelUpRewards;
        private PlayerService _profile;
        private PlayerStats _stats;

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public InventoryDelta LevelUpRewards
        {
            get { return _levelUpRewards; }
            set { Set(ref _levelUpRewards, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public PlayerService Profile
        {
            get { return _profile; }
            set { Set(ref _profile, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public PlayerStats Stats
        {
            get { return _stats; }
            set { Set(ref _stats, value); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="PokedexService"/>. 
        /// </summary>
        /// <param name="apiClient">The <see cref="IPokemonGoApiClient"/> instance to use for any Pokemon Go API requests.</param>

        public PlayerService(IPokemonGoApiClient apiClient) : base(apiClient)
        {
            LevelUpRewards = default(InventoryDelta);
            Profile = default(PlayerService);
            Stats = default(PlayerStats);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public override void ResetState()
        {
            LevelUpRewards = null;
            Profile = null;
            Stats = null;
        }

        #endregion

    }

}