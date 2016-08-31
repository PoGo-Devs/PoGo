using PoGo.ApiClient.Helpers;
using PoGo.ApiClient.Interfaces;
using POGOProtos.Networking.Requests;
using POGOProtos.Networking.Requests.Messages;

namespace PoGo.ApiClient.Rpc
{

    /// <summary>
    /// 
    /// </summary>
    public class MapClient : ClientBase, IMapClient
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public MapClient(PokemonGoApiClient client) : base(client)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool QueueMapObjectsRequest()
        {
            var message = new GetMapObjectsMessage
            {
                CellId = { S2Helper.GetNearbyCellIds(Client.CurrentPosition.Longitude, Client.CurrentPosition.Latitude) },
                SinceTimestampMs = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                Latitude = Client.CurrentPosition.Latitude,
                Longitude = Client.CurrentPosition.Longitude
            };

            return Client.QueueRequest(RequestType.GetMapObjects, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool QueueIncensedPokemonRequest()
        {
            var message = new GetIncensePokemonMessage
            {
                PlayerLatitude = Client.CurrentPosition.Latitude,
                PlayerLongitude = Client.CurrentPosition.Longitude
            };

            return Client.QueueRequest(RequestType.GetIncensePokemon, message);
        }

    }

}