using System;
using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Tests.Builder
{
    public static class TripBuilder
    {
        public static Trip Create()
        {
            return new Trip();
        }

        public static Trip WithName(this Trip trip, string name)
        {
            trip.Name = name;
            return trip;
        }


        public static Trip WithPlayer(this Trip trip, Player player)
        {
            trip.Player = player;
            return trip;
        }

        public static Trip WithSite(this Trip trip, Site site)
        {
            trip.Site = site;
            return trip;
        }


        public static Trip WithDateStart(this Trip trip, DateTime start)
        {
            trip.DateStart = start;
            return trip;
        }

        public static Trip WithDateEnd(this Trip trip, DateTime end)
        {
            trip.DateEnd = end;
            return trip;
        }

        public static Trip AddWayPoint(this Trip trip, Waypoint waypoint)
        {
            if (trip.Waypoints == null)
            {
                trip.Waypoints = new List<Waypoint>();
            }
            trip.Waypoints.Add(waypoint);
            return trip;
        }

        public static Trip CreateValid()
        {

            DateTime date = Convert.ToDateTime((DateTime.Now.ToShortDateString())).AddHours(7);
            return
                Create()
                .WithName("Voyage " + SiteBuilder.CreateValid().Name)
                    .WithDateEnd(date.AddHours(20))
                    .WithDateStart(date)
                    .WithPlayer(PlayerBuilder.CreateValid())
                    .WithSite(SiteBuilder.CreateValid())
                    .AddWayPoint(WaypointBuilder.CreateValid());

        }
    }
}
