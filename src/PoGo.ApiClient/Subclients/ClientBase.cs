using System;

namespace PoGo.ApiClient.Rpc
{

    /// <summary>
    /// 
    /// </summary>
    public class ClientBase
    {

        #region Private Members
        
        /// <summary>
        /// 
        /// </summary>
        protected PokemonGoApiClient Client;

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public static DateTime LastRequestUtc { get; internal set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        protected ClientBase(PokemonGoApiClient client)
        {
            Client = client;
        }

        #endregion

    }

}