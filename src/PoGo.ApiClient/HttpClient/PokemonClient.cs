using Google.Protobuf;
using PoGo.ApiClient.Enums;
using PoGo.ApiClient.Exceptions;
using PoGo.ApiClient.Helpers;
using PoGo.ApiClient.Interfaces;
using POGOProtos.Networking.Envelopes;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PoGo.ApiClient
{
    public class PokemonHttpClient : HttpClient
    {

        #region Static Members

        private static readonly HttpClientHandler Handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            AllowAutoRedirect = false
        };

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public PokemonHttpClient() : base(new RetryHandler(Handler))
        {
            DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Niantic App");
            DefaultRequestHeaders.ExpectContinue = false;
            DefaultRequestHeaders.TryAddWithoutValidation("Connection", "keep-alive");
            DefaultRequestHeaders.TryAddWithoutValidation("Accept", "*/*");
            DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
        }

        #endregion


        public async Task<IMessage[]> PostProtoPayload<TRequest>(string url, RequestEnvelope requestEnvelope, IApiFailureStrategy strategy,
            params Type[] responseTypes)
            where TRequest : IMessage<TRequest>
        {
            var result = new IMessage[responseTypes.Length];
            for (var i = 0; i < responseTypes.Length; i++)
            {
                result[i] = Activator.CreateInstance(responseTypes[i]) as IMessage;
                if (result[i] == null)
                {
                    throw new ArgumentException($"ResponseType {i} is not an IMessage");
                }
            }
            var urlArray = new[] { url };
            ResponseEnvelope response;
            while ((response = await PostProto<TRequest>(urlArray[0], requestEnvelope)).Returns.Count != responseTypes.Length)
            {
                var operation = await strategy.HandleApiFailure(urlArray, requestEnvelope, response);
                if (operation == ApiOperation.Abort)
                {
                    throw new InvalidResponseException($"Expected {responseTypes.Length} responses, but got {response.Returns.Count} responses.");
                }
            }

            strategy.HandleApiSuccess(requestEnvelope, response);

            for (var i = 0; i < responseTypes.Length; i++)
            {
                var payload = response.Returns[i];
                result[i].MergeFrom(payload);
            }
            return result;
        }

        public async Task<TResponsePayload> PostProtoPayload<TRequest, TResponsePayload>(string url, RequestEnvelope requestEnvelope, IApiFailureStrategy strategy)
            where TRequest : IMessage<TRequest>
            where TResponsePayload : IMessage<TResponsePayload>, new()
        {
            Debug.WriteLine($"Requesting {typeof(TResponsePayload).Name}");
            var urlArray = new[] { url };
            var response = await PostProto<TRequest>(url, requestEnvelope);

            while (response.Returns.Count == 0)
            {
                var operation = await strategy.HandleApiFailure(urlArray, requestEnvelope, response);
                if (operation == ApiOperation.Abort)
                {
                    break;
                }

                response = await PostProto<TRequest>(urlArray[0], requestEnvelope);
            }

            // TODO: statuscode = 3 probably means ban!
            if (response.Returns.Count == 0)
                throw new InvalidResponseException();

            strategy.HandleApiSuccess(requestEnvelope, response);

            //Decode payload
            //todo: multi-payload support
            var payload = response.Returns[0];
            var parsedPayload = new TResponsePayload();
            parsedPayload.MergeFrom(payload);

            return parsedPayload;
        }


        public async Task<ResponseEnvelope> PostProto<TRequest>(string url, RequestEnvelope requestEnvelope)
            where TRequest : IMessage<TRequest>
        {
            //Encode payload and put in envelop, then send
            var data = requestEnvelope.ToByteString();
            var result = await PostAsync(url, new ByteArrayContent(data.ToByteArray()));

            //Decode message
            var responseData = await result.Content.ReadAsByteArrayAsync();
            var codedStream = new CodedInputStream(responseData);
            var decodedResponse = new ResponseEnvelope();
            decodedResponse.MergeFrom(codedStream);

            return decodedResponse;
        }

    }
}