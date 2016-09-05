using PoGo.ApiClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POGOProtos.Enums;

namespace PoGo.GameServices.Signature.iPhone
{
    class iOSDeviceInfo : IDeviceInfo
    {
        public IActivityStatus ActivityStatus
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string AndroidBoardName => "";

        public string AndroidBootloader => "";

        public string DeviceBrand => "Apple";

        public string DeviceId
        {
            get
            {
                //if (string.IsNullOrEmpty(SettingsService.Instance.Udid) || SettingsService.Instance.Udid.Length != 32)
                //{
                //    try
                //    {
                //        SettingsService.Instance.Udid = UdidGenerator.GenerateUdid().Substring(0, 32).ToLower();
                //    }
                //    catch (Exception)
                //    {
                //        //Fallback solution with random hex
                //        SettingsService.Instance.Udid = Utilities.RandomHex(32).ToLower();
                //    }
                //}
                //return SettingsService.Instance.Udid.ToLower();
                return null;
            }
        }

        public string DeviceModel => "iPhone";

        public string DeviceModelBoot => "iPhone6,1";

        public string DeviceModelIdentifier => "";

        public string FirmwareBrand => "iPhone OS";

        public string FirmwareFingerprint => "";

        public string FirmwareTags => "";

        public string FirmwareType => "9.3.3";

        public IGpsSatellitesInfo[] GpsSatellitesInfo
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string HardwareManufacturer => "Apple";

        public string HardwareModel => "N51AP";

        public ILocationFix[] LocationFixes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Platform Platform => Platform.Ios;

        public ISensorInfo Sensors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public long TimeSnapshot => DeviceInfoManager.RelativeTimeFromStart;

        public int Version => 3300;

        public void CollectLocationData()
        {
            throw new NotImplementedException();
        }
    }
}
