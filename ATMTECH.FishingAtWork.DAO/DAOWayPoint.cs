using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOWayPoint : BaseDao<Waypoint, int>, IDAOWayPoint
    {
        public IDAOEnum<EnumWaypointTechniqueType> DAOEnumTechnique { get; set; }
        public IDAOLure DAOLure { get; set; }
        public IDAOWayPointCoordinate DAOWayPointCoordinate { get; set; }

        public Waypoint GetWayPoint(int id)
        {
            Waypoint waypoint = GetById(id);
            waypoint.Technique = DAOEnumTechnique.GetEnum(waypoint.Technique.Id);
            return waypoint;
        }

        public IList<Waypoint> GetWayPoint(Trip trip)
        {
            IList<Waypoint> waypoints = GetAllOneCriteria(Waypoint.TRIP, trip.Id.ToString());
            foreach (Waypoint waypoint in waypoints)
            {
                waypoint.WaypointCoordinates = DAOWayPointCoordinate.GetWaypointCoordinate(waypoint);
                waypoint.Lure = DAOLure.GetLure(waypoint.Lure.Id);
                waypoint.Technique = DAOEnumTechnique.GetEnum(waypoint.Technique.Id);
            }
            return waypoints;
        }

        public int AddWaypoint(Waypoint waypoint)
        {
            return Save(waypoint);
        }

        public IList<Waypoint> GetWaypointList(Trip trip, string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            OrderOperation orderOperation = new OrderOperation() { OrderByColumn = BaseEntity.ID, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation() { PageIndex = indexDebutRangee, PageSize = nbEnreg };
            Criteria criteria = new Criteria() { Column = Waypoint.TRIP, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = trip.Id.ToString() };

            IList<Waypoint> waypoints = GetAllOneCriteria(criteria, pagingOperation, orderOperation);
            foreach (Waypoint waypoint in waypoints)
            {
                waypoint.Lure = DAOLure.GetLure(waypoint.Lure.Id);
                waypoint.Technique = DAOEnumTechnique.GetEnum(waypoint.Technique.Id);
            }
            return waypoints;
        }

        public int GetWaypointCount(Trip trip)
        {
            return GetAllOneCriteria(Waypoint.TRIP, trip.Id.ToString()).Count;
        }

        public int UpdateWaypoint(Waypoint waypoint)
        {
            return Save(waypoint);
        }
    }
}
