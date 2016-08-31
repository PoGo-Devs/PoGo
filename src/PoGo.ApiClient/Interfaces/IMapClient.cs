
namespace PoGo.ApiClient.Interfaces
{

    /// <summary>
    /// 
    /// </summary>
    public interface IMapClient
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool QueueIncensedPokemonRequest();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool QueueMapObjectsRequest();

    }

}