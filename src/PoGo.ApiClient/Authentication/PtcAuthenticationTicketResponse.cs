using System.Collections.Generic;

namespace PoGo.ApiClient.Authentication
{
    internal class PtcAuthenticationTicketResponse : PtcAuthenticationParameters
    {

        /// <summary>
        /// A list of errors returned from the Authentication request.
        /// </summary>
        public List<string> Errors { get; set; }

    }

}