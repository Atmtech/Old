using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Web.Services
{
    public class GoogleMapService : BaseService, IGoogleMapService
    {
        //public GeocodingResponse Rechercher(string adresse)
        //{
        //    GeocodingRequest request = new GeocodingRequest();
        //    request.Address = adresse;
        //    request.Sensor = "false";
        //    GeocodingResponse geocodingResponse = GeocodingService.GetResponse(request);
        //    return geocodingResponse;
        //}

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
}
