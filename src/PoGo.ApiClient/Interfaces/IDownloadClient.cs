using POGOProtos.Enums;
using System.Collections.Generic;

namespace PoGo.ApiClient.Interfaces
{

    /// <summary>
    /// 
    /// </summary>
    public interface IDownloadClient
    {

        /// <summary>
        /// 
        /// </summary>
        string DownloadSettingsHash { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool QueueDownloadItemTemplatesRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appVersion"></param>
        /// <param name="deviceManufacturer"></param>
        /// <param name="deviceModel"></param>
        /// <param name="locale"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        bool QueueDownloadRemoteConfigVersionRequest(uint appVersion, string deviceManufacturer, string deviceModel, string locale, Platform platform);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool QueueDownloadSettingsRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appVersion"></param>
        /// <param name="deviceManufacturer"></param>
        /// <param name="deviceModel"></param>
        /// <param name="locale"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        bool QueueGetAssetDigestRequest(uint appVersion, string deviceManufacturer, string deviceModel, string locale, Platform platform);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetIds"></param>
        /// <returns></returns>
        bool QueueGetDownloadUrlsRequest(IEnumerable<string> assetIds);

    }

}