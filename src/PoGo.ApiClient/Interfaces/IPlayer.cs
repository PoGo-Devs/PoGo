using System.Threading.Tasks;
using POGOProtos.Data.Player;
using POGOProtos.Enums;
using POGOProtos.Networking.Responses;

namespace PoGo.ApiClient.Interfaces
{
    public interface IPlayer
    {
        Task<PlayerUpdateResponse> UpdatePlayerLocation(double latitude, double longitude, double altitude);
        Task<GetPlayerResponse> GetPlayer();
        Task<GetPlayerProfileResponse> GetPlayerProfile(string playerName);
        Task<CheckAwardedBadgesResponse> GetNewlyAwardedBadges();
        Task<CollectDailyBonusResponse> CollectDailyBonus();
        Task<CollectDailyDefenderBonusResponse> CollectDailyDefenderBonus();
        Task<EquipBadgeResponse> EquipBadge(BadgeType type);
        Task<LevelUpRewardsResponse> GetLevelUpRewards(int level);
        Task<SetAvatarResponse> SetAvatar(PlayerAvatar playerAvatar);
        Task<SetContactSettingsResponse> SetContactSetting(ContactSettings contactSettings);
        Task<SetPlayerTeamResponse> SetPlayerTeam(TeamColor teamColor);
        void SetCoordinates(double lat, double lng, double altitude);

    }
}