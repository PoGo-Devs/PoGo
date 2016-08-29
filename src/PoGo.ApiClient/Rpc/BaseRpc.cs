using Google.Protobuf;
using PoGo.ApiClient.Helpers;
using POGOProtos.Networking.Envelopes;
using POGOProtos.Networking.Requests;
using System;
using System.Threading.Tasks;

namespace PoGo.ApiClient.Rpc
{
    public class BaseRpc
    {

        #region Private Members
        
        protected PokemonGoApiClient Client;

        private string ApiUrl => $"https://{Client.ApiUrl}/rpc";

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public static DateTime LastRpcRequest { get; internal set; }

        #endregion

        protected BaseRpc(PokemonGoApiClient client)
        {
            Client = client;
        }

        //protected RequestBuilder RequestBuilder => new RequestBuilder(Client.AuthToken, Client.AuthType, 
        //    Client.CurrentLatitude, Client.CurrentLongitude, Client.CurrentAccuracy, Client.DeviceInfo, Client.AuthTicket);


        //protected async Task<TResponsePayload> PostProtoPayload<TRequest, TResponsePayload>(RequestType type, IMessage message)
        //    where TRequest : IMessage<TRequest>
        //    where TResponsePayload : IMessage<TResponsePayload>, new()
        //{
        //    var requestEnvelops = RequestBuilder.GetRequestEnvelope(type, message);
        //    return await  Client.PostProto<TRequest, TResponsePayload>(ApiUrl, requestEnvelops);
        //}

        //protected async Task<TResponsePayload> PostProtoPayload<TRequest, TResponsePayload>(RequestEnvelope requestEnvelope)
        //    where TRequest : IMessage<TRequest>
        //    where TResponsePayload : IMessage<TResponsePayload>, new()
        //{
        //    return await Client.PostProto<TRequest, TResponsePayload>(ApiUrl, requestEnvelope);
        //}

        //protected async Task<Tuple<T1, T2, T3, T4, T5>> PostProtoPayload<TRequest, T1, T2, T3, T4, T5>(RequestEnvelope requestEnvelope)
        //    where TRequest : IMessage<TRequest>
        //    where T1 : class, IMessage<T1>, new()
        //    where T2 : class, IMessage<T2>, new()
        //    where T3 : class, IMessage<T3>, new()
        //    where T4 : class, IMessage<T4>, new()
        //    where T5 : class, IMessage<T5>, new()
        //{
        //    var responses = await PostProtoPayload<TRequest>(requestEnvelope, typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5));
        //    return new Tuple<T1, T2, T3, T4, T5>(responses[0] as T1, responses[1] as T2, responses[2] as T3, responses[3] as T4,
        //        responses[4] as T5);
        //}

        //protected async Task<IMessage[]> PostProtoPayload<TRequest>(RequestEnvelope requestEnvelope, params Type[] responseTypes)
        //    where TRequest : IMessage<TRequest>
        //{
        //    LastRpcRequest = DateTime.Now;
        //    return await  Client.PokemonHttpClient.PostProtoPayload<TRequest>(ApiUrl, requestEnvelope, Client.ApiFailure, responseTypes);
        //}

        //protected async Task<ResponseEnvelope> PostProto<TRequest>(string url, RequestEnvelope requestEnvelope)
        //    where TRequest : IMessage<TRequest>
        //{            
        //    LastRpcRequest = DateTime.Now;            
        //    return await Client.PokemonHttpClient.PostProto<TRequest>(url, requestEnvelope);
        //}

    }

}