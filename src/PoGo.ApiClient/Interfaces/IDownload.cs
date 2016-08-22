using System.Collections.Generic;
using System.Threading.Tasks;
using POGOProtos.Enums;
using POGOProtos.Networking.Responses;

namespace PoGo.ApiClient.Interfaces
{
    public interface IDownload
    {
        Task<DownloadSettingsResponse> GetSettings();
        Task<DownloadItemTemplatesResponse> GetItemTemplates();

        Task<DownloadRemoteConfigVersionResponse> GetRemoteConfigVersion(uint appVersion,
            string deviceManufacturer, string deviceModel, string locale, Platform platform);

        Task<GetAssetDigestResponse> GetAssetDigest(uint appVersion, string deviceManufacturer,
            string deviceModel, string locale, Platform platform);

        Task<GetDownloadUrlsResponse> GetDownloadUrls(IEnumerable<string> assetIds);
    }
}