using Google.Protobuf.Collections;
using POGOProtos.Networking.Requests;
using POGOProtos.Networking.Responses;
using System;
using System.Collections.Generic;

namespace PoGo.ApiClient
{

    /// <summary>
    /// 
    /// </summary>
    public static class ResponseMessageMapper
    {

        private static readonly Dictionary<RequestType, Type> _requestMapping = new Dictionary<RequestType, Type>
        {
            { RequestType.AddFortModifier, typeof(AddFortModifierResponse) },
            { RequestType.AttackGym, typeof(AttackGymResponse) },
            //{ RequestType.BuyGemPack, typeof(CatchPokemonResponse) },
            //{ RequestType.BuyItemPack, typeof(CheckAwardedBadgesResponse) },
            { RequestType.CatchPokemon, typeof(CatchPokemonResponse) },
            { RequestType.CheckAwardedBadges, typeof(CheckAwardedBadgesResponse) },
            { RequestType.CheckChallenge, typeof(CheckChallengeResponse) },
            { RequestType.CheckCodenameAvailable, typeof(CheckCodenameAvailableResponse) },
            { RequestType.ClaimCodename, typeof(ClaimCodenameResponse) },
            { RequestType.CollectDailyBonus, typeof(CollectDailyBonusResponse) },
            { RequestType.CollectDailyDefenderBonus, typeof(CollectDailyDefenderBonusResponse) },
            //{ RequestType.DebugDeletePlayer, typeof(DebugDeletePlayerResponse) },
            //{ RequestType.DebugUpdateInventory, typeof(DebugUpdateInventoryResponse) },
            { RequestType.DiskEncounter, typeof(DiskEncounterResponse) },
            { RequestType.DownloadItemTemplates, typeof(DownloadItemTemplatesResponse) },
            { RequestType.DownloadRemoteConfigVersion, typeof(DownloadRemoteConfigVersionResponse) },
            { RequestType.DownloadSettings, typeof(DownloadSettingsResponse) },
            { RequestType.Echo, typeof(EchoResponse) },
            { RequestType.Encounter, typeof(EncounterResponse) },
            { RequestType.EncounterTutorialComplete, typeof(EncounterTutorialCompleteResponse) },
            { RequestType.EquipBadge, typeof(EquipBadgeResponse) },
            { RequestType.EvolvePokemon, typeof(EvolvePokemonResponse) },
            { RequestType.FortDeployPokemon, typeof(FortDeployPokemonResponse) },
            { RequestType.FortDetails, typeof(FortDetailsResponse) },
            { RequestType.FortRecallPokemon, typeof(FortRecallPokemonResponse) },
            { RequestType.FortSearch, typeof(FortSearchResponse) },
            { RequestType.GetAssetDigest, typeof(GetAssetDigestResponse) },
            { RequestType.GetBuddyWalked, typeof(GetBuddyWalkedResponse) },
            { RequestType.GetDownloadUrls, typeof(GetDownloadUrlsResponse) },
            { RequestType.GetGymDetails, typeof(GetGymDetailsResponse) },
            { RequestType.GetHatchedEggs, typeof(GetHatchedEggsResponse) },
            { RequestType.GetIncensePokemon, typeof(GetIncensePokemonResponse) },
            { RequestType.GetInventory, typeof(GetInventoryResponse) },
            //{ RequestType.GetItemPack, typeof(GetItemPackResponse) },
            { RequestType.GetMapObjects, typeof(GetMapObjectsResponse) },
            { RequestType.GetPlayer, typeof(GetPlayerResponse) },
            { RequestType.GetPlayerProfile, typeof(GetPlayerProfileResponse) },
            { RequestType.GetSuggestedCodenames, typeof(GetSuggestedCodenamesResponse) },
            { RequestType.IncenseEncounter, typeof(IncenseEncounterResponse) },
            //{ RequestType.ItemUse, typeof(ItemUseResponse) },
            { RequestType.LevelUpRewards, typeof(LevelUpRewardsResponse) },
            //{ RequestType.LoadSpawnPoints, typeof(LoadSpawnPointsResponse) },
            { RequestType.MarkTutorialComplete, typeof(MarkTutorialCompleteResponse) },
            { RequestType.NicknamePokemon, typeof(NicknamePokemonResponse) },
            { RequestType.PlayerUpdate, typeof(PlayerUpdateResponse) },
            { RequestType.RecycleInventoryItem, typeof(RecycleInventoryItemResponse) },
            { RequestType.ReleasePokemon, typeof(ReleasePokemonResponse) },
            { RequestType.SetAvatar, typeof(SetAvatarResponse) },
            { RequestType.SetBuddyPokemon, typeof(SetBuddyPokemonResponse) },
            { RequestType.SetContactSettings, typeof(SetContactSettingsResponse) },
            { RequestType.SetPlayerTeam, typeof(SetPlayerTeamResponse) },
            { RequestType.SetFavoritePokemon, typeof(SetFavoritePokemonResponse) },
            //{ RequestType.SfidaAction, typeof(SfidaActionResponse) },
            { RequestType.SfidaActionLog, typeof(SfidaActionLogResponse) },
            //{ RequestType.SfidaCapture, typeof(SfidaCaptureResponse) },
            //{ RequestType.SfidaCertification, typeof(SfidaCertificationResponse) },
            //{ RequestType.SfidaDowser, typeof(SfidaDowserResponse) },
            //{ RequestType.SfidaRegistration, typeof(SfidaRegistrationResponse) },
            //{ RequestType.SfidaUpdate, typeof(SfidaUpdateResponse) },
            { RequestType.StartGymBattle, typeof(StartGymBattleResponse) },
            //{ RequestType.TradeOffer, typeof(TradeOfferResponse) },
            //{ RequestType.TradeResponse, typeof(TradeResponseResponse) },
            //{ RequestType.TradeResult, typeof(TradeResultResponse) },
            //{ RequestType.TradeSearch, typeof(TradeSearchResponse) },
            { RequestType.UpgradePokemon, typeof(UpgradePokemonResponse) },
            { RequestType.UseIncense, typeof(UseIncenseResponse) },
            { RequestType.UseItemCapture, typeof(UseItemCaptureResponse) },
            { RequestType.UseItemEggIncubator, typeof(UseItemEggIncubatorResponse) },
            //{ RequestType.UseItemFlee, typeof(UseItemFleeResponse) },
            { RequestType.UseItemGym, typeof(UseItemGymResponse) },
            { RequestType.UseItemPotion, typeof(UseItemPotionResponse) },
            { RequestType.UseItemRevive, typeof(UseItemReviveResponse) },
            { RequestType.UseItemXpBoost, typeof(UseItemXpBoostResponse) },
            { RequestType.VerifyChallenge, typeof(VerifyChallengeResponse) },
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestType"></param>
        /// <returns></returns>
        internal static Type GetExpectedResponseType(RequestType requestType)
        {
            return _requestMapping.ContainsKey(requestType) ? _requestMapping[requestType] : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        internal static IEnumerable<Type> GetExpectedResponseTypes(RepeatedField<Request> messages)
        {
            foreach (var message in messages)
            {
                yield return _requestMapping.ContainsKey(message.RequestType) ? _requestMapping[message.RequestType] : null;
            }
        }

    }

}