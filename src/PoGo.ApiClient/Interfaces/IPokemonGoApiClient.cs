using PoGo.ApiClient.Authentication;

namespace PoGo.ApiClient.Interfaces
{

    /// <summary>
    /// 
    /// </summary>
    public partial interface IPokemonGoApiClient
    {

        /// <summary>
        /// 
        /// </summary>
        IApiSettings ApiSettings { get; }


        /// <summary>
        /// 
        /// </summary>
        string ApiUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        AuthenticatedUser AuthenticatedUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        GeoCoordinate CurrentPosition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        IAuthenticationProvider CurrentProvider { get; }

        /// <summary>
        /// 
        /// </summary>
        IDeviceInfo DeviceInfo { get; }

        /// <summary>
        /// 
        /// </summary>
        IDownloadClient Download { get; }

        /// <summary>
        /// 
        /// </summary>
        IEncounterClient Encounter { get; }

        /// <summary>
        /// 
        /// </summary>
        IFortClient Fort { get; }

        /// <summary>
        /// 
        /// </summary>
        IInventoryClient Inventory { get; }

        /// <summary>
        /// 
        /// </summary>
        IMapClient Map { get; }

        /// <summary>
        /// 
        /// </summary>
        IPlayerClient Player { get; }

    }

}