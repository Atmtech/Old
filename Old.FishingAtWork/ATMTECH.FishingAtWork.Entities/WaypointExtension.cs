using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities.DTO;


namespace ATMTECH.FishingAtWork.Entities
{
    public partial class Waypoint
    {
        public IList<Coordinate> Area
        {
            get
            {
                IList<Coordinate> area = new List<Coordinate>();
                foreach (WaypointCoordinate waypointCoordinate in WaypointCoordinates)
                {
                    area.Add(new Coordinate(waypointCoordinate.X, waypointCoordinate.Y));
                }

                return area;
            }
        }

        public string TechniqueName
        { get { return Technique.Description; } }
    }

}
