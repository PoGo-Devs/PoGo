using System;

namespace PoGo.ApiClient.Interfaces
{

    public interface IActivityStatus
    {
        bool Walking { get; }
        bool Automotive { get; }
        bool Cycling { get; }
        bool Running { get; }
        bool Stationary { get; }
        bool Tilting { get; }
    }

}
