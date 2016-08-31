namespace PoGo.ApiClient.Enums
{

    /// <summary>
    /// Represents the different status codes teh Pokemon Go API server can return.
    /// </summary>
    public enum StatusCodes : int
    {

        /// <summary>
        /// 
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Valid response with no ApiUrl
        /// </summary>
        ValidResponse = 1,

        /// <summary>
        /// the response envelope has api_url set and this response is valid
        /// </summary>
        ValidResponseWithUrl = 2,

        /// <summary>
        /// bad request
        /// </summary>
        AccessDenied = 3,

        /// <summary>
        /// Using unimplemented request or corrupt request
        /// </summary>
        InvalidRequest = 51,

        /// <summary>
        /// 
        /// </summary>
        ServerOverloaded = 52,

        /// <summary>
        /// A new rpc endpoint is available and you should redirect to there
        /// </summary>
        Redirect = 53,

        /// <summary>
        /// Occurs when you send blank authinfo, or sending nonsense timings (ie LocationFix.timestampSnapshot == Signature.timestampSinceStart)
        /// </summary>
        InvalidSession = 100,

        /// <summary>
        /// 
        /// </summary>
        InvalidToken = 102,

    }

}
