using System.Collections.Generic;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.GoogleMap;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Web.Services
{
    public class GoogleMapService : BaseService, IGoogleMapService
    {
        public IList<GoogleAdresse> Rechercher(string adresse)
        {
            GeocodingRequest request = new GeocodingRequest();
            request.Address = adresse;
            request.Sensor = "false";
            GeocodingResponse geocodingResponse = GeocodingService.GetResponse(request);
            IList<GoogleAdresse> retour = new List<GoogleAdresse>();
            foreach (GeocodingResult geocodingResult in geocodingResponse.Results)
            {
                retour.Add(new GoogleAdresse
                {
                    AdresseLongue = geocodingResult.FormattedAddress,
                    CodePostal = TrouverCodePostal(geocodingResult.Components)
                });
            }
            return retour;
        }


        private string TrouverCodePostal(AddressComponent[] components)
        {
            foreach (AddressComponent addressComponent in components)
            {
                if (addressComponent.Types[0].ToString() == "PostalCode")
                {
                    return addressComponent.ShortName.Replace(" ", "");
                }
            }
            return string.Empty;
        }
        //public void AfficherImage(string adresse, TypeCarteAffiche typeCarteAffiche)
        //{
        //    GeocodingResponse geocodingResponse = Rechercher(adresse);
        //    GeographicPosition geographicPosition = geocodingResponse.Results[0].Geometry.Location;
        //    var map = new StaticMap();
        //    map.Center = geographicPosition.Latitude + "," + geographicPosition.Longitude;
        //    //map.Zoom = zoomSlider.Value.ToString("0");
        //    map.Size = "332x332";
        //    map.Markers = map.Center;
        //    map.MapType = Enum.GetName(typeof(TypeCarteAffiche), typeCarteAffiche);
        //    map.Sensor = "false";
        //    Uri uri = map.ToUri();

        //   // new google.maps.DirectionsService();
        //    // var image = new BitmapImage();
        //    // image.BeginInit();
        //    // image.CacheOption = BitmapCacheOption.OnDemand;
        //    // image.UriSource = map.ToUri();
        //    //// image.DownloadFailed += new EventHandler<ExceptionEventArgs>(image_DownloadFailed);
        //    // image.EndInit();
        //    //image1.Source = image;
        //}
    }

    public enum TypeCarteAffiche
    {
        Satellite,
        roadmap,
        hybrid
    }

    public class GoogleAdresse
    {
        public string AdresseLongue { get; set; }
        public string CodePostal { get; set; }
    }
}
