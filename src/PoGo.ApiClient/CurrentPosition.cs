using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoGo.ApiClient
{

    /// <summary>
    /// Describes a GPS reading.
    /// </summary>
    public class GeoCoordinate
    {

        /// <summary>
        /// 
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Accuracy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="accuracy"></param>
        public GeoCoordinate(double latitude, double longitude, double accuracy)
        {
            Latitude = latitude;
            Longitude = longitude;
            Accuracy = accuracy;
        }

    }

}