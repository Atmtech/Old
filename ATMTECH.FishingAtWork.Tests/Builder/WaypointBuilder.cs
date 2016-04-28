using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Tests.Builder
{
    public static class WaypointBuilder
    {
        public static Waypoint Create()
        {
            return new Waypoint();
        }

        public static Waypoint WithDescription(this Waypoint waypoint, string description)
        {
            waypoint.Description = description;
            return waypoint;
        }


        public static Waypoint WithLure(this Waypoint waypoint, Lure lure)
        {
            waypoint.Lure = lure;
            return waypoint;
        }


        public static Waypoint WithPlayer(this Waypoint waypoint, Player player)
        {
            waypoint.Player = player;
            return waypoint;
        }

        public static Waypoint WithLatitude(this Waypoint waypoint, double latitude)
        {
            waypoint.Latitude = latitude;
            return waypoint;
        }

        public static Waypoint WithLongitude(this Waypoint waypoint, double longitude)
        {
            waypoint.Longitude = longitude;
            return waypoint;
        }


        public static Waypoint WithDateStart(this Waypoint waypoint, DateTime dateStart)
        {
            waypoint.DateStart = dateStart;
            return waypoint;
        }
        public static Waypoint WithDateEnd(this Waypoint waypoint, DateTime dateEnd)
        {
            waypoint.DateEnd = dateEnd;
            return waypoint;
        }


        public static Waypoint WithSitePlayerCoordinate(this Waypoint waypoint, IList<WaypointCoordinate> waypointCoordinates)
        {
            waypoint.WaypointCoordinates = waypointCoordinates;
            return waypoint;
        }
        public static Waypoint WithTechnique(this Waypoint waypoint, EnumWaypointTechniqueType enumWaypointTechniqueType)
        {
            if (waypoint.Technique == null)
            {
                waypoint.Technique = new EnumWaypointTechniqueType();
            }

            waypoint.Technique = enumWaypointTechniqueType;
            return waypoint;
        }

        public static Waypoint AddWayPointCoordinate(this Waypoint waypoint, WaypointCoordinate waypointCoordinate)
        {
            if (waypoint.WaypointCoordinates == null)
            {
                waypoint.WaypointCoordinates = new List<WaypointCoordinate>();
            }
            waypoint.WaypointCoordinates.Add(waypointCoordinate);
            return waypoint;
        }

        public static Waypoint CreateValid()
        {
            return Create()
                .AddWayPointCoordinate(WaypointCoordinateBuilder.Create().WithX(3).WithY(2))
                .AddWayPointCoordinate(WaypointCoordinateBuilder.Create().WithX(3).WithY(3))
                .AddWayPointCoordinate(WaypointCoordinateBuilder.Create().WithX(4).WithY(3))
                .AddWayPointCoordinate(WaypointCoordinateBuilder.Create().WithX(4).WithY(2))
                .WithPlayer(PlayerBuilder.CreateValid())
                .WithDescription("Waypoint")
                .WithLatitude(46.8583851223629)
                .WithLongitude(-71.1500182231445)
                .WithDateEnd(Convert.ToDateTime("2012-01-02 10:00:00"))
                .WithDateStart(Convert.ToDateTime("2012-01-01 9:00:00"))
                .WithTechnique(new EnumWaypointTechniqueType() { Code = "TRAINE" });
        }
    }
}
