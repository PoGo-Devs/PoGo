using System.Threading.Tasks;
using Google.Protobuf;
using PoGo.ApiClient.Interfaces;
using POGOProtos.Data.Player;
using POGOProtos.Enums;
using POGOProtos.Networking.Requests;
using POGOProtos.Networking.Requests.Messages;
using POGOProtos.Networking.Responses;

namespace PoGo.ApiClient.Rpc
{

    /// <summary>
    /// 
    /// </summary>
    public class PlayerClient : BaseRpc, IPlayerClient
    {

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public PlayerClient(PokemonGoApiClient client) : base(client)
        {
            Client = client;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="accuracy"></param>
        /// <returns></returns>
        public bool QueueUpdatePlayerLocationRequest(double latitude, double longitude, double accuracy)
        {
            SetCoordinates(latitude, longitude, accuracy);
            var message = new PlayerUpdateMessage
            {
                Latitude = Client.CurrentLatitude,
                Longitude = Client.CurrentLongitude
            };

            return Client.QueueRequest(RequestType.PlayerUpdate, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <param name="accuracy"></param>
        public void SetCoordinates(double lat, double lng, double accuracy)
        {
            Client.CurrentLatitude = lat;
            Client.CurrentLongitude = lng;
            Client.CurrentAccuracy = accuracy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool QueueGetPlayerRequest()
        {
            return Client.QueueRequest(RequestType.GetPlayer, new GetPlayerMessage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns></returns>
        public bool QueueGetPlayerProfileRequest(string playerName)
        {
            var message = new GetPlayerProfileMessage
            {
                PlayerName = playerName
            };

            return Client.QueueRequest(RequestType.GetPlayerProfile, message);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool QueueGetNewlyAwardedBadgesRequest()
        {
            return Client.QueueRequest(RequestType.CheckAwardedBadges, new CheckAwardedBadgesMessage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool QueueollectDailyBonusRequest()
        {
            return Client.QueueRequest(RequestType.CollectDailyBonus, new CollectDailyBonusMessage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool QueueCollectDailyDefenderBonusRequest()
        {
            return Client.QueueRequest(RequestType.CollectDailyDefenderBonus, new CollectDailyDefenderBonusMessage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool QueueEquipBadgeRequest(BadgeType type)
        {
            var message = new EquipBadgeMessage
            {
                BadgeType = type
            };

            return Client.QueueRequest(RequestType.EquipBadge, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool QueueGetLevelUpRewardsRequest(int level)
        {
            var message = new LevelUpRewardsMessage
            {
                Level = level
            };

            return Client.QueueRequest(RequestType.LevelUpRewards, message);
  
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerAvatar"></param>
        /// <returns></returns>
        public bool QueueSetAvatarRequest(PlayerAvatar playerAvatar)
        {
            var message = new SetAvatarMessage
            {
                PlayerAvatar = playerAvatar
            };

            return Client.QueueRequest(RequestType.SetAvatar, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactSettings"></param>
        /// <returns></returns>
        public bool QueueSetContactSettingRequest(ContactSettings contactSettings)
        {
            var message = new SetContactSettingsMessage
            {
                ContactSettings = contactSettings
            };

            return Client.QueueRequest(RequestType.SetContactSettings, message);
                       
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teamColor"></param>
        /// <returns></returns>
        public bool QueueSetPlayerTeamRequest(TeamColor teamColor)
        {
            var message = new SetPlayerTeamMessage
            {
                Team = teamColor
            };

            return Client.QueueRequest(RequestType.SetPlayerTeam, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codename"></param>
        /// <returns></returns>
        public bool QueueClaimCodenameRequest(string codename)
        {
            var message = new ClaimCodenameMessage
            {
                Codename = codename
            };

            return Client.QueueRequest(RequestType.ClaimCodename, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codename"></param>
        /// <returns></returns>
        public bool QueueCheckCodenameAvailableRequest(string codename)
        {
            var message = new CheckCodenameAvailableMessage
            {
                Codename = codename
            };

            return Client.QueueRequest(RequestType.CheckCodenameAvailable, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool QueueGetSuggestedCodenamesRequest()
        {
            return Client.QueueRequest(RequestType.GetSuggestedCodenames, new GetSuggestedCodenamesMessage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool QueueSendEchoRequest()
        {
            return Client.QueueRequest(RequestType.Echo, new EchoMessage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool QueueMarkTutorialCompleteRequest()
        {
            return Client.QueueRequest(RequestType.MarkTutorialComplete, new MarkTutorialCompleteMessage());
        }

        #endregion

    }
}