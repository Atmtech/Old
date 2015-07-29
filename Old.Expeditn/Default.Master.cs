using System;
using System.Data.SqlTypes;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;
using Subgurim.Controles;

namespace ATMTECH.Expeditn.WebSite
{
    //public partial class Default : PageMaitreBase<PageMaitrePresenter, IPageMaitrePresenter>, IPageMaitrePresenter
    //{
    //    public bool ThrowExceptionIfNoPresenterBound { get; set; }

    //    protected void Page_Load(object sender, EventArgs e)
    //    {
    //        lblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly()
    //                                          .GetName()
    //                                          .Version
    //                                          .ToString();

    //        //string key = "";

    //        //GDirection direction = new GDirection();
    //        //direction.autoGenerate = false;
    //        //direction.buttonElementId = "bt_Go";
    //        //direction.fromElementId = tb_fromPoint.ClientID;
    //        //direction.toElementId = tb_endPoint.ClientID;
    //        //direction.divElementId = "div_directions";
    //        //direction.clearMap = true;

    //        ////direction.avoidHighways = true;
    //        ////direction.travelMode = GDirection.GTravelModeEnum.G_TRAVEL_MODE_WALKING;
    //        ////direction.locale = "en";
    //        //GMap1.enableStore = true;
    //        //GMap1.Add(direction);

    //        //GDirection direction = new GDirection(true);
    //        //direction.autoGenerate = true;
    //        //direction.buttonElementId = "Test";
    //        //direction.fromText = "46.703026, -71.287632";
    //        //direction.toText = "46.708645, -71.291787";
    //        ////direction.fromElementId = tb_fromPoint.ClientID;
    //        ////direction.toElementId = tb_endPoint.ClientID;
    //        ////direction.divElementId = "div_directions";
    //        //direction.clearMap = true;
    //        //direction.

            

    //        //GeoCode geocode = GMap.geoCodeRequest("TEST", key, new GLatLngBounds(new GLatLng(40, 10), new GLatLng(50, 20)));



    //        //GMap1.addControl(new GControl(GControl.preBuilt.GOverviewMapControl));
    //        //GMap1.addControl(new GControl(GControl.preBuilt.LargeMapControl));

    //        //GMarker marker = new GMarker(new GLatLng(39.5, -3.2));
    //        //GInfoWindow window = new GInfoWindow(marker, "<center><b>GoogleMaps.Subgurim.NET</b></center>", true);

    //        //GMap1.addInfoWindow(window);
    //    }

    //    protected void btnIdentificationClick(object sender, EventArgs e)
    //    {
    //        Presenter.RedirigerIdentification();
    //    }

    //    public User Utilisateur
    //    {
    //        set
    //        {
    //            if (value == null)
    //            {
    //                pnlIdentification.Visible = true;
    //                pnlIdentifier.Visible = false;
    //                pnlDeconnecter.Visible = false;
    //            }
    //            else
    //            {
    //                pnlIdentification.Visible = false;
    //                UtilisateurIdentifier.Utilisateur = value;
    //                UtilisateurIdentifier.EstUtilisateurAuthentifie = true;
    //                pnlIdentifier.Visible = true;
    //                pnlDeconnecter.Visible = true;
    //            }

    //        }
    //    }

    //    protected void btnDeconnecterClick(object sender, EventArgs e)
    //    {
    //        Presenter.Deconnecter();
    //    }

    //    protected void btnTestGoogleMapClick(object sender, EventArgs e)
    //    {
    //        Presenter.TestGoogleMap();
    //    }
 //   }
}