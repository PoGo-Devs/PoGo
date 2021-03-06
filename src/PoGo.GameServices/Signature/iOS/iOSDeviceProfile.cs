﻿using PoGo.ApiClient.Interfaces;
using POGOProtos.Enums;
using System;

namespace PoGo.GameServices.Signature.iPhone
{

    /// <summary>
    /// 
    /// </summary>
    class iOSDeviceProfile : IDeviceProfile
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

        public void CollectLocationData()
        {
            throw new NotImplementedException();
        }
    }
}
