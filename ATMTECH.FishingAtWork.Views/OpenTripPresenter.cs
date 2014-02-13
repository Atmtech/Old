using System;
using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Views.Interface;
using ATMTECH.FishingAtWork.Views.Pages;
using ATMTECH.Web;

namespace ATMTECH.FishingAtWork.Views
{
    public class OpenTripPresenter : BaseFishingAtWorkPresenter<IOpenTripPresenter>
    {
        public ITripService TripService { get; set; }
        public IPlayerService PlayerService { get; set; }
        public ISiteService SiteService { get; set; }
        public IWaypointService WaypointService { get; set; }
        public IPlayerLureService PlayerLureService { get; set; }
        public IEnumService<EnumWaypointTechniqueType> EnumService { get; set; }
        public ILureService LureService { get; set; }

        public OpenTripPresenter(IOpenTripPresenter view)
            : base(view)
        {
        }
        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.LureList = PlayerLureService.GetLureList(PlayerService.AuthenticatePlayer);
            View.EnumWaypointTechniqueTypesList = EnumService.GetList();
            View.HourList = Utils.Hour.GetHourList();
        }
        public Waypoint CurrentWaypoint
        {
            get
            {
                return WaypointService.GetWaypoint(Convert.ToInt32(NavigationService.GetQueryStringValue(PagesQueryString.EDIT_WAYPOINT)));
            }
        }
        public Trip CurrentTrip
        {
            get
            {
                Trip trip = null;
                if (!String.IsNullOrEmpty(NavigationService.GetQueryStringValue(PagesQueryString.TRIP)))
                {
                    trip = TripService.GetTrip(Convert.ToInt32(NavigationService.GetQueryStringValue(PagesQueryString.TRIP)));
                }

                if (!String.IsNullOrEmpty(NavigationService.GetQueryStringValue(PagesQueryString.EDIT_WAYPOINT)))
                {
                    trip = WaypointService.GetWaypoint(Convert.ToInt32(NavigationService.GetQueryStringValue(PagesQueryString.EDIT_WAYPOINT))).Trip;
                    trip = TripService.GetTrip(trip.Id);
                }

                return trip;
            }
        }

        private void FillTripInformation()
        {
            Trip trip = CurrentTrip;

            View.SiteList = SiteService.GetSiteList();
            View.SiteSelectedValue = trip.Site.Id;
            View.Name = trip.Name;
            View.DateStart = trip.DateStart;
            View.DateEnd = trip.DateEnd;
            View.Waypoints = trip.WaypointCount + " / " + PlayerService.AuthenticatePlayer.MaximumWaypoint;

            View.googleMapValueThumbnail = SetGoogleMapValue(null);

            View.IsAddWaypointVisible = trip.WaypointCount != PlayerService.AuthenticatePlayer.MaximumWaypoint;
        }
        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            if (NavigationService.GetQueryStringValue(PagesQueryString.TRIP) == null)
            {
                if (NavigationService.GetQueryStringValue(PagesQueryString.EDIT_WAYPOINT) != null)
                {
                    if (View.GoogleMapValue.LatitudeClicked != 0)
                    {
                        View.GoogleMapValue = SetGoogleMapValue(SaveWaypoint());

                        View.IsPanelEditWayPoint = true;
                        View.IsPanelOpenSiteGridViewOpen = false;
                        View.IsPanelOpenSiteTripDetail = false;
                        View.IsPanelSelectWaypoint = false;
                    }
                    else
                    {
                        FillWaypointInformation();
                        View.IsPanelEditWayPoint = true;
                        View.IsPanelOpenSiteGridViewOpen = false;
                        View.IsPanelOpenSiteTripDetail = false;
                    }

                }
                else
                {
                    View.IsPanelEditWayPoint = false;
                    View.IsPanelOpenSiteGridViewOpen = true;
                    View.IsPanelOpenSiteTripDetail = false;
                }

            }
            else
            {
                FillTripInformation();
                View.IsPanelEditWayPoint = false;
                View.IsPanelOpenSiteGridViewOpen = false;
                View.IsPanelOpenSiteTripDetail = true;
            }



        }

        private void FillWaypointInformation()
        {
            int id = Convert.ToInt32(NavigationService.GetQueryStringValue(PagesQueryString.EDIT_WAYPOINT));
            Waypoint waypoint = WaypointService.GetWaypoint(id);
            Trip trip = TripService.GetTrip(waypoint.Trip.Id);
            View.DeepList = SiteService.GetSite(trip.Site.Id).DeepList;

            View.SelectedDeep = waypoint.Deep;
            View.SelectedLureId = waypoint.Lure.Id;
            View.SelectedTechnique = waypoint.Technique.Id;
            View.HourEnd = waypoint.DateEnd.ToShortTimeString();
            View.HourStart = waypoint.DateStart.ToShortTimeString();
            View.Latitude = waypoint.Latitude.ToString();
            View.Longitude = waypoint.Longitude.ToString();
        }

        public IList<Trip> GetTrip(string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            return TripService.GetTripList(PlayerService.AuthenticatePlayer, parametreTrie, nbEnreg, indexDebutRangee);
        }

        public int GetTripCount()
        {
            return TripService.GetTripCount(PlayerService.AuthenticatePlayer);
        }

        public IList<Waypoint> GetWaypoint(string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            return WaypointService.GetWaypointList(CurrentTrip, parametreTrie, nbEnreg, indexDebutRangee);
        }

        public int GetWaypointCount()
        {
            return WaypointService.GetWaypointCount(CurrentTrip);
        }

        public void OpenTrip(object commandArgument)
        {
            IList<QueryString> list = new List<QueryString>();
            list.Add(new QueryString(PagesQueryString.TRIP, commandArgument.ToString()));
            NavigationService.Redirect(Pages.Pages.OPEN_TRIP, list);
        }


        public void OpenWaypoint(object commandArgument)
        {
            IList<QueryString> list = new List<QueryString>();
            list.Add(new QueryString(PagesQueryString.EDIT_WAYPOINT, commandArgument.ToString()));
            NavigationService.Redirect(Pages.Pages.OPEN_TRIP, list);
        }

        public Waypoint SaveWaypoint()
        {
            Waypoint waypoint = GetCurrentWayPoint();
            waypoint.Id = Convert.ToInt32(NavigationService.GetQueryStringValue(PagesQueryString.EDIT_WAYPOINT));
            WaypointService.UpdateWaypoint(waypoint);
            return waypoint;
        }
        public void SaveTrip()
        {
            Trip trip = CurrentTrip;
            trip.DateEnd = View.DateEnd;
            trip.DateStart = View.DateStart;
            trip.Name = View.Name;
            trip.Site = SiteService.GetSite(View.SiteSelectedValue);
            TripService.SaveTrip(trip);
        }

        private GoogleMapValue SetGoogleMapValue(Waypoint waypoint)
        {
            GoogleMapValue googleMapValue = new GoogleMapValue() { Trip = CurrentTrip };
            return googleMapValue.SetGoogleMapValue(waypoint);
        }

        private Waypoint GetCurrentWayPoint()
        {
            Trip trip = CurrentTrip;
            Player player = PlayerService.AuthenticatePlayer;

            int id = Convert.ToInt32(NavigationService.GetQueryStringValue(PagesQueryString.EDIT_WAYPOINT));
            Waypoint waypoint = WaypointService.GetWaypoint(id);

            if (View.GoogleMapValue.LatitudeClicked != 0)
            {
                waypoint.X = View.GoogleMapValue.X;
                waypoint.Y = View.GoogleMapValue.Y;
                waypoint.Latitude = View.GoogleMapValue.LatitudeClicked;
                waypoint.Longitude = View.GoogleMapValue.LongitudeClicked;
            }

            waypoint.Player = player;
            waypoint.DateStart = Convert.ToDateTime((trip.DateStart.ToShortDateString() + " " + View.HourStart));
            waypoint.DateEnd = Convert.ToDateTime((trip.DateEnd.ToShortDateString() + " " + View.HourEnd));
            waypoint.Lure = LureService.GetLure(View.SelectedLureId);
            waypoint.Deep = View.SelectedDeep;
            waypoint.Technique = EnumService.GetEnum(View.SelectedTechnique);
            waypoint.Trip = trip;
            return waypoint;
        }

        public void ChangeWaypoint()
        {
            View.GoogleMapValue = SetGoogleMapValue(null);
            View.IsPanelEditWayPoint = false;
            View.IsPanelOpenSiteGridViewOpen = false;
            View.IsPanelOpenSiteTripDetail = false;
            View.IsPanelSelectWaypoint = true;
        }

        public void CancelToWaypoint()
        {
            IList<QueryString> list = new List<QueryString>();
            list.Add(new QueryString(PagesQueryString.TRIP, GetCurrentWayPoint().Trip.Id.ToString()));
            NavigationService.Redirect(Pages.Pages.OPEN_TRIP, list);
        }

        public void AddWaypoint()
        {

            Waypoint waypoint = new Waypoint();
            WaypointService.UpdateWaypoint(waypoint);

            View.GoogleMapValue = SetGoogleMapValue(null);
            View.IsPanelEditWayPoint = true;
            View.IsPanelOpenSiteGridViewOpen = false;
            View.IsPanelOpenSiteTripDetail = false;
            View.IsPanelSelectWaypoint = false;
        }
    }
}
