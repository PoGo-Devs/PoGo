using Google.Protobuf;
using PoGo.ApiClient.Authentication;
using PoGo.ApiClient.Enums;
using PoGo.ApiClient.Interfaces;
using POGOProtos.Networking.Envelopes;
using POGOProtos.Networking.Requests;
using System;
using System.Linq;
using static POGOProtos.Networking.Envelopes.RequestEnvelope.Types;

namespace PoGo.ApiClient.Helpers
{

    /// <summary>
    /// 
    /// </summary>
    public class RequestBuilder
    {

        #region Private Members

        private readonly Random _random = new Random();
        private static byte[] _sessionHash = null;

        /// <summary>
        /// 
        /// </summary>
        private AuthenticatedUser AuthenticatedUser { get; }

        /// <summary>
        /// 
        /// </summary>
        private GeoCoordinate CurrentPosition { get; }

        /// <summary>
        /// 
        /// </summary>
        private IDeviceProfile DeviceProfile { get; }

        /// <summary>
        /// 
        /// </summary>
        private DateTimeOffset StartTime { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authUser"></param>
        /// <param name="position"></param>
        /// <param name="deviceProfile"></param>
        /// <param name="startTime"></param>
        /// <remarks>
        /// @robertmclaws: We're not tracking teh start time in this class internally because we're resetting the PokemonGoApiClient with
        /// every login, so the startTime shoudl be the time from last reset.
        /// </remarks>
        public RequestBuilder(AuthenticatedUser authUser, GeoCoordinate position, IDeviceProfile deviceProfile, DateTimeOffset startTime)
        {
            AuthenticatedUser = authUser;
            CurrentPosition = position;
            DeviceProfile = deviceProfile;
            StartTime = startTime;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customRequests"></param>
        /// <returns></returns>
        public RequestEnvelope GetInitialRequestEnvelope(params Request[] customRequests)
        {
            return SetRequestEnvelopeUnknown6(new RequestEnvelope
            {
                StatusCode = 2, //1
                // @robertmclaws to do: This needs to be generated, not static
                RequestId = 1469378659230941192, //3
                Requests = { customRequests }, //4

                //Unknown6 = , //6
                Latitude = CurrentPosition.Latitude, //7
                Longitude = CurrentPosition.Longitude, //8
                Accuracy = CurrentPosition.Accuracy, //9
                AuthInfo = new AuthInfo
                {
                    Provider = AuthenticatedUser.ProviderType == AuthenticationProviderTypes.Google ? "google" : "ptc",
                    Token = new AuthInfo.Types.JWT
                    {
                        Contents = AuthenticatedUser.AccessToken,
                        Unknown2 = 14
                    }
                }, //10
                // @robertmclaws to do: This needs to be generated, not static
                MsSinceLastLocationfix = _random.Next(500, 1000) //12
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customRequests"></param>
        /// <returns></returns>
        public RequestEnvelope GetRequestEnvelope(params Request[] customRequests)
        {
            return SetRequestEnvelopeUnknown6(new RequestEnvelope
            {
                StatusCode = 2, //1
                // @robertmclaws to do: This needs to be generated, not static
                RequestId = 1469378659230941192, //3
                Requests = {customRequests}, //4

                //Unknown6 = , //6
                Latitude = CurrentPosition.Latitude, //7
                Longitude = CurrentPosition.Longitude, //8
                Accuracy = CurrentPosition.Accuracy, //9
                AuthTicket = AuthenticatedUser.AuthTicket, //11
                // @robertmclaws to do: This needs to be generated, not static
                MsSinceLastLocationfix = _random.Next(500, 1000) //12
            });
        }

        #endregion

        #region Private Methods


        internal RequestEnvelope SetRequestEnvelopeUnknown6(RequestEnvelope requestEnvelope)
        {

            if (_sessionHash == null)
            {
                _sessionHash = new byte[32];
                _random.NextBytes(_sessionHash);
            }

            byte[] authSeed = requestEnvelope.AuthTicket != null ?
                requestEnvelope.AuthTicket.ToByteArray() :
                requestEnvelope.AuthInfo.ToByteArray();


            var normAccel = new Vector(DeviceProfile.Sensors.AccelRawX, DeviceProfile.Sensors.AccelRawY, DeviceProfile.Sensors.AccelRawZ);
            normAccel.NormalizeVector(1.0f);//1.0f on iOS, 9.81 on Android?

            var sig = new Signature
            {
                LocationHash1 = Utils.GenerateLocation1(authSeed, requestEnvelope.Latitude, requestEnvelope.Longitude, requestEnvelope.Accuracy),
                LocationHash2 = Utils.GenerateLocation2(requestEnvelope.Latitude, requestEnvelope.Longitude, requestEnvelope.Accuracy),
                SessionHash = ByteString.CopyFrom(_sessionHash),
                Unknown25 = DeviceProfile.VersionData.VersionHash,
                Timestamp = (ulong)DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                TimestampSinceStart = GetRelativeTimeFromStart(),
                SensorInfo = new Signature.Types.SensorInfo
                {
                    LinearAccelerationX = normAccel.X,
                    LinearAccelerationY = normAccel.Y,
                    LinearAccelerationZ = normAccel.Z,
                    AccelRawX = -DeviceProfile.Sensors.AccelRawX,
                    AccelRawY = -DeviceProfile.Sensors.AccelRawY,
                    AccelRawZ = -DeviceProfile.Sensors.AccelRawZ,
                    MagnetometerX = DeviceProfile.Sensors.MagnetometerX,
                    MagnetometerY = DeviceProfile.Sensors.MagnetometerY,
                    MagnetometerZ = DeviceProfile.Sensors.MagnetometerZ,
                    GyroscopeRawX = DeviceProfile.Sensors.GyroscopeRawX,
                    GyroscopeRawY = DeviceProfile.Sensors.GyroscopeRawY,
                    GyroscopeRawZ = DeviceProfile.Sensors.GyroscopeRawZ,
                    AngleNormalizedX = DeviceProfile.Sensors.AngleNormalizedX,
                    AngleNormalizedY = DeviceProfile.Sensors.AngleNormalizedY,
                    AngleNormalizedZ = DeviceProfile.Sensors.AngleNormalizedZ,
                    AccelerometerAxes = DeviceProfile.Sensors.AccelerometerAxes,
                    TimestampSnapshot = GetRelativeTimeFromStart() - (ulong)_random.Next(150, 260)
                },
                DeviceInfo = new Signature.Types.DeviceInfo
                {
                    DeviceId = DeviceProfile.DeviceId,
                    AndroidBoardName = DeviceProfile.AndroidBoardName,
                    AndroidBootloader = DeviceProfile.AndroidBootloader,
                    DeviceBrand = DeviceProfile.DeviceBrand,
                    DeviceModel = DeviceProfile.DeviceModel,
                    DeviceModelBoot = DeviceProfile.DeviceModelBoot,
                    DeviceModelIdentifier = DeviceProfile.DeviceModelIdentifier,
                    FirmwareFingerprint = DeviceProfile.FirmwareFingerprint,
                    FirmwareTags = DeviceProfile.FirmwareTags,
                    HardwareManufacturer = DeviceProfile.HardwareManufacturer,
                    HardwareModel = DeviceProfile.HardwareModel,
                    FirmwareBrand = DeviceProfile.FirmwareBrand,
                    FirmwareType = DeviceProfile.FirmwareType
                },

                ActivityStatus = DeviceProfile.ActivityStatus != null ? new Signature.Types.ActivityStatus()
                {
                    Walking = DeviceProfile.ActivityStatus.Walking,
                    Automotive = DeviceProfile.ActivityStatus.Automotive,
                    Cycling = DeviceProfile.ActivityStatus.Cycling,
                    Running = DeviceProfile.ActivityStatus.Running,
                    Stationary = DeviceProfile.ActivityStatus.Stationary,
                    Tilting = DeviceProfile.ActivityStatus.Tilting,
                }
                : null
            };


            if (DeviceProfile.GpsSatellitesInfo.Length > 0)
            {
                sig.GpsInfo = new Signature.Types.AndroidGpsInfo();
                //sig.GpsInfo.TimeToFix //currently not filled

                DeviceProfile.GpsSatellitesInfo.ToList().ForEach(sat =>
                {
                    sig.GpsInfo.Azimuth.Add(sat.Azimuth);
                    sig.GpsInfo.Elevation.Add(sat.Elevation);
                    sig.GpsInfo.HasAlmanac.Add(sat.Almanac);
                    sig.GpsInfo.HasEphemeris.Add(sat.Emphasis);
                    sig.GpsInfo.SatellitesPrn.Add(sat.SattelitesPrn);
                    sig.GpsInfo.Snr.Add(sat.Snr);
                    sig.GpsInfo.UsedInFix.Add(sat.UsedInFix);
                });
            }

            DeviceProfile.LocationFixes.ToList().ForEach(loc => sig.LocationFix.Add(new Signature.Types.LocationFix
            {
                Floor = loc.Floor,
                Longitude = loc.Longitude,
                Latitude = loc.Latitude,
                Altitude = loc.Altitude,
                LocationType = loc.LocationType,
                Provider = loc.Provider,
                ProviderStatus = loc.ProviderStatus,
                HorizontalAccuracy = loc.HorizontalAccuracy,
                VerticalAccuracy = loc.VerticalAccuracy,
                Course = loc.Course,
                Speed = loc.Speed,
                TimestampSnapshot = loc.TimeSnapshot

            }));

            foreach (var request in requestEnvelope.Requests)
            {
                sig.RequestHash.Add(Utils.GenerateRequestHash(authSeed, request.ToByteArray()));
            }

            requestEnvelope.Unknown6 = new Unknown6
            {
                RequestType = 6,
                Unknown2 = new Unknown6.Types.Unknown2
                {
                    EncryptedSignature = ByteString.CopyFrom(Crypt.Encrypt(sig.ToByteArray()))
                }
            };

            return requestEnvelope;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ulong GetRelativeTimeFromStart()
        {
            return (ulong)(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - StartTime.ToUnixTimeMilliseconds());
        }

        #endregion

    }

}