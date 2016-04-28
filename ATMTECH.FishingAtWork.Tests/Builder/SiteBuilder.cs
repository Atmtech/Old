using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Tests.Builder
{
    public static class SiteBuilder
    {
        public static Site Create()
        {
            return new Site();
        }
        public static Site WithDescription(this Site site, string description)
        {
            site.Description = description;
            return site;
        }
        public static Site WithWidth(this Site site, int width)
        {
            site.Width = width;
            return site;
        }

        public static Site WithLatitude(this Site site, double latitude)
        {
            site.Latitude = latitude;
            return site;
        }

        public static Site WithLongitude(this Site site, double longitude)
        {
            site.Longitude = longitude;
            return site;
        }

        public static Site WithZoom(this Site site, int zoom)
        {
            site.Zoom = zoom;
            return site;
        }


        public static Site WithMaxDeep(this Site site, int deep)
        {
            site.MaxDeep = deep;
            return site;
        }
        public static Site WithHeight(this Site site, int height)
        {
            site.Height = height;
            return site;
        }
        public static Site WithName(this Site site, string name)
        {
            site.Name = name;
            return site;
        }
        public static Site AddSiteSpecies(this Site site, SiteSpecies siteSpecies)
        {
            if (site.SiteSpecies == null)
            {
                site.SiteSpecies = new List<SiteSpecies>();
            }
            site.SiteSpecies.Add(siteSpecies);
            return site;
        }
        public static Site AddWayPoint(this Site site, Waypoint waypoint)
        {
            if (site.Waypoints == null)
            {
                site.Waypoints = new List<Waypoint>();
            }
            site.Waypoints.Add(waypoint);
            return site;
        }
        public static Site EnabledTournament(this Site site)
        {
            site.IsTournament = true;
            return site;
        }


        public static Site CreateValid()
        {
            Site site = new Site();
            site.WithName("Fleuve St-Laurent").WithDescription("Majestueux fleuve").WithLatitude(1).WithLongitude(2).
                WithZoom(10);
            return site;
        }
    }
}
