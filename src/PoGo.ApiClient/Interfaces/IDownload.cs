using POGOProtos.Enums;
using System.Collections.Generic;

namespace PoGo.ApiClient.Interfaces
{

    /// <summary>
    /// 
    /// </summary>
    public interface IDownload
    {

        /// <summary>
        /// 
        /// </summary>
        string DownloadSettingsHash { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool QueueSettingsRequest();

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
        bool QueueRemoteConfigVersionRequest(uint appVersion, string deviceManufacturer, string deviceModel, string locale, Platform platform);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appVersion"></param>
        /// <param name="deviceManufacturer"></param>
        /// <param name="deviceModel"></param>
        /// <param name="locale"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        bool QueueAssetDigestRequest(uint appVersion, string deviceManufacturer, string deviceModel, string locale, Platform platform);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetIds"></param>
        /// <returns></returns>
        bool QueueDownloadUrlsRequest(IEnumerable<string> assetIds);
    }
}