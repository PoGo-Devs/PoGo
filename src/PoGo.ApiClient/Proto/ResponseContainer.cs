using Google.Protobuf;
using POGOProtos.Networking.Responses;

namespace PoGo.ApiClient.Proto
{

    /// <summary>
    /// Holds the batch responses for Map requests.
    /// </summary>
    public class ResponseContainer<TPrimaryResponse> where TPrimaryResponse : IMessage<TPrimaryResponse>
    {

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public TPrimaryResponse PrimaryResponse { get; set; }

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
        public ResponseContainer(TPrimaryResponse primaryResponse, GetHatchedEggsResponse hatchedEggsResponse, 
            GetInventoryResponse inventoryResponse, CheckAwardedBadgesResponse awardedBadgesResponse, 
            DownloadSettingsResponse downloadSettingsResponse)
        {
            PrimaryResponse = primaryResponse;
            HatchedEggsResponse = hatchedEggsResponse;
            InventoryResponse = inventoryResponse;
            AwardedBadgesResponse = awardedBadgesResponse;
            DownloadSettingsResponse = downloadSettingsResponse;
        }

        #endregion

    }

}