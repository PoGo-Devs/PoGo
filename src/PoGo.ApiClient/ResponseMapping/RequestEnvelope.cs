using System;
using System.Collections.Generic;

namespace POGOProtos.Networking.Envelopes
{
    public class ExtendedRequestEnvelope : RequestEnvelope
    {

        /// <summary>
        /// 
        /// </summary>
        public List<Type> ExpectedResponseTypes { get; set; }

    }

}