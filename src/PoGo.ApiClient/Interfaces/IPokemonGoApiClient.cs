using PoGo.ApiClient.Enums;
using PoGo.ApiClient.Helpers;
using PoGo.ApiClient.Rpc;
using PoGo.ApiClient.Session;
using POGOProtos.Networking.Envelopes;
using System.Net.Http;

namespace PoGo.ApiClient.Interfaces
{
    public interface IPokemonGoApiClient
    {
        string AuthToken { get; }
        AuthType AuthType { get; }
        string ApiUrl { get; set; }
        AuthTicket AuthTicket { get; }
        AccessToken AccessToken { get; set; }
        double CurrentLatitude { get; }
        double CurrentLongitude { get; }
        double CurrentAltitude { get; }
        IDeviceInfo DeviceInfo { get; }
        IDownloadClient Download { get; }
        IEncounterClient Encounter { get; }
        IFortClient Fort { get; }
        IInventoryClient Inventory { get; }
        Rpc.UserClient Login { get; }
        IMapClient Map { get; }
        Misc Misc { get; }
        IPlayerClient Player { get; }
        IApiSettings Settings { get; }
    }
}