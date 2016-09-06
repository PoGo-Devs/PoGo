using PoGo.ApiClient.Interfaces;
using System;
using Windows.Devices.Sensors;

namespace PoGo.GameServices.Signature.iOS
{

    /// <summary>
    /// 
    /// </summary>
    public class iOSSensorInfo : ISensorInfo
    {

        #region Private Members

        private readonly Random random = new Random();

        private readonly Accelerometer accelerometer = Accelerometer.GetDefault();

        private readonly Magnetometer magnetometer = Magnetometer.GetDefault();

        private readonly Gyrometer gyrometer = Gyrometer.GetDefault();

        private readonly Inclinometer inclinometer = Inclinometer.GetDefault();

        #endregion

        #region Public Methods

        public ulong AccelerometerAxes => 3;

        public double AccelRawX => accelerometer?.GetCurrentReading()?.AccelerationX ?? random.NextGaussian(0.0, 0.3);

        public double AccelRawY => accelerometer?.GetCurrentReading()?.AccelerationY ?? random.NextGaussian(0.0, 0.3);

        public double AccelRawZ => accelerometer?.GetCurrentReading()?.AccelerationZ ?? random.NextGaussian(0.0, 0.3);

        public double AngleNormalizedX => inclinometer?.GetCurrentReading()?.PitchDegrees ?? random.NextGaussian(0.0, 5.0);

        public double AngleNormalizedY => inclinometer?.GetCurrentReading()?.YawDegrees ?? random.NextGaussian(0.0, 5.0);

        public double AngleNormalizedZ => inclinometer?.GetCurrentReading()?.RollDegrees ?? random.NextGaussian(0.0, 5.0);

        public double GyroscopeRawX => gyrometer?.GetCurrentReading()?.AngularVelocityX ?? random.NextGaussian(0.0, 0.1);

        public double GyroscopeRawY => gyrometer?.GetCurrentReading()?.AngularVelocityY ?? random.NextGaussian(0.0, 0.1);

        public double GyroscopeRawZ => gyrometer?.GetCurrentReading()?.AngularVelocityZ ?? random.NextGaussian(0.0, 0.1);

        public double MagnetometerX => magnetometer?.GetCurrentReading()?.MagneticFieldX ?? random.NextGaussian(0.0, 0.1);

        public double MagnetometerY => magnetometer?.GetCurrentReading()?.MagneticFieldY ?? random.NextGaussian(0.0, 0.1);

        public double MagnetometerZ => magnetometer?.GetCurrentReading()?.MagneticFieldZ ?? random.NextGaussian(0.0, 0.1);

        #endregion

    }

}