using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Services.Interface
{
    public interface IWaypointService
    {
        Waypoint GetWaypoint(int id);

        int AddWaypoint(Waypoint waypoint);
        void UpdateWaypoint(Waypoint waypoint);
        int GetNumberOfWayPoint(Trip trip);

        IList<Waypoint> GetWaypointList(Trip trip, string parametreTrie, int nbEnreg, int indexDebutRangee);
        int GetWaypointCount(Trip trip);

    }
}
