using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOWayPointCoordinate : BaseDao<WaypointCoordinate, int>, IDAOWayPointCoordinate
    {
        public IList<WaypointCoordinate> GetWaypointCoordinate(Waypoint waypoint)
        {
            return GetAllOneCriteria(WaypointCoordinate.WAYPOINT, waypoint.Id.ToString());
        }

        public void SaveWaypointCoordinate(WaypointCoordinate waypointCoordinate)
        {
            Save(waypointCoordinate);
        }
    }
}
