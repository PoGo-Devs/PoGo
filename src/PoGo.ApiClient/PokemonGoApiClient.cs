using PoGo.ApiClient.Enums;
using PoGo.ApiClient.Extensions;
using PoGo.ApiClient.Helpers;
using PoGo.ApiClient.HttpClient;
using PoGo.ApiClient.Interfaces;
using PoGo.ApiClient.Rpc;
using PoGo.ApiClient.Session;
using POGOProtos.Networking.Envelopes;

namespace PoGo.ApiClient
{
    public class PokemonGoApiClient : IPokemonGoApiClient
    {

        #region Private Members

        internal readonly PokemonHttpClient PokemonHttpClient = new PokemonHttpClient();

        #endregion

        #region Properties

        public string AuthToken => AccessToken?.Token;

        public AuthType AuthType => Settings.AuthType;

        public IApiFailureStrategy ApiFailure { get; }

        public string ApiUrl { get; set; }

        public AuthTicket AuthTicket => AccessToken?.AuthTicket;

        public AccessToken AccessToken { get; set; }

        public double CurrentLatitude { get; internal set; }

        public double CurrentLongitude { get; internal set; }

        public double CurrentAltitude { get; internal set; }

        public IDeviceInfo DeviceInfo { get; }

        public IDownload Download { get; }

        public IEncounter Encounter { get; }

        public IFort Fort { get; }

        public IInventory Inventory { get; }

        public Rpc.LoginClient Login { get; }

        public IMap Map { get; }

        public Misc Misc { get; }

        public IPlayer Player { get; }

        public ISettings Settings { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="apiFailureStrategy"></param>
        /// <param name="deviceInfo"></param>
        /// <param name="accessToken"></param>
        public PokemonGoApiClient(ISettings settings, IApiFailureStrategy apiFailureStrategy, IDeviceInfo deviceInfo, AccessToken accessToken = null)
        {
            Settings = settings;
            ApiFailure = apiFailureStrategy;
            AccessToken = accessToken;

            Login = new Rpc.LoginClient(this);
            Player = new PlayerClient(this);
            Download = new DownloadClient(this);
            Inventory = new InventoryClient(this);
            Map = new MapClient(this);
            Fort = new FortClient(this);
            Encounter = new EncounterClient(this);
            Misc = new Misc(this);
            DeviceInfo = deviceInfo;

            Player.SetCoordinates(Settings.DefaultLatitude, Settings.DefaultLongitude, Settings.DefaultAltitude);
        }

        #endregion

    }

}