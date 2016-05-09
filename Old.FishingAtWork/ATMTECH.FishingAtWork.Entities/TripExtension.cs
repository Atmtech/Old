using System;
using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public partial class Trip
    {
        public int WaypointCount
        {
            get
            {
                if (Waypoints != null)
                {
                    return Waypoints.Count;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
