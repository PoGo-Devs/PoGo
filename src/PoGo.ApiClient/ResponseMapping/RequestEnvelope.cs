using System;
using System.Collections.Generic;

namespace POGOProtos.Networking.Envelopes
{
    public sealed partial class RequestEnvelope
    {

        /// <summary>
        /// 
        /// </summary>
        public List<Type> ExpectedResponseTypes { get; set; }

    }

}