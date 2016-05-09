using System.Collections;
using System.Collections.Generic;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.FishingAtWork.Services
{
    public class WaypointService : BaseService, IWaypointService
    {
        public IDAOWayPoint DAOWaypoint { get; set; }
        public IDAOWayPointCoordinate DAOWayPointCoordinate { get; set; }

        public Waypoint GetWaypoint(int id)
        {
            return DAOWaypoint.GetWayPoint(id);
        }

        private void SaveWaypointCoordinate(WaypointCoordinate waypointCoordinate, int x, int y, Waypoint waypoint)
        {
            if (waypointCoordinate != null)
            {
                waypointCoordinate.Waypoint = waypoint;
                waypointCoordinate.X = x;
                waypointCoordinate.Y = y;
            }
            else
            {
                WaypointCoordinate waypointCoordinateNew = new WaypointCoordinate();
                waypointCoordinateNew.Waypoint = waypoint;
                waypointCoordinateNew.X = waypoint.X;
                waypointCoordinateNew.Y = waypoint.Y;
                DAOWayPointCoordinate.SaveWaypointCoordinate(waypointCoordinateNew);
            }

        }

        private void GenerateWaypointCoordinate(IList<WaypointCoordinate> waypointCoordinates, Waypoint waypoint)
        {
            // le facteur de 20 devra être réévaluer selon l'achat de skill on verra.

            const int factor = 20;
            if (waypointCoordinates.Count > 0)
            {
                SaveWaypointCoordinate(waypointCoordinates[0], waypoint.X, waypoint.Y, waypoint);
                SaveWaypointCoordinate(waypointCoordinates[1], waypoint.X, waypoint.Y + factor, waypoint);
                SaveWaypointCoordinate(waypointCoordinates[2], waypoint.X + factor, waypoint.Y + factor, waypoint);
                SaveWaypointCoordinate(waypointCoordinates[3], waypoint.X + factor, waypoint.Y, waypoint);
            }
            else
            {
                SaveWaypointCoordinate(null, waypoint.X, waypoint.Y, waypoint);
                SaveWaypointCoordinate(null, waypoint.X, waypoint.Y + factor, waypoint);
                SaveWaypointCoordinate(null, waypoint.X + factor, waypoint.Y + factor, waypoint);
                SaveWaypointCoordinate(null, waypoint.X + factor, waypoint.Y, waypoint);
            }
        }

        public void UpdateWaypoint(Waypoint waypoint)
        {

            DAOWaypoint.UpdateWaypoint(waypoint);
            IList<WaypointCoordinate> waypointCoordinates = DAOWayPointCoordinate.GetWaypointCoordinate(waypoint);

            GenerateWaypointCoordinate(waypointCoordinates, waypoint);


        }
        public int AddWaypoint(Waypoint waypoint)
        {
            //validation
            // Create area
            return DAOWaypoint.AddWaypoint(waypoint);
        }

        public int GetNumberOfWayPoint(Trip trip)
        {
            return trip.Waypoints.Count;
        }

        public IList<Waypoint> GetWaypointList(Trip trip, string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            return DAOWaypoint.GetWaypointList(trip, parametreTrie, nbEnreg, indexDebutRangee);
        }

        public int GetWaypointCount(Trip trip)
        {
            return DAOWaypoint.GetWaypointCount(trip);
        }
    }
}
