using PoGo.ApiClient.Interfaces;
using PoGo.GameServices.Player;
using POGOProtos.Data;
using POGOProtos.Data.Player;
using POGOProtos.Inventory.Item;
using POGOProtos.Networking.Responses;
using System.Collections.Generic;

namespace PoGo.GameServices
{

    /// <summary>
    /// Manages the game logic for dealing with the player, including Achievements, Stats, and Level Rewards.
    /// </summary>
    public class PlayerService : GameServiceBase
    {

        #region Private Members

        private LevelUpRewards _levelUpRewards;
        private PlayerData _profile;
        private PlayerStats _stats;

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public LevelUpRewards LevelUpRewards
        {
            get { return _levelUpRewards; }
            set { Set(ref _levelUpRewards, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public PlayerData Profile
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
            LevelUpRewards = default(LevelUpRewards);
            Profile = default(PlayerData);
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

        /// <summary>
        /// 
        /// </summary>
        public override void RegisterClientEvents()
        {
            ApiClient.CheckCodenameAvailableReceived += CheckCodenameAvailableReceived;
            ApiClient.ClaimCodenameReceived += ClaimCodenameReceived;
            ApiClient.CollectDailyBonusReceived += CollectDailyBonusReceived;
            ApiClient.CollectDailyDefenderBonusReceived += CollectDailyDefenderBonusReceived;
            ApiClient.EquipBadgeReceived += EquipBadgeReceived;
            ApiClient.PlayerReceived += PlayerReceived;
            ApiClient.PlayerProfileReceived += PlayerProfileReceived;
            ApiClient.CheckAwardedBadgesReceived += CheckAwardedBadgesReceived;
            ApiClient.LevelUpRewardsReceived += LevelUpRewardsReceived;
            ApiClient.SuggestedCodenamesReceived += SuggestedCodenamesReceived;
            ApiClient.MarkTutorialCompleteReceived += MarkTutorialCompleteReceived;
            ApiClient.AvatarReceived += AvatarReceived;
            ApiClient.ContactSettingsReceived += ContactSettingsReceived;
            ApiClient.PlayerTeamReceived += PlayerTeamReceived;
            ApiClient.PlayerUpdateReceived += PlayerUpdateReceived;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void UnregisterClientEvents()
        {
            ApiClient.CheckCodenameAvailableReceived -= CheckCodenameAvailableReceived;
            ApiClient.ClaimCodenameReceived -= ClaimCodenameReceived;
            ApiClient.CollectDailyBonusReceived -= CollectDailyBonusReceived;
            ApiClient.CollectDailyDefenderBonusReceived -= CollectDailyDefenderBonusReceived;
            ApiClient.EquipBadgeReceived -= EquipBadgeReceived;
            ApiClient.PlayerReceived -= PlayerReceived;
            ApiClient.PlayerProfileReceived -= PlayerProfileReceived;
            ApiClient.CheckAwardedBadgesReceived -= CheckAwardedBadgesReceived;
            ApiClient.LevelUpRewardsReceived -= LevelUpRewardsReceived;
            ApiClient.SuggestedCodenamesReceived -= SuggestedCodenamesReceived;
            ApiClient.MarkTutorialCompleteReceived -= MarkTutorialCompleteReceived;
            ApiClient.AvatarReceived -= AvatarReceived;
            ApiClient.ContactSettingsReceived -= ContactSettingsReceived;
            ApiClient.PlayerTeamReceived -= PlayerTeamReceived;
            ApiClient.PlayerUpdateReceived -= PlayerUpdateReceived;
        }

        #endregion

        #region Event Handlers

        private void CheckCodenameAvailableReceived(object sender, CheckCodenameAvailableResponse e)
        {
            throw new System.NotImplementedException();
        }

        private void ClaimCodenameReceived(object sender, ClaimCodenameResponse e)
        {
            throw new System.NotImplementedException();
        }

        private void CollectDailyBonusReceived(object sender, CollectDailyBonusResponse e)
        {
            throw new System.NotImplementedException();
        }

        private void CollectDailyDefenderBonusReceived(object sender, CollectDailyDefenderBonusResponse e)
        {
            throw new System.NotImplementedException();
        }

        private void EquipBadgeReceived(object sender, EquipBadgeResponse e)
        {
            throw new System.NotImplementedException();
        }

        private void PlayerReceived(object sender, GetPlayerResponse e)
        {
            if (e.Success && e.PlayerData != null)
            {
                Profile = e.PlayerData;
                //ApiClient.Download.QueueDownloadRemoteConfigVersionRequest();
                //ApiClient.Download.QueueGetAssetDigestRequest();
                //ApiClient.Player.QueueGetLevelUpRewardsRequest();
            }
        }

        private void PlayerProfileReceived(object sender, GetPlayerProfileResponse e)
        {
            if (e.Result == GetPlayerProfileResponse.Types.Result.Success)
            {
                throw new System.NotImplementedException();
            }
        }

        private void CheckAwardedBadgesReceived(object sender, CheckAwardedBadgesResponse e)
        {
            throw new System.NotImplementedException();
        }

        private void LevelUpRewardsReceived(object sender, LevelUpRewardsResponse e)
        {
            if (e.Result == LevelUpRewardsResponse.Types.Result.Success && e.CalculateSize() > 0)
            {
                LevelUpRewards = new LevelUpRewards(new List<ItemAward>(e.ItemsAwarded), new List<ItemId>(e.ItemsUnlocked));
            }
        }

        private void SuggestedCodenamesReceived(object sender, GetSuggestedCodenamesResponse e)
        {
            throw new System.NotImplementedException();
        }

        private void MarkTutorialCompleteReceived(object sender, MarkTutorialCompleteResponse e)
        {
            throw new System.NotImplementedException();
        }

        private void AvatarReceived(object sender, SetAvatarResponse e)
        {
            throw new System.NotImplementedException();
        }

        private void ContactSettingsReceived(object sender, SetContactSettingsResponse e)
        {
            throw new System.NotImplementedException();
        }

        private void PlayerTeamReceived(object sender, SetPlayerTeamResponse e)
        {
            throw new System.NotImplementedException();
        }

        private void PlayerUpdateReceived(object sender, PlayerUpdateResponse e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

    }

}