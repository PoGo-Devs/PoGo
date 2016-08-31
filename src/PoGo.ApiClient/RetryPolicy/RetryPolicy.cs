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
    public struct RetryPolicy
    {

        /// <summary>
        /// A 1-based integer indicating the number of times this operation can be retried.
        /// </summary>
        internal int MaxFailureAttempts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        internal int MaxRedirectAttempts { get; set; }

        /// <summary>
        /// The number of seconds the system should wait before retrying the operation.
        /// </summary>
        internal int DelayInSeconds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxFailureAttempts"></param>
        /// <param name="maxRedirectAttempts"></param>
        /// <param name="delayInSeconds"></param>
        public RetryPolicy(int maxFailureAttempts, int maxRedirectAttempts, int delayInSeconds)
        {
            MaxFailureAttempts = maxFailureAttempts;
            MaxRedirectAttempts = maxRedirectAttempts;
            DelayInSeconds = delayInSeconds;
        }

    }

}
