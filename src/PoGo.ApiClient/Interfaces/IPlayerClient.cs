using POGOProtos.Data.Player;
using POGOProtos.Enums;

namespace PoGo.ApiClient.Interfaces
{

    /// <summary>
    /// 
    /// </summary>
    public interface IPlayerClient
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codename"></param>
        /// <returns></returns>
        bool QueueCheckCodenameAvailableRequest(string codename);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codename"></param>
        /// <returns></returns>
        bool QueueClaimCodenameRequest(string codename);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool QueueCollectDailyBonusRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool QueueCollectDailyDefenderBonusRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool QueueEquipBadgeRequest(BadgeType type);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        bool QueueGetLevelUpRewardsRequest(int level);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns></returns>
        bool QueueGetPlayerProfileRequest(string playerName);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool QueueGetPlayerRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool QueueGetSuggestedCodenamesRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool QueueNewlyAwardedBadgesRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool QueueSendEchoRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerAvatar"></param>
        /// <returns></returns>
        bool QueueSetAvatarRequest(PlayerAvatar playerAvatar);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactSettings"></param>
        /// <returns></returns>
        bool QueueSetContactSettingRequest(ContactSettings contactSettings);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teamColor"></param>
        /// <returns></returns>
        bool QueueSetPlayerTeamRequest(TeamColor teamColor);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool QueueMarkTutorialCompleteRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="altitude"></param>
        /// <returns></returns>
        bool QueueUpdatePlayerLocationRequest(double latitude, double longitude, double altitude);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <param name="altitude"></param>
        void SetCoordinates(double lat, double lng, double altitude);

    }

}