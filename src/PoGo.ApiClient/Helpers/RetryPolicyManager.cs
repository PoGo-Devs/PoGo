using POGOProtos.Networking.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoGo.ApiClient.Helpers
{

    /// <summary>
    /// 
    /// </summary>
    public static class RetryPolicyManager
    {

        private static readonly Dictionary<RequestType, RetryPolicy> _retryPolicies = new Dictionary<RequestType, RetryPolicy>
        {
            { RequestType.PlayerUpdate, new RetryPolicy(1, 1, 11) },
            { RequestType.GetPlayer, new RetryPolicy(1, 1, 11) },
            { RequestType.GetInventory, new RetryPolicy(1, 1, 0) },
        };

        internal static RetryPolicy GetRetryPolicy(RequestType type)
        {
            return _retryPolicies.ContainsKey(type) ? _retryPolicies[type] : new RetryPolicy(1, 1, 0);
        }

    }
}
