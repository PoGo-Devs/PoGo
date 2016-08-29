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
        internal int MaxAttempts { get; set; }

        /// <summary>
        /// The number of seconds the system should wait before retrying the operation.
        /// </summary>
        internal int DelayInSeconds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxAttempts"></param>
        /// <param name="delayInSeconds"></param>
        public RetryPolicy(int maxAttempts, int delayInSeconds)
        {
            MaxAttempts = maxAttempts;
            DelayInSeconds = delayInSeconds;
        }

    }

}
