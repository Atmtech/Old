//using System;
//using ATMTECH.FishingAtWork.Entities;
//using ATMTECH.FishingAtWork.Entities.DTO;
//using ATMTECH.FishingAtWork.Views;
//using ATMTECH.FishingAtWork.Views.Interface;
//using ATMTECH.FishingAtWork.Views.Pages;
//using ATMTECH.FishingAtWork.WebSite.Base;

//namespace ATMTECH.FishingAtWork.WebSite
//{
//    public partial class Default1 : PageBaseFishingAtWork, IDefaultPresenter
//    {
//        public DefaultPresenter Presenter { get; set; }

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                Presenter.OnViewInitialized();
//            }
//            Presenter.OnViewLoaded();

//        }


//        public GoogleMapValue GoogleMapValue
//        {
//            get { return googleMap.GoogleMapValue; }
//            set
//            {
//                if (value != null)
//                {
//                    googleMap.Latitude = value.Latitude;
//                    googleMap.Longitude = value.Longitude;
//                    googleMap.Zoom = value.Zoom;

//                    if (value.GoogleMapMarkers != null)
//                    {
//                        if (value.GoogleMapMarkers.Count != 0)
//                        {
//                            foreach (GoogleMapMarker googleMapMarker in value.GoogleMapMarkers)
//                            {
//                                googleMap.AddMarker(googleMapMarker);
//                            }
//                        }
//                    }

//                    googleMap.SetPosition();
//                }
//            }
//        }

//        public Trip CurrentTrip
//        {
//            get { return (Trip)ViewState["CurrentTrip"]; }
//            set
//            {
//                if (value != null)
//                {
//                    pnlCurrentTrip.Visible = true;
//                    txtName.Text = value.Name;
//                    txtSite.Text = value.Site.Name;
//                }
//                else
//                {
//                    pnlCurrentTrip.Visible = false;

//                }
//            }
//        }

//        public bool IsLogged
//        {
//            get { return pnlHomeUnlogged.Visible; }
//            set
//            {
//                if (value)
//                {
//                    pnlHomeUnlogged.Visible = false;
//                }
//                else
//                {
//                    pnlHomeUnlogged.Visible = true;
//                }
                
//            }
//        }

//        public bool IsPanelCurrentTrip
//        {
//            get { return pnlCurrentTrip.Visible; }
//            set { pnlCurrentTrip.Visible = value; }
//        }

//        public bool IsPanelNoTrip
//        {
//            get { return pnlNoTrip.Visible; }
//            set { pnlNoTrip.Visible = value; }
//        }

//        public int TotalPlayerOnTrip
//        {
//            get { return Convert.ToInt32(txtTotalPlayer.Text); }
//            set { txtTotalPlayer.Text = value.ToString(); }
//        }

//        protected void CreateTripClick(object sender, EventArgs e)
//        {
//            Presenter.NavigationService.Redirect(Pages.NEW_TRIP);
//        }
//    }
//}