using System;

namespace PoGo.ApiClient.Interfaces
{

    /// <summary>
    /// 
    /// </summary>
    public interface IGpsSatellitesInfo
    {
        int SattelitesPrn { get; }
        float Azimuth { get; }
        float Elevation { get; }
        float Snr { get; }
        bool Almanac { get; }
        bool Emphasis { get; }
        bool UsedInFix { get; }
    }

}
