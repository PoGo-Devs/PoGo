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
        /// 
        /// </summary>
        Success = 1,

        /// <summary>
        /// 
        /// </summary>
        AccessDenied = 3,

        /// <summary>
        /// 
        /// </summary>
        ServerOverloaded = 52,

        /// <summary>
        /// 
        /// </summary>
        Redirect = 53,

        /// <summary>
        /// 
        /// </summary>
        InvalidToken = 102,

    }

}
