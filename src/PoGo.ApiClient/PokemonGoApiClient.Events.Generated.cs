using PoGo.ApiClient.Authentication;
using POGOProtos.Inventory;
using POGOProtos.Networking.Responses;
using System;

namespace PoGo.ApiClient
{
    public partial class PokemonGoApiClient
    {

        #region Events

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<AddFortModifierResponse> AddFortModifierReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<AttackGymResponse> AttackGymReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<CatchPokemonResponse> CatchPokemonReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<CheckAwardedBadgesResponse> CheckAwardedBadgesReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<CheckChallengeResponse> CheckChallengeReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<CheckCodenameAvailableResponse> CheckCodenameAvailableReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<ClaimCodenameResponse> ClaimCodenameReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<CollectDailyBonusResponse> CollectDailyBonusReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<CollectDailyDefenderBonusResponse> CollectDailyDefenderBonusReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<DiskEncounterResponse> DiskEncounterReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<DownloadItemTemplatesResponse> DownloadItemTemplatesReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<DownloadRemoteConfigVersionResponse> DownloadRemoteConfigVersionReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<DownloadSettingsResponse> DownloadSettingsReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<EchoResponse> EchoReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<EncounterResponse> EncounterReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<EncounterTutorialCompleteResponse> EncounterTutorialCompleteReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<EquipBadgeResponse> EquipBadgeReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<EvolvePokemonResponse> EvolvePokemonReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<FortDeployPokemonResponse> FortDeployPokemonReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<FortDetailsResponse> FortDetailsReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<FortRecallPokemonResponse> FortRecallPokemonReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<FortSearchResponse> FortSearchReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<GetAssetDigestResponse> AssetDigestReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<GetBuddyWalkedResponse> BuddyWalkedReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<GetDownloadUrlsResponse> DownloadUrlsReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<GetGymDetailsResponse> GymDetailsReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<GetHatchedEggsResponse> HatchedEggsReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<GetIncensePokemonResponse> IncensePokemonReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<GetInventoryResponse> InventoryReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<GetMapObjectsResponse> MapObjectsReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<GetPlayerProfileResponse> PlayerProfileReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<GetPlayerResponse> PlayerReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<GetSuggestedCodenamesResponse> SuggestedCodenamesReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<IncenseEncounterResponse> IncenseEncounterReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<LevelUpRewardsResponse> LevelUpRewardsReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<MarkTutorialCompleteResponse> MarkTutorialCompleteReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<NicknamePokemonResponse> NicknamePokemonReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<PlayerUpdateResponse> PlayerUpdateReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<RecycleInventoryItemResponse> RecycleInventoryItemReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<ReleasePokemonResponse> ReleasePokemonReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<SetAvatarResponse> AvatarReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<SetBuddyPokemonResponse> BuddyPokemonReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<SetContactSettingsResponse> ContactSettingsReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<SetFavoritePokemonResponse> FavoritePokemonReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<SetPlayerTeamResponse> PlayerTeamReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<SfidaActionLogResponse> SfidaActionLogReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<StartGymBattleResponse> StartGymBattleReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<UpgradePokemonResponse> UpgradePokemonReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<UseIncenseResponse> UseIncenseReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<UseItemCaptureResponse> UseItemCaptureReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<UseItemEggIncubatorResponse> UseItemEggIncubatorReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<UseItemGymResponse> UseItemGymReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<UseItemPotionResponse> UseItemPotionReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<UseItemReviveResponse> UseItemReviveReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<UseItemXpBoostResponse> UseItemXpBoostReceived;

		///<summary>
		/// 
		/// </summary>
		public event EventHandler<VerifyChallengeResponse> VerifyChallengeReceived;


		#endregion

		#region Event Raisers


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseAddFortModifierReceived(AddFortModifierResponse value) => AddFortModifierReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseAttackGymReceived(AttackGymResponse value) => AttackGymReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseCatchPokemonReceived(CatchPokemonResponse value) => CatchPokemonReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseCheckAwardedBadgesReceived(CheckAwardedBadgesResponse value) => CheckAwardedBadgesReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseCheckChallengeReceived(CheckChallengeResponse value) => CheckChallengeReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseCheckCodenameAvailableReceived(CheckCodenameAvailableResponse value) => CheckCodenameAvailableReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseClaimCodenameReceived(ClaimCodenameResponse value) => ClaimCodenameReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseCollectDailyBonusReceived(CollectDailyBonusResponse value) => CollectDailyBonusReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseCollectDailyDefenderBonusReceived(CollectDailyDefenderBonusResponse value) => CollectDailyDefenderBonusReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseDiskEncounterReceived(DiskEncounterResponse value) => DiskEncounterReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseDownloadItemTemplatesReceived(DownloadItemTemplatesResponse value) => DownloadItemTemplatesReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseDownloadRemoteConfigVersionReceived(DownloadRemoteConfigVersionResponse value) => DownloadRemoteConfigVersionReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseDownloadSettingsReceived(DownloadSettingsResponse value) => DownloadSettingsReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseEchoReceived(EchoResponse value) => EchoReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseEncounterReceived(EncounterResponse value) => EncounterReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseEncounterTutorialCompleteReceived(EncounterTutorialCompleteResponse value) => EncounterTutorialCompleteReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseEquipBadgeReceived(EquipBadgeResponse value) => EquipBadgeReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseEvolvePokemonReceived(EvolvePokemonResponse value) => EvolvePokemonReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseFortDeployPokemonReceived(FortDeployPokemonResponse value) => FortDeployPokemonReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseFortDetailsReceived(FortDetailsResponse value) => FortDetailsReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseFortRecallPokemonReceived(FortRecallPokemonResponse value) => FortRecallPokemonReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseFortSearchReceived(FortSearchResponse value) => FortSearchReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseAssetDigestReceived(GetAssetDigestResponse value) => AssetDigestReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseBuddyWalkedReceived(GetBuddyWalkedResponse value) => BuddyWalkedReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseDownloadUrlsReceived(GetDownloadUrlsResponse value) => DownloadUrlsReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseGymDetailsReceived(GetGymDetailsResponse value) => GymDetailsReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseHatchedEggsReceived(GetHatchedEggsResponse value) => HatchedEggsReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseIncensePokemonReceived(GetIncensePokemonResponse value) => IncensePokemonReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseInventoryReceived(GetInventoryResponse value) => InventoryReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseMapObjectsReceived(GetMapObjectsResponse value) => MapObjectsReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaisePlayerProfileReceived(GetPlayerProfileResponse value) => PlayerProfileReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaisePlayerReceived(GetPlayerResponse value) => PlayerReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseSuggestedCodenamesReceived(GetSuggestedCodenamesResponse value) => SuggestedCodenamesReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseIncenseEncounterReceived(IncenseEncounterResponse value) => IncenseEncounterReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseLevelUpRewardsReceived(LevelUpRewardsResponse value) => LevelUpRewardsReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseMarkTutorialCompleteReceived(MarkTutorialCompleteResponse value) => MarkTutorialCompleteReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseNicknamePokemonReceived(NicknamePokemonResponse value) => NicknamePokemonReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaisePlayerUpdateReceived(PlayerUpdateResponse value) => PlayerUpdateReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseRecycleInventoryItemReceived(RecycleInventoryItemResponse value) => RecycleInventoryItemReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseReleasePokemonReceived(ReleasePokemonResponse value) => ReleasePokemonReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseAvatarReceived(SetAvatarResponse value) => AvatarReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseBuddyPokemonReceived(SetBuddyPokemonResponse value) => BuddyPokemonReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseContactSettingsReceived(SetContactSettingsResponse value) => ContactSettingsReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseFavoritePokemonReceived(SetFavoritePokemonResponse value) => FavoritePokemonReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaisePlayerTeamReceived(SetPlayerTeamResponse value) => PlayerTeamReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseSfidaActionLogReceived(SfidaActionLogResponse value) => SfidaActionLogReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseStartGymBattleReceived(StartGymBattleResponse value) => StartGymBattleReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseUpgradePokemonReceived(UpgradePokemonResponse value) => UpgradePokemonReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseUseIncenseReceived(UseIncenseResponse value) => UseIncenseReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseUseItemCaptureReceived(UseItemCaptureResponse value) => UseItemCaptureReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseUseItemEggIncubatorReceived(UseItemEggIncubatorResponse value) => UseItemEggIncubatorReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseUseItemGymReceived(UseItemGymResponse value) => UseItemGymReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseUseItemPotionReceived(UseItemPotionResponse value) => UseItemPotionReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseUseItemReviveReceived(UseItemReviveResponse value) => UseItemReviveReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseUseItemXpBoostReceived(UseItemXpBoostResponse value) => UseItemXpBoostReceived?.Invoke(this, value);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>These might not stay here, we'll see how the pattern plays out.</remarks>
        public void RaiseVerifyChallengeReceived(VerifyChallengeResponse value) => VerifyChallengeReceived?.Invoke(this, value);


		#endregion

	}

}