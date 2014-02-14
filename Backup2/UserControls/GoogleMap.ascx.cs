using System;
using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities.DTO;
using Artem.Google.UI;

namespace ATMTECH.FishingAtWork.WebSite.UserControls
{
    public partial class GoogleMap : System.Web.UI.UserControl
    {
        public double Latitude
        {
            get
            {
                if (ViewState["Latitude"] != null)
                {
                    return (double)ViewState["Latitude"];
                }
                return 0;
            }
            set
            {
                ViewState["Latitude"] = value;
                SetPosition();
            }
        }
        public double Longitude
        {
            get
            {
                if (ViewState["Longitude"] != null)
                {
                    return (double)ViewState["Longitude"];
                }
                return 0;
            }
            set
            {
                ViewState["Longitude"] = value;
                SetPosition();
            }
        }
        public int Zoom
        {
            get
            {
                if (ViewState["Zoom"] != null)
                {
                    return (int)ViewState["Zoom"];
                }
                else
                {
                    return 0;
                }

            }
            set
            {
                ViewState["Zoom"] = value;
                SetPosition();
            }
        }
        public int PixelXClicked { get { return Convert.ToInt32(txtCoordinateMouseX.Text); } }
        public int PixelYClicked { get { return Convert.ToInt32(txtCoordinateMouseY.Text); } }
        public double LatitudeClicked { get { return Convert.ToDouble(txtLatitudeClicked.Text.Replace(".", ",")); } }
        public double LongitudeClicked { get { return Convert.ToDouble(txtLongitudeClicked.Text.Replace(".", ",")); } }

        private bool _isThumbnail;

        public bool IsThumbnail
        {
            get { return _isThumbnail; }
            set
            {
                _isThumbnail = value;
                if (!value) return;
                GoogleMapFishingAtWork.Width = 200;
                GoogleMapFishingAtWork.Height = 200;
            }
        }

        public GoogleMapValue GoogleMapValue
        {
            get
            {
                return new GoogleMapValue()
                {
                    Latitude = Latitude,
                    LatitudeClicked = LatitudeClicked,
                    Longitude = Longitude,
                    LongitudeClicked = LongitudeClicked,
                    X = PixelXClicked,
                    Y = PixelYClicked
                };
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void SetPosition()
        {
            GoogleMapFishingAtWork.Latitude = Latitude;
            GoogleMapFishingAtWork.Longitude = Longitude;
            GoogleMapFishingAtWork.Zoom = Zoom;
        }

        public void AddMarker(GoogleMapMarker googleMapMarker)
        {
            Marker marker = new Marker();
            marker.Position = new LatLng() { Latitude = googleMapMarker.Latitude, Longitude = googleMapMarker.Longitude };
            marker.Info = googleMapMarker.Information;
            marker.Icon = googleMapMarker.Icon;
            GoogleMapFishingAtWork.Markers.Add(marker);
        }

        public void AddPolygon()
        {
        //    var overlay = new Artem.Google.UI.Overlay

      //      Artem.Google.UI.Overlay

//            var myOptions = {
//    zoom: 2,
//    center: new google.maps.LatLng(25,25),
//    mapTypeId: google.maps.MapTypeId.ROADMAP
//};
//var map = new google.maps.Map(
//    document.getElementById("map"), 
//    myOptions
//);

//var overlay = new google.maps.OverlayView();
//overlay.draw = function() {};
//overlay.setMap(map);


//            var coordinates = overlay.getProjection().fromContainerPixelToLatLng(
//    new google.maps.Point(92, 61)
//);

           

            GooglePolygon googlePolygon = new GooglePolygon();
            googlePolygon.Paths.Add(new LatLng());
            GoogleMapFishingAtWork.Overlays.Add(googlePolygon);
        }
    }
}