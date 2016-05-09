using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOWayPointCoordinate
    {
        IList<WaypointCoordinate> GetWaypointCoordinate(Waypoint waypoint);
        void SaveWaypointCoordinate(WaypointCoordinate waypointCoordinate);
    }
}
