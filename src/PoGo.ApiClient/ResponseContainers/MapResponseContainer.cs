using POGOProtos.Networking.Responses;

namespace PoGo.ApiClient.ResponseContainers
{

    /// <summary>
    /// Holds the batch responses for Map requests.
    /// </summary>
    public class MapResponseContainer
    {

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public GetMapObjectsResponse MapObjectsResponse { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public GetHatchedEggsResponse HatchedEggsResponse { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public GetInventoryResponse InventoryResponse { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CheckAwardedBadgesResponse AwardedBadgesResponse { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DownloadSettingsResponse DownloadSettingsResponse { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapObjectsResponse"></param>
        /// <param name="hatchedEggsResponse"></param>
        /// <param name="inventoryResponse"></param>
        /// <param name="awardedBadgesResponse"></param>
        /// <param name="downloadSettingsResponse"></param>
        public MapResponseContainer(GetMapObjectsResponse mapObjectsResponse, GetHatchedEggsResponse hatchedEggsResponse, 
            GetInventoryResponse inventoryResponse, CheckAwardedBadgesResponse awardedBadgesResponse, 
            DownloadSettingsResponse downloadSettingsResponse)
        {
            MapObjectsResponse = mapObjectsResponse;
            HatchedEggsResponse = hatchedEggsResponse;
            InventoryResponse = inventoryResponse;
            AwardedBadgesResponse = awardedBadgesResponse;
            DownloadSettingsResponse = downloadSettingsResponse;
        }

        #endregion

    }

}