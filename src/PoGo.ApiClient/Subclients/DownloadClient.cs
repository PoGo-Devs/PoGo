using PoGo.ApiClient.Interfaces;
using POGOProtos.Enums;
using POGOProtos.Networking.Requests;
using POGOProtos.Networking.Requests.Messages;
using System.Collections.Generic;

namespace PoGo.ApiClient.Rpc
{

    /// <summary>
    /// 
    /// </summary>
    public class DownloadClient : ClientBase, IDownloadClient
    {

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public string DownloadSettingsHash { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public DownloadClient(PokemonGoApiClient client) : base(client)
        {
            DownloadSettingsHash = "";
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool QueueSettingsRequest()
        {
            var message = new DownloadSettingsMessage
            {
                Hash = DownloadSettingsHash
            };

            return Client.QueueRequest(RequestType.DownloadSettings, message);

            //robertmclaws to do: Handle SettingsChanged event and push the new value.
            //DownloadSettingsHash = response?.Hash ?? "";
           // return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool QueueDownloadItemTemplatesRequest()
        {
            return Client.QueueRequest(RequestType.DownloadItemTemplates, new DownloadItemTemplatesMessage());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appVersion"></param>
        /// <param name="deviceManufacturer"></param>
        /// <param name="deviceModel"></param>
        /// <param name="locale"></param>
        /// <param name="platform"></param>
        public bool QueueRemoteConfigVersionRequest(uint appVersion, string deviceManufacturer, string deviceModel, string locale, Platform platform)
        {
            var message = new DownloadRemoteConfigVersionMessage
            {
                AppVersion = appVersion,
                DeviceManufacturer = deviceManufacturer,
                DeviceModel = deviceModel,
                Locale = locale,
                Platform = platform
            };

            return Client.QueueRequest(RequestType.DownloadRemoteConfigVersion, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appVersion"></param>
        /// <param name="deviceManufacturer"></param>
        /// <param name="deviceModel"></param>
        /// <param name="locale"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public bool QueueAssetDigestRequest(uint appVersion, string deviceManufacturer, string deviceModel, string locale, Platform platform)
        {
            var message = new GetAssetDigestMessage
            {
                AppVersion = appVersion,
                DeviceManufacturer = deviceManufacturer,
                DeviceModel = deviceModel,
                Locale = locale,
                Platform = platform
            };

            return Client.QueueRequest(RequestType.GetAssetDigest, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetIds"></param>
        /// <returns></returns>
        public bool QueueDownloadUrlsRequest (IEnumerable<string> assetIds)
        {
            var message = new GetDownloadUrlsMessage
            {
                AssetId = { assetIds }
            };

            return Client.QueueRequest(RequestType.GetDownloadUrls, message);
        }

        #endregion

    }

}