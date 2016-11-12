using System;

namespace PoGo.ApiClient.Exceptions
{

    /// <summary>
    /// 
    /// </summary>
    public class LoginFailedException : Exception
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public string LoginResponse { get; }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public LoginFailedException()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginResponse"></param>
        public LoginFailedException(string loginResponse)
        {
            LoginResponse = loginResponse;
        }

    }

}