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
        /// <param name="locale"></param>
        /// <returns></returns>
        bool QueueDownloadRemoteConfigVersionRequest(uint appVersion, string locale);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool QueueDownloadSettingsRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appVersion"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        bool QueueGetAssetDigestRequest(uint appVersion, string locale);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetIds"></param>
        /// <returns></returns>
        bool QueueGetDownloadUrlsRequest(IEnumerable<string> assetIds);

    }

}