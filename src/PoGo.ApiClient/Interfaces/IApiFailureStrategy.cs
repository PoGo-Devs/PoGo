using System.Threading.Tasks;
using POGOProtos.Networking.Envelopes;
using PoGo.ApiClient.Enums;

namespace PoGo.ApiClient.Interfaces
{

    public interface IApiFailureStrategy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        Task<ApiOperation> HandleApiFailure(string[] url, RequestEnvelope request, ResponseEnvelope response);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        void HandleApiSuccess(RequestEnvelope request, ResponseEnvelope response);
    }

}