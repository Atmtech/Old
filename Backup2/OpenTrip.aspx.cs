using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ATMTECH.Entities;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Views;
using ATMTECH.FishingAtWork.Views.Interface;
using ATMTECH.FishingAtWork.Views.Pages;
using ATMTECH.FishingAtWork.WebSite.Base;

namespace ATMTECH.FishingAtWork.WebSite
{
    public partial class OpenTrip : PageBaseFishingAtWork, IOpenTripPresenter
    {
        public OpenTripPresenter Presenter { get; set; }

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
            if (e.CommandName == "OpenTrip")
            {
                Presenter.OpenTrip(e.CommandArgument);
            }
        }

        public bool IsPanelOpenSiteGridViewOpen
        {
            get { return pnlOpenTripGridView.Visible; }
            set { pnlOpenTripGridView.Visible = value; }
        }

        public bool IsPanelOpenSiteTripDetail
        {
            get { return pnlTripDetail.Visible; }
            set { pnlTripDetail.Visible = value; }
        }

        public bool IsPanelEditWayPoint
        {
            get { return pnlEditWayPoint.Visible; }
            set { pnlEditWayPoint.Visible = value; }
        }

        public bool IsPanelSelectWaypoint
        {
            get { return pnlSelectWaypoint.Visible; }
            set { pnlSelectWaypoint.Visible = value; }
        }

        public IList<Entities.Site> SiteList
        {
            set
            {
                ddlSite.DataSource = value;
                ddlSite.DataTextField = Entities.Site.NAME;
                ddlSite.DataValueField = BaseEntity.ID;
                ddlSite.DataBind();
            }
        }

        public IList<Lure> LureList
        {
            set
            {
                ddlLure.DataSource = value;
                ddlLure.DataTextField = Lure.NAME;
                ddlLure.DataValueField = BaseEntity.ID;
                ddlLure.DataBind();
            }
        }

        public IList<int> DeepList
        {
            set
            {
                ddlDeep.DataSource = value;
                ddlDeep.DataBind();
            }
        }

        public IList<EnumWaypointTechniqueType> EnumWaypointTechniqueTypesList
        {
            set
            {
                ddlTechnique.DataSource = value;
                ddlTechnique.DataTextField = BaseEntity.DESCRIPTION;
                ddlTechnique.DataValueField = BaseEntity.ID;
                ddlTechnique.DataBind();
            }
        }

        public IList<string> HourList
        {
            set
            {
                ddlTimeEnd.DataSource = value;
                ddlTimeEnd.DataBind();

                ddlTimeStart.DataSource = value;
                ddlTimeStart.DataBind();
            }
        }


        public int SiteSelectedValue
        {
            get { return Convert.ToInt32(ddlSite.SelectedValue); }
            set { ddlSite.SelectedValue = value.ToString(); }
        }

        public string Name
        {
            get { return txtName.Text; }
            set
            {
                txtName.Text = value;
                lblName.Text = value;
            }
        }

        public DateTime DateStart
        {
            get { return txtDateStart.ValeurDateTime; }
            set { txtDateStart.ValeurDateTime = value; }
        }

        public DateTime DateEnd
        {
            get { return txtDateEnd.ValeurDateTime; }
            set { txtDateEnd.ValeurDateTime = value; }
        }

        public string Waypoints
        {
            get { return txtWayPoint.Text; }
            set { txtWayPoint.Text = value; }
        }

        public int SelectedLureId
        {
            get { return Convert.ToInt32(ddlLure.SelectedValue); }
            set { ddlLure.SelectedValue = value.ToString(); }
        }

        public int SelectedTechnique
        {
            get { return Convert.ToInt32(ddlTechnique.SelectedValue); }
            set { ddlTechnique.SelectedValue = value.ToString(); }
        }

        public string HourStart
        {
            get { return ddlTimeStart.SelectedValue; }
            set { ddlTimeStart.SelectedValue = value.ToString(); }
        }

        public string HourEnd
        {
            get { return ddlTimeEnd.SelectedValue; }
            set { ddlTimeEnd.SelectedValue = value.ToString(); }
        }

        public int SelectedDeep
        {
            get { return Convert.ToInt32(ddlDeep.SelectedValue); }
            set { ddlDeep.SelectedValue = value.ToString(); }
        }

        public string Latitude
        {
            get { return txtLatitude.Text; }
            set { txtLatitude.Text = value; }
        }

        public string Longitude
        {
            get { return txtLongitude.Text; }
            set { txtLongitude.Text = value; }
        }

        public bool IsAddWaypointVisible
        {
            get { return btnAddWaypoint.Visible; }
            set { btnAddWaypoint.Visible = value; }
        }

        public GoogleMapValue googleMapValueThumbnail
        {
            get { return googleMapThumbnailWindow.GoogleMapValue; }
            set
            {
                googleMapThumbnailWindow.Latitude = value.Latitude;
                googleMapThumbnailWindow.Longitude = value.Longitude;
                googleMapThumbnailWindow.Zoom = value.Zoom;
                googleMapThumbnailWindow.SetPosition();

            }
        }

        public GoogleMapValue GoogleMapValue
        {
            get { return googleMap.GoogleMapValue; }
            set
            {
                txtLatitude.Text = value.LatitudeClicked.ToString();
                txtLongitude.Text = value.LongitudeClicked.ToString();
                txtPixelX.Text = value.X.ToString();
                txtPixelY.Text = value.Y.ToString();

                googleMap.Latitude = value.Latitude;
                googleMap.Longitude = value.Longitude;
                googleMap.Zoom = value.Zoom;


                if (value.GoogleMapMarkers != null)
                {
                    if (value.GoogleMapMarkers.Count != 0)
                    {
                        foreach (GoogleMapMarker googleMapMarker in value.GoogleMapMarkers)
                        {
                            googleMap.AddMarker(googleMapMarker);
                        }
                    }
                }

                googleMap.SetPosition();
            }
        }


        protected void CancelClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.OPEN_TRIP);
        }

        protected void SaveClick(object sender, EventArgs e)
        {
            Presenter.SaveTrip();
        }

        protected void WaypointRowCommandClick(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "OpenWaypoint")
            {
                Presenter.OpenWaypoint(e.CommandArgument);
            }
        }

        protected void ChangeWayPointClick(object sender, EventArgs e)
        {
            Presenter.ChangeWaypoint();
        }

        protected void SaveWaypointClick(object sender, EventArgs e)
        {
            Presenter.SaveWaypoint();
        }

        protected void CancelToWayPointClick(object sender, EventArgs e)
        {
            Presenter.CancelToWaypoint();
        }

        protected void AddWaypointClick(object sender, EventArgs e)
        {
            Presenter.AddWaypoint();
        }
    }
}