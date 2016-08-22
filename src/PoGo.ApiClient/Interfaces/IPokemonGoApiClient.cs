using PoGo.ApiClient.Enums;
using PoGo.ApiClient.Extensions;
using PoGo.ApiClient.Helpers;
using PoGo.ApiClient.Rpc;
using PoGo.ApiClient.Session;
using POGOProtos.Networking.Envelopes;

namespace PoGo.ApiClient.Interfaces
{
    public interface IPokemonGoApiClient
    {
        string AuthToken { get; }
        AuthType AuthType { get; }
        IApiFailureStrategy ApiFailure { get; }
        string ApiUrl { get; set; }
        AuthTicket AuthTicket { get; }
        AccessToken AccessToken { get; set; }
        double CurrentLatitude { get; }
        double CurrentLongitude { get; }
        double CurrentAltitude { get; }
        IDeviceInfo DeviceInfo { get; }
        IDownload Download { get; }
        IEncounter Encounter { get; }
        IFort Fort { get; }
        IInventory Inventory { get; }
        Rpc.LoginClient Login { get; }
        IMap Map { get; }
        Misc Misc { get; }
        IPlayer Player { get; }
        ISettings Settings { get; }
    }
}