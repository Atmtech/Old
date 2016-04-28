using System.Collections.Generic;

namespace ATMTECH.FishingAtWork.Entities.DTO
{
    public class GoogleMapValue
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double LatitudeClicked { get; set; }
        public double LongitudeClicked { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Zoom { get; set; }
        public IList<GoogleMapMarker> GoogleMapMarkers { get; set; }

        public Trip Trip { get; set; }

        public GoogleMapValue SetGoogleMapValue(Waypoint waypoint)
        {
            Trip trip = Trip;
            GoogleMapValue googleMapValue = new GoogleMapValue
                                                {
                                                    Latitude = trip.Site.Latitude,
                                                    Longitude = trip.Site.Longitude,
                                                    Zoom = trip.Site.Zoom
                                                };

            if (waypoint != null)
            {
                googleMapValue.LatitudeClicked = waypoint.Latitude;
                googleMapValue.LongitudeClicked = waypoint.Longitude;
                googleMapValue.X = waypoint.X;
                googleMapValue.Y = waypoint.Y;
            }

            IList<GoogleMapMarker> googleMapMarkers = new List<GoogleMapMarker>();
            int bulletToUse = 1;
            foreach (Waypoint waypoint1 in Trip.Waypoints)
            {
                GoogleMapMarker googleMapMarker = new GoogleMapMarker()
                {
                    Information = ExtractWayPointInformation(waypoint1),
                    Icon = "/Images/Main/BulletWayPoint" + bulletToUse + ".png",
                    Latitude = waypoint1.Latitude,
                    Longitude = waypoint1.Longitude
                };
                bulletToUse += 1;
                googleMapMarkers.Add(googleMapMarker);
            }
            googleMapValue.GoogleMapMarkers = googleMapMarkers;
            return googleMapValue;
        }

        public GoogleMapValue SetGoogleMapValue(Site site)
        {
            GoogleMapValue googleMapValue = new GoogleMapValue
            {
                Latitude = site.Latitude,
                Longitude = site.Longitude,
                Zoom = site.Zoom
            };
            return googleMapValue;
        }


        private string ExtractWayPointInformation(Waypoint waypoint)
        {
            return string.Format("<table><tr><td>Leurre:</td><td>{4}</td></tr><tr><td>Technique:</td><td>{0}</td></tr><tr><td>Plage horaire</td><td>{1} à {2}</td></tr><tr><td>Profondeur:</td><td>{3}</td></tr><tr><td>Latitude:</td><td>{5}</td></tr><tr><td>Longitude:</td><td>{6}</td></tr></table>", waypoint.Technique.Description, waypoint.DateStart.ToShortTimeString(), waypoint.DateEnd.ToShortTimeString(), waypoint.Deep, waypoint.Lure.Name, waypoint.Latitude, waypoint.Longitude);
        }
    }
}