using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Tests.Builder
{
    public static class WaypointCoordinateBuilder
    {
        public static WaypointCoordinate Create()
        {
            return new WaypointCoordinate();
        }

        public static WaypointCoordinate WithWaypoint(this WaypointCoordinate waypointCoordinate, Waypoint waypoint)
        {
            waypointCoordinate.Waypoint = waypoint;
            return waypointCoordinate;
        }

        public static WaypointCoordinate WithX(this WaypointCoordinate waypointCoordinate, double x)
        {
            waypointCoordinate.X = x;
            return waypointCoordinate;
        }
        public static WaypointCoordinate WithY(this WaypointCoordinate waypointCoordinate, double y)
        {
            waypointCoordinate.Y = y;
            return waypointCoordinate;
        }


    }
}
