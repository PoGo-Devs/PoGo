using System.Threading.Tasks;
using PoGo.ApiClient.Proto;
using POGOProtos.Networking.Responses;

namespace PoGo.ApiClient.Interfaces
{
    public interface IMap
    {
        Task<ResponseContainer<GetMapObjectsResponse>> GetMapObjects();
        Task<GetIncensePokemonResponse> GetIncensePokemons();
    }
}