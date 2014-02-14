using System;
using System.Web.UI.WebControls;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Views;
using ATMTECH.FishingAtWork.Views.Interface;
using ATMTECH.FishingAtWork.WebSite.Base;

namespace ATMTECH.FishingAtWork.WebSite
{
    public partial class AdminSite : PageBaseFishingAtWork, IAdminSitePresenter
    {
        public AdminSitePresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();

        }

        protected void RowCommandClick(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "OpenSite")
            {
                Presenter.OpenSite(Convert.ToInt32(e.CommandArgument));
            }
        }

        public GoogleMapValue GoogleMapValue
        {
            get { return googleMap.GoogleMapValue; }
            set
            {
                pnlSite.Visible = true;
                googleMap.Latitude = value.Latitude;
                googleMap.Longitude = value.Longitude;
                googleMap.Zoom = value.Zoom;
                googleMap.SetPosition();
            }
        }

    }
}