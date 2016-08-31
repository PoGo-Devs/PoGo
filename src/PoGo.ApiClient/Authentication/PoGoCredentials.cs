using PoGo.ApiClient.Enums;

namespace PoGo.ApiClient.Authentication
{

    /// <summary>
    /// 
    /// </summary>
    public class PoGoCredentials
    {

        /// <summary>
        /// 
        /// </summary>
        public AuthenticationProviderTypes AuthenticationProvider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Username { get; set; }


    }

}