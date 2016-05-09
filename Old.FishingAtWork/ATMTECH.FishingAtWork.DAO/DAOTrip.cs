using System;
using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOTrip : BaseDao<Trip, int>, IDAOTrip
    {
        public IDAOSite DAOSite { get; set; }
        public IDAOWayPoint DAOWaypoint { get; set; }
        public IDAOPlayer DAOPlayer { get; set; }


        public Trip GetTripToday(Player player)
        {
            Criteria criteria1 = new Criteria() { Column = Trip.DATE_START, Operator = DatabaseOperator.OPERATOR_LIKE, Value = DateTime.Now.ToShortDateString() };
            Criteria criteria2 = new Criteria() { Column = Trip.PLAYER, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = player.Id.ToString() };
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(criteria1);
            criterias.Add(criteria2);
            IList<Trip> trips = GetByCriteria(criterias);
            if (trips.Count > 0)
            {
                Trip trip = GetByCriteria(criterias)[0];
                return FillTrip(trip);
            }
            return null;
        }

        private Trip FillTrip(Trip trip)
        {
            if (trip != null)
            {
                trip.Site = DAOSite.GetSite(trip.Site.Id);
                trip.Waypoints = DAOWaypoint.GetWayPoint(trip);
                trip.Site.Waypoints = trip.Waypoints;
                trip.Player = DAOPlayer.GetPlayer(trip.Player.Id);
                foreach (Waypoint waypoint in trip.Waypoints)
                {
                    waypoint.Player = trip.Player;
                }
            }
            return trip;
        }
        public Trip GetTrip(int id)
        {
            Trip trip = GetById(id);
            return FillTrip(trip);
        }

        public int SaveTrip(Trip trip)
        {
            return Save(trip);
        }

        public IList<Trip> GetAllCurrentTrip()
        {
            Criteria criteria1 = new Criteria() { Column = Trip.DATE_START, Operator = DatabaseOperator.OPERATOR_LIKE, Value = DateTime.Now.ToShortDateString() };
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(criteria1);
            IList<Trip> trips = GetByCriteria(criterias);
            foreach (Trip trip in trips)
            {
                FillTrip(trip);
            }
            return trips;
        }

        public IList<Trip> GetTripList(Player player, string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            OrderOperation orderOperation = new OrderOperation() { OrderByColumn = BaseEntity.ID, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation() { PageIndex = indexDebutRangee, PageSize = nbEnreg };
            Criteria criteria = new Criteria() { Column = Trip.PLAYER, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = player.Id.ToString() };
            IList<Trip> test = GetAllOneCriteria(criteria, pagingOperation, orderOperation);
            foreach (Trip trip in test)
            {
                FillTrip(trip);
            }
            return test;
        }

        public IList<Trip> GetTripList(Player player)
        {
            return GetAllOneCriteria(Trip.PLAYER, player.Id.ToString());
        }

        public int GetTripCount(Player player)
        {
            return GetAllOneCriteria(Trip.PLAYER, player.Id.ToString()).Count;
        }
    }
}
