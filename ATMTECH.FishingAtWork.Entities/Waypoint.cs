using System;
using System.Collections.Generic;
using ATMTECH.Entities;


namespace ATMTECH.FishingAtWork.Entities
{
    public partial class Waypoint : BaseEntity
    {
        public const string TRIP = "Trip";

        public Player Player { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Lure Lure { get; set; }
        public int Deep { get; set; }
        public Trip Trip { get; set; }
        public EnumWaypointTechniqueType Technique { get; set; }
        public bool IsCurrentWayPoint { get; set; }
        public IList<WaypointCoordinate> WaypointCoordinates { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

}
