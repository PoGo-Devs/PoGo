using POGOProtos.Networking.Responses;
using System;

namespace PoGo.ApiClient.Interfaces
{
    public partial interface IPokemonGoApiClient
    {

        #region Events

		///<summary>
		/// Fires every time a <see cref="AddFortModifierResponse" /> is received from the API.
		/// </summary>
		event EventHandler<AddFortModifierResponse> AddFortModifierReceived;

		///<summary>
		/// Fires every time a <see cref="AttackGymResponse" /> is received from the API.
		/// </summary>
		event EventHandler<AttackGymResponse> AttackGymReceived;

		///<summary>
		/// Fires every time a <see cref="CatchPokemonResponse" /> is received from the API.
		/// </summary>
		event EventHandler<CatchPokemonResponse> CatchPokemonReceived;

		///<summary>
		/// Fires every time a <see cref="CheckAwardedBadgesResponse" /> is received from the API.
		/// </summary>
		event EventHandler<CheckAwardedBadgesResponse> CheckAwardedBadgesReceived;

		///<summary>
		/// Fires every time a <see cref="CheckChallengeResponse" /> is received from the API.
		/// </summary>
		event EventHandler<CheckChallengeResponse> CheckChallengeReceived;

		///<summary>
		/// Fires every time a <see cref="CheckCodenameAvailableResponse" /> is received from the API.
		/// </summary>
		event EventHandler<CheckCodenameAvailableResponse> CheckCodenameAvailableReceived;

		///<summary>
		/// Fires every time a <see cref="ClaimCodenameResponse" /> is received from the API.
		/// </summary>
		event EventHandler<ClaimCodenameResponse> ClaimCodenameReceived;

		///<summary>
		/// Fires every time a <see cref="CollectDailyBonusResponse" /> is received from the API.
		/// </summary>
		event EventHandler<CollectDailyBonusResponse> CollectDailyBonusReceived;

		///<summary>
		/// Fires every time a <see cref="CollectDailyDefenderBonusResponse" /> is received from the API.
		/// </summary>
		event EventHandler<CollectDailyDefenderBonusResponse> CollectDailyDefenderBonusReceived;

		///<summary>
		/// Fires every time a <see cref="DiskEncounterResponse" /> is received from the API.
		/// </summary>
		event EventHandler<DiskEncounterResponse> DiskEncounterReceived;

		///<summary>
		/// Fires every time a <see cref="DownloadItemTemplatesResponse" /> is received from the API.
		/// </summary>
		event EventHandler<DownloadItemTemplatesResponse> DownloadItemTemplatesReceived;

		///<summary>
		/// Fires every time a <see cref="DownloadRemoteConfigVersionResponse" /> is received from the API.
		/// </summary>
		event EventHandler<DownloadRemoteConfigVersionResponse> DownloadRemoteConfigVersionReceived;

		///<summary>
		/// Fires every time a <see cref="DownloadSettingsResponse" /> is received from the API.
		/// </summary>
		event EventHandler<DownloadSettingsResponse> DownloadSettingsReceived;

		///<summary>
		/// Fires every time a <see cref="EchoResponse" /> is received from the API.
		/// </summary>
		event EventHandler<EchoResponse> EchoReceived;

		///<summary>
		/// Fires every time a <see cref="EncounterResponse" /> is received from the API.
		/// </summary>
		event EventHandler<EncounterResponse> EncounterReceived;

		///<summary>
		/// Fires every time a <see cref="EncounterTutorialCompleteResponse" /> is received from the API.
		/// </summary>
		event EventHandler<EncounterTutorialCompleteResponse> EncounterTutorialCompleteReceived;

		///<summary>
		/// Fires every time a <see cref="EquipBadgeResponse" /> is received from the API.
		/// </summary>
		event EventHandler<EquipBadgeResponse> EquipBadgeReceived;

		///<summary>
		/// Fires every time a <see cref="EvolvePokemonResponse" /> is received from the API.
		/// </summary>
		event EventHandler<EvolvePokemonResponse> EvolvePokemonReceived;

		///<summary>
		/// Fires every time a <see cref="FortDeployPokemonResponse" /> is received from the API.
		/// </summary>
		event EventHandler<FortDeployPokemonResponse> FortDeployPokemonReceived;

		///<summary>
		/// Fires every time a <see cref="FortDetailsResponse" /> is received from the API.
		/// </summary>
		event EventHandler<FortDetailsResponse> FortDetailsReceived;

		///<summary>
		/// Fires every time a <see cref="FortRecallPokemonResponse" /> is received from the API.
		/// </summary>
		event EventHandler<FortRecallPokemonResponse> FortRecallPokemonReceived;

		///<summary>
		/// Fires every time a <see cref="FortSearchResponse" /> is received from the API.
		/// </summary>
		event EventHandler<FortSearchResponse> FortSearchReceived;

		///<summary>
		/// Fires every time a <see cref="GetAssetDigestResponse" /> is received from the API.
		/// </summary>
		event EventHandler<GetAssetDigestResponse> AssetDigestReceived;

		///<summary>
		/// Fires every time a <see cref="GetBuddyWalkedResponse" /> is received from the API.
		/// </summary>
		event EventHandler<GetBuddyWalkedResponse> BuddyWalkedReceived;

		///<summary>
		/// Fires every time a <see cref="GetDownloadUrlsResponse" /> is received from the API.
		/// </summary>
		event EventHandler<GetDownloadUrlsResponse> DownloadUrlsReceived;

		///<summary>
		/// Fires every time a <see cref="GetGymDetailsResponse" /> is received from the API.
		/// </summary>
		event EventHandler<GetGymDetailsResponse> GymDetailsReceived;

		///<summary>
		/// Fires every time a <see cref="GetHatchedEggsResponse" /> is received from the API.
		/// </summary>
		event EventHandler<GetHatchedEggsResponse> HatchedEggsReceived;

		///<summary>
		/// Fires every time a <see cref="GetIncensePokemonResponse" /> is received from the API.
		/// </summary>
		event EventHandler<GetIncensePokemonResponse> IncensePokemonReceived;

		///<summary>
		/// Fires every time a <see cref="GetInventoryResponse" /> is received from the API.
		/// </summary>
		event EventHandler<GetInventoryResponse> InventoryReceived;

		///<summary>
		/// Fires every time a <see cref="GetMapObjectsResponse" /> is received from the API.
		/// </summary>
		event EventHandler<GetMapObjectsResponse> MapObjectsReceived;

		///<summary>
		/// Fires every time a <see cref="GetPlayerProfileResponse" /> is received from the API.
		/// </summary>
		event EventHandler<GetPlayerProfileResponse> PlayerProfileReceived;

		///<summary>
		/// Fires every time a <see cref="GetPlayerResponse" /> is received from the API.
		/// </summary>
		event EventHandler<GetPlayerResponse> PlayerReceived;

		///<summary>
		/// Fires every time a <see cref="GetSuggestedCodenamesResponse" /> is received from the API.
		/// </summary>
		event EventHandler<GetSuggestedCodenamesResponse> SuggestedCodenamesReceived;

		///<summary>
		/// Fires every time a <see cref="IncenseEncounterResponse" /> is received from the API.
		/// </summary>
		event EventHandler<IncenseEncounterResponse> IncenseEncounterReceived;

		///<summary>
		/// Fires every time a <see cref="LevelUpRewardsResponse" /> is received from the API.
		/// </summary>
		event EventHandler<LevelUpRewardsResponse> LevelUpRewardsReceived;

		///<summary>
		/// Fires every time a <see cref="MarkTutorialCompleteResponse" /> is received from the API.
		/// </summary>
		event EventHandler<MarkTutorialCompleteResponse> MarkTutorialCompleteReceived;

		///<summary>
		/// Fires every time a <see cref="NicknamePokemonResponse" /> is received from the API.
		/// </summary>
		event EventHandler<NicknamePokemonResponse> NicknamePokemonReceived;

		///<summary>
		/// Fires every time a <see cref="PlayerUpdateResponse" /> is received from the API.
		/// </summary>
		event EventHandler<PlayerUpdateResponse> PlayerUpdateReceived;

		///<summary>
		/// Fires every time a <see cref="RecycleInventoryItemResponse" /> is received from the API.
		/// </summary>
		event EventHandler<RecycleInventoryItemResponse> RecycleInventoryItemReceived;

		///<summary>
		/// Fires every time a <see cref="ReleasePokemonResponse" /> is received from the API.
		/// </summary>
		event EventHandler<ReleasePokemonResponse> ReleasePokemonReceived;

		///<summary>
		/// Fires every time a <see cref="SetAvatarResponse" /> is received from the API.
		/// </summary>
		event EventHandler<SetAvatarResponse> AvatarReceived;

		///<summary>
		/// Fires every time a <see cref="SetBuddyPokemonResponse" /> is received from the API.
		/// </summary>
		event EventHandler<SetBuddyPokemonResponse> BuddyPokemonReceived;

		///<summary>
		/// Fires every time a <see cref="SetContactSettingsResponse" /> is received from the API.
		/// </summary>
		event EventHandler<SetContactSettingsResponse> ContactSettingsReceived;

		///<summary>
		/// Fires every time a <see cref="SetFavoritePokemonResponse" /> is received from the API.
		/// </summary>
		event EventHandler<SetFavoritePokemonResponse> FavoritePokemonReceived;

		///<summary>
		/// Fires every time a <see cref="SetPlayerTeamResponse" /> is received from the API.
		/// </summary>
		event EventHandler<SetPlayerTeamResponse> PlayerTeamReceived;

		///<summary>
		/// Fires every time a <see cref="SfidaActionLogResponse" /> is received from the API.
		/// </summary>
		event EventHandler<SfidaActionLogResponse> SfidaActionLogReceived;

		///<summary>
		/// Fires every time a <see cref="StartGymBattleResponse" /> is received from the API.
		/// </summary>
		event EventHandler<StartGymBattleResponse> StartGymBattleReceived;

		///<summary>
		/// Fires every time a <see cref="UpgradePokemonResponse" /> is received from the API.
		/// </summary>
		event EventHandler<UpgradePokemonResponse> UpgradePokemonReceived;

		///<summary>
		/// Fires every time a <see cref="UseIncenseResponse" /> is received from the API.
		/// </summary>
		event EventHandler<UseIncenseResponse> UseIncenseReceived;

		///<summary>
		/// Fires every time a <see cref="UseItemCaptureResponse" /> is received from the API.
		/// </summary>
		event EventHandler<UseItemCaptureResponse> UseItemCaptureReceived;

		///<summary>
		/// Fires every time a <see cref="UseItemEggIncubatorResponse" /> is received from the API.
		/// </summary>
		event EventHandler<UseItemEggIncubatorResponse> UseItemEggIncubatorReceived;

		///<summary>
		/// Fires every time a <see cref="UseItemGymResponse" /> is received from the API.
		/// </summary>
		event EventHandler<UseItemGymResponse> UseItemGymReceived;

		///<summary>
		/// Fires every time a <see cref="UseItemPotionResponse" /> is received from the API.
		/// </summary>
		event EventHandler<UseItemPotionResponse> UseItemPotionReceived;

		///<summary>
		/// Fires every time a <see cref="UseItemReviveResponse" /> is received from the API.
		/// </summary>
		event EventHandler<UseItemReviveResponse> UseItemReviveReceived;

		///<summary>
		/// Fires every time a <see cref="UseItemXpBoostResponse" /> is received from the API.
		/// </summary>
		event EventHandler<UseItemXpBoostResponse> UseItemXpBoostReceived;

		///<summary>
		/// Fires every time a <see cref="VerifyChallengeResponse" /> is received from the API.
		/// </summary>
		event EventHandler<VerifyChallengeResponse> VerifyChallengeReceived;


		#endregion

		#region Event Raisers


        /// <summary>
        /// Provides a safe way to invoke the <see cref="AddFortModifierReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseAddFortModifierReceived(AddFortModifierResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="AttackGymReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseAttackGymReceived(AttackGymResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="CatchPokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseCatchPokemonReceived(CatchPokemonResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="CheckAwardedBadgesReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseCheckAwardedBadgesReceived(CheckAwardedBadgesResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="CheckChallengeReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseCheckChallengeReceived(CheckChallengeResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="CheckCodenameAvailableReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseCheckCodenameAvailableReceived(CheckCodenameAvailableResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="ClaimCodenameReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseClaimCodenameReceived(ClaimCodenameResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="CollectDailyBonusReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseCollectDailyBonusReceived(CollectDailyBonusResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="CollectDailyDefenderBonusReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseCollectDailyDefenderBonusReceived(CollectDailyDefenderBonusResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="DiskEncounterReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseDiskEncounterReceived(DiskEncounterResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="DownloadItemTemplatesReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseDownloadItemTemplatesReceived(DownloadItemTemplatesResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="DownloadRemoteConfigVersionReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseDownloadRemoteConfigVersionReceived(DownloadRemoteConfigVersionResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="DownloadSettingsReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseDownloadSettingsReceived(DownloadSettingsResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="EchoReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseEchoReceived(EchoResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="EncounterReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseEncounterReceived(EncounterResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="EncounterTutorialCompleteReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseEncounterTutorialCompleteReceived(EncounterTutorialCompleteResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="EquipBadgeReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseEquipBadgeReceived(EquipBadgeResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="EvolvePokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseEvolvePokemonReceived(EvolvePokemonResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="FortDeployPokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseFortDeployPokemonReceived(FortDeployPokemonResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="FortDetailsReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseFortDetailsReceived(FortDetailsResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="FortRecallPokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseFortRecallPokemonReceived(FortRecallPokemonResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="FortSearchReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseFortSearchReceived(FortSearchResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="AssetDigestReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseAssetDigestReceived(GetAssetDigestResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="BuddyWalkedReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseBuddyWalkedReceived(GetBuddyWalkedResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="DownloadUrlsReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseDownloadUrlsReceived(GetDownloadUrlsResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="GymDetailsReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseGymDetailsReceived(GetGymDetailsResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="HatchedEggsReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseHatchedEggsReceived(GetHatchedEggsResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="IncensePokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseIncensePokemonReceived(GetIncensePokemonResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="InventoryReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseInventoryReceived(GetInventoryResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="MapObjectsReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseMapObjectsReceived(GetMapObjectsResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="PlayerProfileReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaisePlayerProfileReceived(GetPlayerProfileResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="PlayerReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaisePlayerReceived(GetPlayerResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="SuggestedCodenamesReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseSuggestedCodenamesReceived(GetSuggestedCodenamesResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="IncenseEncounterReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseIncenseEncounterReceived(IncenseEncounterResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="LevelUpRewardsReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseLevelUpRewardsReceived(LevelUpRewardsResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="MarkTutorialCompleteReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseMarkTutorialCompleteReceived(MarkTutorialCompleteResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="NicknamePokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseNicknamePokemonReceived(NicknamePokemonResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="PlayerUpdateReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaisePlayerUpdateReceived(PlayerUpdateResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="RecycleInventoryItemReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseRecycleInventoryItemReceived(RecycleInventoryItemResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="ReleasePokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseReleasePokemonReceived(ReleasePokemonResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="AvatarReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseAvatarReceived(SetAvatarResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="BuddyPokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseBuddyPokemonReceived(SetBuddyPokemonResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="ContactSettingsReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseContactSettingsReceived(SetContactSettingsResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="FavoritePokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseFavoritePokemonReceived(SetFavoritePokemonResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="PlayerTeamReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaisePlayerTeamReceived(SetPlayerTeamResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="SfidaActionLogReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseSfidaActionLogReceived(SfidaActionLogResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="StartGymBattleReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseStartGymBattleReceived(StartGymBattleResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="UpgradePokemonReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseUpgradePokemonReceived(UpgradePokemonResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="UseIncenseReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseUseIncenseReceived(UseIncenseResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="UseItemCaptureReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseUseItemCaptureReceived(UseItemCaptureResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="UseItemEggIncubatorReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseUseItemEggIncubatorReceived(UseItemEggIncubatorResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="UseItemGymReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseUseItemGymReceived(UseItemGymResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="UseItemPotionReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseUseItemPotionReceived(UseItemPotionResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="UseItemReviveReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseUseItemReviveReceived(UseItemReviveResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="UseItemXpBoostReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseUseItemXpBoostReceived(UseItemXpBoostResponse value);


        /// <summary>
        /// Provides a safe way to invoke the <see cref="VerifyChallengeReceived" /> event.
        /// </summary>
        /// <param name="value"></param>
        void RaiseVerifyChallengeReceived(VerifyChallengeResponse value);


		#endregion

	}

}