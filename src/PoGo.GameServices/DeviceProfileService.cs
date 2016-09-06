using PoGo.ApiClient.Interfaces;
using PoGo.GameServices.Signature.iPhone;
using System;

namespace PoGo.GameServices
{

    /// <summary>
    /// Handles managing Device Profiles for signature creation.
    /// </summary>
    public class DeviceProfileService
    {

        #region Private Members

        #endregion

        #region Properties

        /// <summary>
        /// The devices provile currently being used by the API.
        /// </summary>
        public IDeviceProfile CurrentDevice { get; }

        /// <summary>
        /// The <see cref="LocationService"/> injected by the DI container to be used by this instance of the <see cref="DeviceProfileService"/>.
        /// </summary>
        private LocationService LocationService { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationService"></param>
        public DeviceProfileService(LocationService locationService)
        {
            LocationService = locationService;
            CurrentDevice = CurrentDevice ?? new iOSDeviceProfile();
        }

        #endregion

    }
}
