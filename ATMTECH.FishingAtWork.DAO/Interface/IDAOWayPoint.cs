using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOWayPoint
    {
        Waypoint GetWayPoint(int id);
        IList<Waypoint> GetWayPoint(Trip trip);
        int AddWaypoint(Waypoint waypoint);

        IList<Waypoint> GetWaypointList(Trip trip, string parametreTrie, int nbEnreg, int indexDebutRangee);
        int GetWaypointCount(Trip trip);
        int UpdateWaypoint(Waypoint waypoint);
    }
}
