using POGOProtos.Enums;
using System;

namespace PoGo.ApiClient.Interfaces
{

    public interface IDeviceProfile
    {
        string DeviceId { get; }
		string AndroidBoardName { get; }
        string AndroidBootloader { get; }
        string DeviceBrand { get; }
        string DeviceModel { get; }
        string DeviceModelIdentifier { get; }
        string DeviceModelBoot { get; }
        string HardwareManufacturer { get; }
        string HardwareModel { get; }
        string FirmwareBrand { get; }
        string FirmwareTags { get; }
        string FirmwareType { get; }
        string FirmwareFingerprint { get; }
        ILocationFix[] LocationFixes { get; }
        IGpsSatellitesInfo[] GpsSatellitesInfo { get; }
        ISensorInfo Sensors { get; }
        IActivityStatus ActivityStatus { get; }

        void CollectLocationData();
        Platform Platform { get; }

    }

}