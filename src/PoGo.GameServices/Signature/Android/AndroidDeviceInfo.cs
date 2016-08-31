using PoGo.ApiClient.Interfaces;
using POGOProtos.Enums;
using System;
using System.Collections.Generic;

namespace PoGo.GameServices.Signature.Android
{
    public class AndroidDeviceInfo : IDeviceInfo
    {

        #region Private Members

        private object gpsLocationFixesLock = new object();

        private List<IGpsSatellitesInfo> gpsSatellitesInfo = new List<IGpsSatellitesInfo>();

        private object gpsSatellitesInfoLock = new object();

        private List<ILocationFix> locationFixes = new List<ILocationFix>();

        private AndroidSensorInfo sensors = new AndroidSensorInfo();

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// @wallycz: Activity status is not filled on Android.
        /// </remarks>
        public IActivityStatus ActivityStatus => null;

        public string AndroidBoardName => "shamu";

        public string AndroidBootloader => "moto-apq8084-71.15";

        public string DeviceBrand => "google";

        public string DeviceId
        {
            get
            {
                //if (string.IsNullOrEmpty(SettingsService.Instance.AndroidDeviceID))
                //{
                //    SettingsService.Instance.AndroidDeviceID = Utilities.RandomHex(16);
                //}
                //return SettingsService.Instance.AndroidDeviceID;
                return null;
            }
        }

        public string DeviceModel => "shamu";

        public string DeviceModelBoot => "shamu";

        public string DeviceModelIdentifier => "MRA58R";

        public string FirmwareBrand => "shamu";

        public string FirmwareFingerprint => "google/shamu/shamu:6.0/MRA58R/2308909:user/release-keys";

        public string FirmwareTags => "release-keys";

        public string FirmwareType => "user";

        public IGpsSatellitesInfo[] GpsSatellitesInfo
        {
            get
            {
                lock (gpsSatellitesInfoLock)
                {
                    gpsSatellitesInfo.Clear();
                    //if (GameClient.Geoposition?.Coordinate?.SatelliteData != null)
                    //{
                    //    //cant find API for this in UWP
                    //    //so mwhere to get that data? emulate? is there some service or algorithm for get GPS sattelites info?
                    //}

                    return gpsSatellitesInfo.ToArray();
                }
            }
        }

        public string HardwareManufacturer => "motorola";

        public string HardwareModel => "Nexus 6";

        public ILocationFix[] LocationFixes
        {
            get
            {
                lock (gpsLocationFixesLock)
                {
                    //atomically exchange lists (new is empty)
                    List<ILocationFix> data = locationFixes;
                    locationFixes = new List<ILocationFix>();
                    return data.ToArray();
                }
            }
        }

        public Platform Platform => Platform.Android;

        public ISensorInfo Sensors => sensors;

        public long TimeSnapshot => DeviceInfoManager.RelativeTimeFromStart;

        public int Version => 3300;

        #endregion

        #region Constructors

        public AndroidDeviceInfo()
        {
        }

        #endregion

        public void CollectLocationData()
        {
            throw new NotImplementedException();
        }
    }
}
