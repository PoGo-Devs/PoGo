using Google.Protobuf;
using POGOProtos.Networking.Responses;
using System;

namespace PoGo.ApiClient
{
    public partial class PokemonGoApiClient
    {

        #region Events

		///<summary>
		/// Fires every time a <see cref="AddFortModifierResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<AddFortModifierResponse> AddFortModifierReceived;

		///<summary>
		/// Fires every time a <see cref="AttackGymResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<AttackGymResponse> AttackGymReceived;

		///<summary>
		/// Fires every time a <see cref="CatchPokemonResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<CatchPokemonResponse> CatchPokemonReceived;

		///<summary>
		/// Fires every time a <see cref="CheckAwardedBadgesResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<CheckAwardedBadgesResponse> CheckAwardedBadgesReceived;

		///<summary>
		/// Fires every time a <see cref="CheckChallengeResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<CheckChallengeResponse> CheckChallengeReceived;

		///<summary>
		/// Fires every time a <see cref="CheckCodenameAvailableResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<CheckCodenameAvailableResponse> CheckCodenameAvailableReceived;

		///<summary>
		/// Fires every time a <see cref="ClaimCodenameResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<ClaimCodenameResponse> ClaimCodenameReceived;

		///<summary>
		/// Fires every time a <see cref="CollectDailyBonusResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<CollectDailyBonusResponse> CollectDailyBonusReceived;

		///<summary>
		/// Fires every time a <see cref="CollectDailyDefenderBonusResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<CollectDailyDefenderBonusResponse> CollectDailyDefenderBonusReceived;

		///<summary>
		/// Fires every time a <see cref="DiskEncounterResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<DiskEncounterResponse> DiskEncounterReceived;

		///<summary>
		/// Fires every time a <see cref="DownloadItemTemplatesResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<DownloadItemTemplatesResponse> DownloadItemTemplatesReceived;

		///<summary>
		/// Fires every time a <see cref="DownloadRemoteConfigVersionResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<DownloadRemoteConfigVersionResponse> DownloadRemoteConfigVersionReceived;

		///<summary>
		/// Fires every time a <see cref="DownloadSettingsResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<DownloadSettingsResponse> DownloadSettingsReceived;

		///<summary>
		/// Fires every time a <see cref="EchoResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<EchoResponse> EchoReceived;

		///<summary>
		/// Fires every time a <see cref="EncounterResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<EncounterResponse> EncounterReceived;

		///<summary>
		/// Fires every time a <see cref="EncounterTutorialCompleteResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<EncounterTutorialCompleteResponse> EncounterTutorialCompleteReceived;

		///<summary>
		/// Fires every time a <see cref="EquipBadgeResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<EquipBadgeResponse> EquipBadgeReceived;

		///<summary>
		/// Fires every time a <see cref="EvolvePokemonResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<EvolvePokemonResponse> EvolvePokemonReceived;

		///<summary>
		/// Fires every time a <see cref="FortDeployPokemonResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<FortDeployPokemonResponse> FortDeployPokemonReceived;

		///<summary>
		/// Fires every time a <see cref="FortDetailsResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<FortDetailsResponse> FortDetailsReceived;

		///<summary>
		/// Fires every time a <see cref="FortRecallPokemonResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<FortRecallPokemonResponse> FortRecallPokemonReceived;

		///<summary>
		/// Fires every time a <see cref="FortSearchResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<FortSearchResponse> FortSearchReceived;

		///<summary>
		/// Fires every time a <see cref="GetAssetDigestResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<GetAssetDigestResponse> AssetDigestReceived;

		///<summary>
		/// Fires every time a <see cref="GetBuddyWalkedResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<GetBuddyWalkedResponse> BuddyWalkedReceived;

		///<summary>
		/// Fires every time a <see cref="GetDownloadUrlsResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<GetDownloadUrlsResponse> DownloadUrlsReceived;

		///<summary>
		/// Fires every time a <see cref="GetGymDetailsResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<GetGymDetailsResponse> GymDetailsReceived;

		///<summary>
		/// Fires every time a <see cref="GetHatchedEggsResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<GetHatchedEggsResponse> HatchedEggsReceived;

		///<summary>
		/// Fires every time a <see cref="GetIncensePokemonResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<GetIncensePokemonResponse> IncensePokemonReceived;

		///<summary>
		/// Fires every time a <see cref="GetInventoryResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<GetInventoryResponse> InventoryReceived;

		///<summary>
		/// Fires every time a <see cref="GetMapObjectsResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<GetMapObjectsResponse> MapObjectsReceived;

		///<summary>
		/// Fires every time a <see cref="GetPlayerProfileResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<GetPlayerProfileResponse> PlayerProfileReceived;

		///<summary>
		/// Fires every time a <see cref="GetPlayerResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<GetPlayerResponse> PlayerReceived;

		///<summary>
		/// Fires every time a <see cref="GetSuggestedCodenamesResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<GetSuggestedCodenamesResponse> SuggestedCodenamesReceived;

		///<summary>
		/// Fires every time a <see cref="IncenseEncounterResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<IncenseEncounterResponse> IncenseEncounterReceived;

		///<summary>
		/// Fires every time a <see cref="LevelUpRewardsResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<LevelUpRewardsResponse> LevelUpRewardsReceived;

		///<summary>
		/// Fires every time a <see cref="MarkTutorialCompleteResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<MarkTutorialCompleteResponse> MarkTutorialCompleteReceived;

		///<summary>
		/// Fires every time a <see cref="NicknamePokemonResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<NicknamePokemonResponse> NicknamePokemonReceived;

		///<summary>
		/// Fires every time a <see cref="PlayerUpdateResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<PlayerUpdateResponse> PlayerUpdateReceived;

		///<summary>
		/// Fires every time a <see cref="RecycleInventoryItemResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<RecycleInventoryItemResponse> RecycleInventoryItemReceived;

		///<summary>
		/// Fires every time a <see cref="ReleasePokemonResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<ReleasePokemonResponse> ReleasePokemonReceived;

		///<summary>
		/// Fires every time a <see cref="SetAvatarResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<SetAvatarResponse> AvatarReceived;

		///<summary>
		/// Fires every time a <see cref="SetBuddyPokemonResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<SetBuddyPokemonResponse> BuddyPokemonReceived;

		///<summary>
		/// Fires every time a <see cref="SetContactSettingsResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<SetContactSettingsResponse> ContactSettingsReceived;

		///<summary>
		/// Fires every time a <see cref="SetFavoritePokemonResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<SetFavoritePokemonResponse> FavoritePokemonReceived;

		///<summary>
		/// Fires every time a <see cref="SetPlayerTeamResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<SetPlayerTeamResponse> PlayerTeamReceived;

		///<summary>
		/// Fires every time a <see cref="SfidaActionLogResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<SfidaActionLogResponse> SfidaActionLogReceived;

		///<summary>
		/// Fires every time a <see cref="StartGymBattleResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<StartGymBattleResponse> StartGymBattleReceived;

		///<summary>
		/// Fires every time a <see cref="UpgradePokemonResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<UpgradePokemonResponse> UpgradePokemonReceived;

		///<summary>
		/// Fires every time a <see cref="UseIncenseResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<UseIncenseResponse> UseIncenseReceived;

		///<summary>
		/// Fires every time a <see cref="UseItemCaptureResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<UseItemCaptureResponse> UseItemCaptureReceived;

		///<summary>
		/// Fires every time a <see cref="UseItemEggIncubatorResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<UseItemEggIncubatorResponse> UseItemEggIncubatorReceived;

		///<summary>
		/// Fires every time a <see cref="UseItemGymResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<UseItemGymResponse> UseItemGymReceived;

		///<summary>
		/// Fires every time a <see cref="UseItemPotionResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<UseItemPotionResponse> UseItemPotionReceived;

		///<summary>
		/// Fires every time a <see cref="UseItemReviveResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<UseItemReviveResponse> UseItemReviveReceived;

		///<summary>
		/// Fires every time a <see cref="UseItemXpBoostResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<UseItemXpBoostResponse> UseItemXpBoostReceived;

		///<summary>
		/// Fires every time a <see cref="VerifyChallengeResponse" /> is received from the API.
		/// </summary>
		public event EventHandler<VerifyChallengeResponse> VerifyChallengeReceived;


		#endregion

		#region Event Raisers


        /// <summary>
        /// Provides a safe way to invoke the <see cref="AddFortModifierReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseAddFortModifierReceived(AddFortModifierResponse value) => AddFortModifierReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="AttackGymReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseAttackGymReceived(AttackGymResponse value) => AttackGymReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="CatchPokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseCatchPokemonReceived(CatchPokemonResponse value) => CatchPokemonReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="CheckAwardedBadgesReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseCheckAwardedBadgesReceived(CheckAwardedBadgesResponse value) => CheckAwardedBadgesReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="CheckChallengeReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseCheckChallengeReceived(CheckChallengeResponse value) => CheckChallengeReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="CheckCodenameAvailableReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseCheckCodenameAvailableReceived(CheckCodenameAvailableResponse value) => CheckCodenameAvailableReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="ClaimCodenameReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseClaimCodenameReceived(ClaimCodenameResponse value) => ClaimCodenameReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="CollectDailyBonusReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseCollectDailyBonusReceived(CollectDailyBonusResponse value) => CollectDailyBonusReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="CollectDailyDefenderBonusReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseCollectDailyDefenderBonusReceived(CollectDailyDefenderBonusResponse value) => CollectDailyDefenderBonusReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="DiskEncounterReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseDiskEncounterReceived(DiskEncounterResponse value) => DiskEncounterReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="DownloadItemTemplatesReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseDownloadItemTemplatesReceived(DownloadItemTemplatesResponse value) => DownloadItemTemplatesReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="DownloadRemoteConfigVersionReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseDownloadRemoteConfigVersionReceived(DownloadRemoteConfigVersionResponse value) => DownloadRemoteConfigVersionReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="DownloadSettingsReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseDownloadSettingsReceived(DownloadSettingsResponse value) => DownloadSettingsReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="EchoReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseEchoReceived(EchoResponse value) => EchoReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="EncounterReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseEncounterReceived(EncounterResponse value) => EncounterReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="EncounterTutorialCompleteReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseEncounterTutorialCompleteReceived(EncounterTutorialCompleteResponse value) => EncounterTutorialCompleteReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="EquipBadgeReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseEquipBadgeReceived(EquipBadgeResponse value) => EquipBadgeReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="EvolvePokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseEvolvePokemonReceived(EvolvePokemonResponse value) => EvolvePokemonReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="FortDeployPokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseFortDeployPokemonReceived(FortDeployPokemonResponse value) => FortDeployPokemonReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="FortDetailsReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseFortDetailsReceived(FortDetailsResponse value) => FortDetailsReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="FortRecallPokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseFortRecallPokemonReceived(FortRecallPokemonResponse value) => FortRecallPokemonReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="FortSearchReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseFortSearchReceived(FortSearchResponse value) => FortSearchReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="AssetDigestReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseAssetDigestReceived(GetAssetDigestResponse value) => AssetDigestReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="BuddyWalkedReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseBuddyWalkedReceived(GetBuddyWalkedResponse value) => BuddyWalkedReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="DownloadUrlsReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseDownloadUrlsReceived(GetDownloadUrlsResponse value) => DownloadUrlsReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="GymDetailsReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseGymDetailsReceived(GetGymDetailsResponse value) => GymDetailsReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="HatchedEggsReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseHatchedEggsReceived(GetHatchedEggsResponse value) => HatchedEggsReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="IncensePokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseIncensePokemonReceived(GetIncensePokemonResponse value) => IncensePokemonReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="InventoryReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseInventoryReceived(GetInventoryResponse value) => InventoryReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="MapObjectsReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseMapObjectsReceived(GetMapObjectsResponse value) => MapObjectsReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="PlayerProfileReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaisePlayerProfileReceived(GetPlayerProfileResponse value) => PlayerProfileReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="PlayerReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaisePlayerReceived(GetPlayerResponse value) => PlayerReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="SuggestedCodenamesReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseSuggestedCodenamesReceived(GetSuggestedCodenamesResponse value) => SuggestedCodenamesReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="IncenseEncounterReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseIncenseEncounterReceived(IncenseEncounterResponse value) => IncenseEncounterReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="LevelUpRewardsReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseLevelUpRewardsReceived(LevelUpRewardsResponse value) => LevelUpRewardsReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="MarkTutorialCompleteReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseMarkTutorialCompleteReceived(MarkTutorialCompleteResponse value) => MarkTutorialCompleteReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="NicknamePokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseNicknamePokemonReceived(NicknamePokemonResponse value) => NicknamePokemonReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="PlayerUpdateReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaisePlayerUpdateReceived(PlayerUpdateResponse value) => PlayerUpdateReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="RecycleInventoryItemReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseRecycleInventoryItemReceived(RecycleInventoryItemResponse value) => RecycleInventoryItemReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="ReleasePokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseReleasePokemonReceived(ReleasePokemonResponse value) => ReleasePokemonReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="AvatarReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseAvatarReceived(SetAvatarResponse value) => AvatarReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="BuddyPokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseBuddyPokemonReceived(SetBuddyPokemonResponse value) => BuddyPokemonReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="ContactSettingsReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseContactSettingsReceived(SetContactSettingsResponse value) => ContactSettingsReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="FavoritePokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseFavoritePokemonReceived(SetFavoritePokemonResponse value) => FavoritePokemonReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="PlayerTeamReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaisePlayerTeamReceived(SetPlayerTeamResponse value) => PlayerTeamReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="SfidaActionLogReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseSfidaActionLogReceived(SfidaActionLogResponse value) => SfidaActionLogReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="StartGymBattleReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseStartGymBattleReceived(StartGymBattleResponse value) => StartGymBattleReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="UpgradePokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseUpgradePokemonReceived(UpgradePokemonResponse value) => UpgradePokemonReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="UseIncenseReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseUseIncenseReceived(UseIncenseResponse value) => UseIncenseReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="UseItemCaptureReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseUseItemCaptureReceived(UseItemCaptureResponse value) => UseItemCaptureReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="UseItemEggIncubatorReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseUseItemEggIncubatorReceived(UseItemEggIncubatorResponse value) => UseItemEggIncubatorReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="UseItemGymReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseUseItemGymReceived(UseItemGymResponse value) => UseItemGymReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="UseItemPotionReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseUseItemPotionReceived(UseItemPotionResponse value) => UseItemPotionReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="UseItemReviveReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseUseItemReviveReceived(UseItemReviveResponse value) => UseItemReviveReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="UseItemXpBoostReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseUseItemXpBoostReceived(UseItemXpBoostResponse value) => UseItemXpBoostReceived?.Invoke(this, value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="VerifyChallengeReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        public void RaiseVerifyChallengeReceived(VerifyChallengeResponse value) => VerifyChallengeReceived?.Invoke(this, value);


		#endregion

		#region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        internal bool ProcessMessages(IMessage[] messages)
        {
			var wasSuccessful = true;
            foreach (var message in messages)
            {
				switch (message.GetType().Name)
				{
					case "AddFortModifierResponse":
						RaiseAddFortModifierReceived(message as AddFortModifierResponse);
						break;
					case "AttackGymResponse":
						RaiseAttackGymReceived(message as AttackGymResponse);
						break;
					case "CatchPokemonResponse":
						RaiseCatchPokemonReceived(message as CatchPokemonResponse);
						break;
					case "CheckAwardedBadgesResponse":
						RaiseCheckAwardedBadgesReceived(message as CheckAwardedBadgesResponse);
						break;
					case "CheckChallengeResponse":
						RaiseCheckChallengeReceived(message as CheckChallengeResponse);
						break;
					case "CheckCodenameAvailableResponse":
						RaiseCheckCodenameAvailableReceived(message as CheckCodenameAvailableResponse);
						break;
					case "ClaimCodenameResponse":
						RaiseClaimCodenameReceived(message as ClaimCodenameResponse);
						break;
					case "CollectDailyBonusResponse":
						RaiseCollectDailyBonusReceived(message as CollectDailyBonusResponse);
						break;
					case "CollectDailyDefenderBonusResponse":
						RaiseCollectDailyDefenderBonusReceived(message as CollectDailyDefenderBonusResponse);
						break;
					case "DiskEncounterResponse":
						RaiseDiskEncounterReceived(message as DiskEncounterResponse);
						break;
					case "DownloadItemTemplatesResponse":
						RaiseDownloadItemTemplatesReceived(message as DownloadItemTemplatesResponse);
						break;
					case "DownloadRemoteConfigVersionResponse":
						RaiseDownloadRemoteConfigVersionReceived(message as DownloadRemoteConfigVersionResponse);
						break;
					case "DownloadSettingsResponse":
						RaiseDownloadSettingsReceived(message as DownloadSettingsResponse);
						break;
					case "EchoResponse":
						RaiseEchoReceived(message as EchoResponse);
						break;
					case "EncounterResponse":
						RaiseEncounterReceived(message as EncounterResponse);
						break;
					case "EncounterTutorialCompleteResponse":
						RaiseEncounterTutorialCompleteReceived(message as EncounterTutorialCompleteResponse);
						break;
					case "EquipBadgeResponse":
						RaiseEquipBadgeReceived(message as EquipBadgeResponse);
						break;
					case "EvolvePokemonResponse":
						RaiseEvolvePokemonReceived(message as EvolvePokemonResponse);
						break;
					case "FortDeployPokemonResponse":
						RaiseFortDeployPokemonReceived(message as FortDeployPokemonResponse);
						break;
					case "FortDetailsResponse":
						RaiseFortDetailsReceived(message as FortDetailsResponse);
						break;
					case "FortRecallPokemonResponse":
						RaiseFortRecallPokemonReceived(message as FortRecallPokemonResponse);
						break;
					case "FortSearchResponse":
						RaiseFortSearchReceived(message as FortSearchResponse);
						break;
					case "GetAssetDigestResponse":
						RaiseAssetDigestReceived(message as GetAssetDigestResponse);
						break;
					case "GetBuddyWalkedResponse":
						RaiseBuddyWalkedReceived(message as GetBuddyWalkedResponse);
						break;
					case "GetDownloadUrlsResponse":
						RaiseDownloadUrlsReceived(message as GetDownloadUrlsResponse);
						break;
					case "GetGymDetailsResponse":
						RaiseGymDetailsReceived(message as GetGymDetailsResponse);
						break;
					case "GetHatchedEggsResponse":
						RaiseHatchedEggsReceived(message as GetHatchedEggsResponse);
						break;
					case "GetIncensePokemonResponse":
						RaiseIncensePokemonReceived(message as GetIncensePokemonResponse);
						break;
					case "GetInventoryResponse":
						RaiseInventoryReceived(message as GetInventoryResponse);
						break;
					case "GetMapObjectsResponse":
						RaiseMapObjectsReceived(message as GetMapObjectsResponse);
						break;
					case "GetPlayerProfileResponse":
						RaisePlayerProfileReceived(message as GetPlayerProfileResponse);
						break;
					case "GetPlayerResponse":
						RaisePlayerReceived(message as GetPlayerResponse);
						break;
					case "GetSuggestedCodenamesResponse":
						RaiseSuggestedCodenamesReceived(message as GetSuggestedCodenamesResponse);
						break;
					case "IncenseEncounterResponse":
						RaiseIncenseEncounterReceived(message as IncenseEncounterResponse);
						break;
					case "LevelUpRewardsResponse":
						RaiseLevelUpRewardsReceived(message as LevelUpRewardsResponse);
						break;
					case "MarkTutorialCompleteResponse":
						RaiseMarkTutorialCompleteReceived(message as MarkTutorialCompleteResponse);
						break;
					case "NicknamePokemonResponse":
						RaiseNicknamePokemonReceived(message as NicknamePokemonResponse);
						break;
					case "PlayerUpdateResponse":
						RaisePlayerUpdateReceived(message as PlayerUpdateResponse);
						break;
					case "RecycleInventoryItemResponse":
						RaiseRecycleInventoryItemReceived(message as RecycleInventoryItemResponse);
						break;
					case "ReleasePokemonResponse":
						RaiseReleasePokemonReceived(message as ReleasePokemonResponse);
						break;
					case "SetAvatarResponse":
						RaiseAvatarReceived(message as SetAvatarResponse);
						break;
					case "SetBuddyPokemonResponse":
						RaiseBuddyPokemonReceived(message as SetBuddyPokemonResponse);
						break;
					case "SetContactSettingsResponse":
						RaiseContactSettingsReceived(message as SetContactSettingsResponse);
						break;
					case "SetFavoritePokemonResponse":
						RaiseFavoritePokemonReceived(message as SetFavoritePokemonResponse);
						break;
					case "SetPlayerTeamResponse":
						RaisePlayerTeamReceived(message as SetPlayerTeamResponse);
						break;
					case "SfidaActionLogResponse":
						RaiseSfidaActionLogReceived(message as SfidaActionLogResponse);
						break;
					case "StartGymBattleResponse":
						RaiseStartGymBattleReceived(message as StartGymBattleResponse);
						break;
					case "UpgradePokemonResponse":
						RaiseUpgradePokemonReceived(message as UpgradePokemonResponse);
						break;
					case "UseIncenseResponse":
						RaiseUseIncenseReceived(message as UseIncenseResponse);
						break;
					case "UseItemCaptureResponse":
						RaiseUseItemCaptureReceived(message as UseItemCaptureResponse);
						break;
					case "UseItemEggIncubatorResponse":
						RaiseUseItemEggIncubatorReceived(message as UseItemEggIncubatorResponse);
						break;
					case "UseItemGymResponse":
						RaiseUseItemGymReceived(message as UseItemGymResponse);
						break;
					case "UseItemPotionResponse":
						RaiseUseItemPotionReceived(message as UseItemPotionResponse);
						break;
					case "UseItemReviveResponse":
						RaiseUseItemReviveReceived(message as UseItemReviveResponse);
						break;
					case "UseItemXpBoostResponse":
						RaiseUseItemXpBoostReceived(message as UseItemXpBoostResponse);
						break;
					case "VerifyChallengeResponse":
						RaiseVerifyChallengeReceived(message as VerifyChallengeResponse);
						break;
					default:
						// @robertmclaws: We got a payload we didn't understand, and couldn't process.
						wasSuccessful = false;
						break;
				}
            }

            return wasSuccessful;
        }

		#endregion

	}

}