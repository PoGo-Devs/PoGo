using System.Threading.Tasks;
using POGOProtos.Networking.Envelopes;

namespace PoGo.ApiClient.Interfaces
{
    public interface IApiFailureStrategy
    {
        Task<ApiOperation> HandleApiFailure(string[] url, RequestEnvelope request, ResponseEnvelope response);
        void HandleApiSuccess(RequestEnvelope request, ResponseEnvelope response);
    }
}