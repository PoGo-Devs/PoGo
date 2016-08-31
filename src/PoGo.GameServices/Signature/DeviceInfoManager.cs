using PoGo.ApiClient.Interfaces;
using PoGo.GameServices.Signature.iPhone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoGo.GameServices.Signature
{

    /// <summary>
    /// 
    /// </summary>
    public static class DeviceInfoManager
    {

        #region Private Members

        private static readonly DateTimeOffset startTime;

        #endregion

        #region Properties

        public static IDeviceInfo CurrentDevice { get; }

        /// <summary>
        /// 
        /// </summary>
        public static long RelativeTimeFromStart
        {
            get
            {
                return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - startTime.ToUnixTimeMilliseconds();
            }
        }

        #endregion

        #region Constructors

        static DeviceInfoManager()
        {
            startTime = DateTimeOffset.UtcNow;
            CurrentDevice = CurrentDevice ?? new iOSDeviceInfo();
        }

        #endregion

    }
}
