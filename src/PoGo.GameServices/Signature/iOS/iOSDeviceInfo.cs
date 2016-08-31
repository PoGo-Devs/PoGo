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

        public string AndroidBoardName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string AndroidBootloader
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string DeviceBrand
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string DeviceId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string DeviceModel
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string DeviceModelBoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string DeviceModelIdentifier
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string FirmwareBrand
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string FirmwareFingerprint
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string FirmwareTags
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string FirmwareType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IGpsSatellitesInfo[] GpsSatellitesInfo
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string HardwareManufacturer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string HardwareModel
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ILocationFix[] LocationFixes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Platform Platform
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ISensorInfo Sensors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public long TimeSnapshot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Version
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
