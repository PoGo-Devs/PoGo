using System;

namespace PoGo.ApiClient.Interfaces
{

    /// <summary>
    /// 
    /// </summary>
    public interface ILocationFix
    {
        string Provider { get; }
        float Latitude { get; }
        float Longitude { get; }
        float Altitude { get; }
        uint Floor { get; }
        ulong LocationType { get; }
        ulong ProviderStatus { get; }
        long TimeSnapshot { get; }
        float HorizontalAccuracy { get; }
        float VerticalAccuracy { get; }
        float Course { get; }
        float Speed { get; }
    }

}