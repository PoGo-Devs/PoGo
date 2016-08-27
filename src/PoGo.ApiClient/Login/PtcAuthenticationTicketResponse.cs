using System.Collections.Generic;

namespace PoGo.ApiClient.Login
{
    internal class PtcAuthenticationTicketResponse : PtcLoginParameters
    {

        /// <summary>
        /// A list of errors returned from the Authentication request.
        /// </summary>
        public List<string> Errors { get; set; }

    }

}