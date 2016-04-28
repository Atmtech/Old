using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class WaypointCoordinate : BaseEntity
    {
        public const string WAYPOINT = "Waypoint";

        public Waypoint Waypoint { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
