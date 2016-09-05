using PoGo.ApiClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoGo.GameServices.Signature.iOS
{

    /// <summary>
    /// 
    /// </summary>
    public class iOSActivityStatus : IActivityStatus
    {

        #region Private Members

        private const double stationaryMax = 0.2;   // .44 MPH (to account for GPS drift)
        private const double tiltingMax = 0.33528;  // 3/4 MPH
        private const double walkingMax = 3;  // 6.7 MPH
        private const double runningMax = 6;  // 13.4 MPH
        private const double cyclingMax = 15;   // 33 MPH, this is the speed when the "driving" dialog pops up.

        public bool Walking
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Automotive
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Cycling
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Running
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Stationary
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool Tilting
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Properties

        //public bool Automotive => GameClient.Geoposition?.Coordinate?.Speed > cyclingMax;

        //public bool Cycling => GameClient.Geoposition?.Coordinate?.Speed > runningMax && GameClient.Geoposition.Coordinate?.Speed <= cyclingMax;

        //public bool Running => GameClient.Geoposition?.Coordinate?.Speed > walkingMax && GameClient.Geoposition.Coordinate?.Speed <= runningMax;

        //public bool Stationary => GameClient.Geoposition?.Coordinate?.Speed <= stationaryMax;

        //public bool Tilting => GameClient.Geoposition?.Coordinate?.Speed > stationaryMax && GameClient.Geoposition.Coordinate?.Speed <= tiltingMax;

        //public bool Walking => GameClient.Geoposition?.Coordinate?.Speed > tiltingMax && GameClient.Geoposition.Coordinate?.Speed <= walkingMax;

        #endregion

    }

}