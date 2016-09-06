using System;

namespace PoGo.ApiClient.Interfaces
{

    public interface ISensorInfo
    {

        ulong AccelerometerAxes { get; }
        double AccelRawX { get; }
        double AccelRawY { get; }
        double AccelRawZ { get; }
        double MagnetometerX { get; }
        double MagnetometerY { get; }
        double MagnetometerZ { get; }
        double AngleNormalizedX { get; }
        double AngleNormalizedY { get; }
        double AngleNormalizedZ { get; }
        double GyroscopeRawX { get; }
        double GyroscopeRawY { get; }
        double GyroscopeRawZ { get; }

    }

}
