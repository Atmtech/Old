//using System;
//using System.Collections.Generic;
//using ATMTECH.Entities;
//using ATMTECH.FishingAtWork.Entities;
//using ATMTECH.FishingAtWork.Entities.DTO;
//using ATMTECH.FishingAtWork.Views;
//using ATMTECH.FishingAtWork.Views.Interface;
//using ATMTECH.FishingAtWork.Views.Pages;
//using ATMTECH.FishingAtWork.WebSite.Base;

//namespace ATMTECH.FishingAtWork.WebSite
//{
//    public partial class NewTrip : PageBaseFishingAtWork, INewTripPresenter
//    {
//        public NewTripPresenter Presenter { get; set; }

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                Presenter.OnViewInitialized();
//            }
//            Presenter.OnViewLoaded();
//        }

//        public IList<Entities.Site> SiteList
//        {
//            set
//            {
//                ddlSite.DataSource = value;
//                ddlSite.DataTextField = Entities.Site.NAME;
//                ddlSite.DataValueField = BaseEntity.ID;
//                ddlSite.DataBind();
//            }
//        }

//        public IList<Lure> LureList
//        {
//            set
//            {
//                ddlLure.DataSource = value;
//                ddlLure.DataTextField = Lure.NAME;
//                ddlLure.DataValueField = BaseEntity.ID;
//                ddlLure.DataBind();
//            }
//        }

//        public IList<int> DeepList
//        {
//            set
//            {
//                ddlDeep.DataSource = value;
//                ddlDeep.DataBind();
//            }
//        }

//        public IList<EnumWaypointTechniqueType> EnumWaypointTechniqueTypesList
//        {
//            set
//            {
//                ddlTechnique.DataSource = value;
//                ddlTechnique.DataTextField = BaseEntity.DESCRIPTION;
//                ddlTechnique.DataValueField = BaseEntity.ID;
//                ddlTechnique.DataBind();
//            }
//        }

//        public IList<string> HourList
//        {
//            set
//            {
//                ddlTimeEnd.DataSource = value;
//                ddlTimeEnd.DataBind();

//                ddlTimeStart.DataSource = value;
//                ddlTimeStart.DataBind();
//            }
//        }

//        public int TripId
//        {
//            get
//            {
//                return (int)Session["TripId"];
//            }
//            set { Session["TripId"] = value; }
//        }

//        public int SelectedSiteId
//        {
//            get { return Convert.ToInt32(ddlSite.SelectedValue); }
//        }

//        public int SelectedLureId
//        {
//            get { return Convert.ToInt32(ddlLure.SelectedValue); }
//        }

//        public int SelectedTechnique
//        {
//            get { return Convert.ToInt32(ddlTechnique.SelectedValue); }
//        }

//        public string HourStart
//        {
//            get { return ddlTimeStart.SelectedValue; }
//        }

//        public string HourEnd
//        {
//            get { return ddlTimeEnd.SelectedValue; }
//        }

//        public int SelectedDeep
//        {
//            get { return Convert.ToInt32(ddlDeep.SelectedValue); }
//        }

//        public GoogleMapValue GoogleMapValue
//        {
//            get { return googleMap.GoogleMapValue; }
//            set
//            {
//                txtLatitude.Text = value.LatitudeClicked.ToString();
//                txtLongitude.Text = value.LongitudeClicked.ToString();
//                txtPixelX.Text = value.X.ToString();
//                txtPixelY.Text = value.Y.ToString();

//                googleMap.Latitude = value.Latitude;
//                googleMap.Longitude = value.Longitude;
//                googleMap.Zoom = value.Zoom;

//                if (value.GoogleMapMarkers != null)
//                {
//                    if (value.GoogleMapMarkers.Count != 0)
//                    {
//                        foreach (GoogleMapMarker googleMapMarker in value.GoogleMapMarkers)
//                        {
//                            googleMap.AddMarker(googleMapMarker);
//                        }
//                    }
//                }

//                googleMap.SetPosition();
//            }
//        }

//        public GoogleMapValue GoogleMapValueResume
//        {
//            get { return googleMapResume.GoogleMapValue; }
//            set
//            {
//                googleMapResume.Latitude = value.Latitude;
//                googleMapResume.Longitude = value.Longitude;
//                googleMapResume.Zoom = value.Zoom;

//                if (value.GoogleMapMarkers.Count != 0)
//                {
//                    foreach (GoogleMapMarker googleMapMarker in value.GoogleMapMarkers)
//                    {
//                        googleMapResume.AddMarker(googleMapMarker);
//                    }
//                }
//                googleMapResume.SetPosition();
//            }
//        }

//        public int CurrentWayPoint
//        {
//            get { return Convert.ToInt32(lblCurrentWayPoint.Text); }
//            set { lblCurrentWayPoint.Text = value.ToString(); }
//        }

//        public int MaximumWayPoint
//        {
//            get { return Convert.ToInt32(lblMaximumWayPoint.Text); }
//            set { lblMaximumWayPoint.Text = value.ToString(); }
//        }

//        public bool IsVisibleStep1
//        {
//            get { return pnlStep1.Visible; }
//            set { pnlStep1.Visible = value; }
//        }

//        public bool IsVisibleStep2
//        {
//            get { return pnlStep2.Visible; }
//            set { pnlStep2.Visible = value; }
//        }

//        public bool IsVisibleStep3
//        {
//            get { return pnlStep3.Visible; }
//            set { pnlStep3.Visible = value; }
//        }

//        public bool IsVisibleStep4
//        {
//            get { return pnlStep4.Visible; }
//            set { pnlStep4.Visible = value; }
//        }

//        public bool IsAddWayPointVisible
//        {
//            get { return btnAddWayPoint2.Visible; }
//            set { btnAddWayPoint2.Visible = value; }
//        }


//        public string Name
//        {
//            get { return txtName.Text; }
//            set { txtName.Text = value; }
//        }

//        public DateTime DateStart
//        {
//            get { return txtDateStart.ValeurDateTime; }
//            set { txtDateStart.ValeurDateTime = value; }
//        }

//        protected void WaypointClick(object sender, EventArgs e)
//        {
//            Presenter.Save();
//        }

//        protected void FinishClick(object sender, EventArgs e)
//        {
//            Presenter.Finish();
//        }

//        protected void CancelClick(object sender, EventArgs e)
//        {
//            Presenter.NavigationService.Redirect(Pages.DEFAULT);
//        }

//        protected void ResumeClick(object sender, EventArgs e)
//        {
//            Presenter.Resume();
//        }

//    }
//}