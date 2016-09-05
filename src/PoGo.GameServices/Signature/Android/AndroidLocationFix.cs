using PoGo.ApiClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoGo.GameServices.Signature.Android
{
    public class AndroidLocationFix : ILocationFix
    {

        #region Private Members

        private static readonly Random _random = new Random();

        #endregion

        #region Properties

        public float Altitude { get; private set; }

        public float Course { get; private set; }

        public uint Floor { get; private set; }

        public float HorizontalAccuracy { get; private set; }

        public float Latitude { get; private set; }

        public ulong LocationType { get; private set; }

        public float Longitude { get; private set; }

        public string Provider { get; private set; }

        public ulong ProviderStatus { get; private set; }

        public float Speed { get; private set; }

        public long TimeSnapshot { get; private set; }

        public float VerticalAccuracy { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public AndroidLocationFix()
        {
        }

        #endregion

        #region Public Methods

        public static ILocationFix CollectData()
        {
            if (GameClient.Geoposition.Coordinate == null)
                return null; //Nothing to collect

            var loc = new AndroidLocationFix();
            //Collect provider
            switch (GameClient.Geoposition.Coordinate.PositionSource)
            {
                case Windows.Devices.Geolocation.PositionSource.WiFi:
                case Windows.Devices.Geolocation.PositionSource.Cellular:
                    loc.Provider = "network"; break;
                case Windows.Devices.Geolocation.PositionSource.Satellite:
                    loc.Provider = "gps"; break;
                default:
                    loc.Provider = "fused"; break;
            }

            //1 = no fix, 2 = acquiring/inaccurate, 3 = fix acquired
            loc.ProviderStatus = 3;

            //Collect coordinates

            loc.Latitude = (float)GameClient.Geoposition.Coordinate.Point.Position.Latitude;
            loc.Longitude = (float)GameClient.Geoposition.Coordinate.Point.Position.Longitude;
            loc.Altitude = (float)GameClient.Geoposition.Coordinate.Point.Position.Altitude;

            // TODO: why 3? need more info.
            loc.Floor = 3;

            // TODO: why 1? need more info.
            loc.LocationType = 1;

            loc.TimeSnapshot = DeviceInfoManager.RelativeTimeFromStart;

            loc.HorizontalAccuracy = (float?)GameClient.Geoposition.Coordinate?.SatelliteData.HorizontalDilutionOfPrecision ?? (float)Math.Floor((float)_random.NextGaussian(1.0, 1.0)); //better would be exp distribution
            loc.VerticalAccuracy = (float?)GameClient.Geoposition.Coordinate?.SatelliteData.VerticalDilutionOfPrecision ?? (float)Math.Floor((float)_random.NextGaussian(1.0, 1.0)); //better would be exp distribution

            return loc;
        }

        #endregion

    }

}