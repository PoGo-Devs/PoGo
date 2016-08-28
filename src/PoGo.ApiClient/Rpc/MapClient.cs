using System;
using System.Threading.Tasks;
using Google.Protobuf;
using PoGo.ApiClient.Helpers;
using PoGo.ApiClient.Interfaces;
using PoGo.ApiClient.Proto;
using POGOProtos.Networking.Requests;
using POGOProtos.Networking.Requests.Messages;
using POGOProtos.Networking.Responses;

namespace PoGo.ApiClient.Rpc
{
    public class MapClient : BaseRpc, IMap
    {
        public MapClient(PokemonGoApiClient client) : base(client)
        {
        }

        public async Task<ResponseContainer<GetMapObjectsResponse>> GetMapObjects()
        {
            #region Messages

            var getMapObjectsMessage = new GetMapObjectsMessage
            {
                CellId = {S2Helper.GetNearbyCellIds(Client.CurrentLongitude, Client.CurrentLatitude)},
                SinceTimestampMs = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                Latitude = Client.CurrentLatitude,
                Longitude = Client.CurrentLongitude
            };
            var getHatchedEggsMessage = new GetHatchedEggsMessage();
            var getInventoryMessage = new GetInventoryMessage
            {
                LastTimestampMs = DateTime.UtcNow.ToUnixTime()
            };
            var checkAwardedBadgesMessage = new CheckAwardedBadgesMessage();
            var downloadSettingsMessage = new DownloadSettingsMessage
            {
                Hash = Client.Download.DownloadSettingsHash
            };

            #endregion

            var request = RequestBuilder.GetRequestEnvelope(
                new Request
                {
                    RequestType = RequestType.GetMapObjects,
                    RequestMessage = getMapObjectsMessage.ToByteString()
                },
                new Request
                {
                    RequestType = RequestType.GetHatchedEggs,
                    RequestMessage = getHatchedEggsMessage.ToByteString()
                }, new Request
                {
                    RequestType = RequestType.GetInventory,
                    RequestMessage = getInventoryMessage.ToByteString()
                }, new Request
                {
                    RequestType = RequestType.CheckAwardedBadges,
                    RequestMessage = checkAwardedBadgesMessage.ToByteString()
                }, new Request
                {
                    RequestType = RequestType.DownloadSettings,
                    RequestMessage = downloadSettingsMessage.ToByteString()
                });

            var response =  await PostProtoPayload<Request, GetMapObjectsResponse, GetHatchedEggsResponse, 
                GetInventoryResponse, CheckAwardedBadgesResponse, DownloadSettingsResponse>(request);

            Client.Download.DownloadSettingsHash = response?.Item5?.Hash ?? "";

            return new ResponseContainer<GetMapObjectsResponse>(response.Item1, response.Item2, response.Item3, response.Item4, response.Item5);
        }

        public async Task<GetIncensePokemonResponse> GetIncensePokemons()
        {
            var message = new GetIncensePokemonMessage
            {
                PlayerLatitude = Client.CurrentLatitude,
                PlayerLongitude = Client.CurrentLongitude
            };

            return await PostProtoPayload<Request, GetIncensePokemonResponse>(RequestType.GetIncensePokemon, message);
        }
    }
}