using PoGo.ApiClient.Interfaces;

namespace PoGo.GameServices.Signature.iOS
{
    public class iOSLocationFix : ILocationFix
    {

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

    }

}
