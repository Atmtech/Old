using System;
using System.Collections;
using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Views.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class NewTripPresenter : BaseFishingAtWorkPresenter<INewTripPresenter>
    {
        public ISiteService SiteService { get; set; }
        public ITripService TripService { get; set; }
        public IPlayerService PlayerService { get; set; }
        public IPlayerLureService PlayerLureService { get; set; }
        public IWaypointService WaypointService { get; set; }
        public IEnumService<EnumWaypointTechniqueType> EnumService { get; set; }
        public ILureService LureService { get; set; }

        public NewTripPresenter(INewTripPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.SiteList = SiteService.GetSiteList();
            View.LureList = PlayerLureService.GetLureList(PlayerService.AuthenticatePlayer);
            View.EnumWaypointTechniqueTypesList = EnumService.GetList();
            View.HourList = Utils.Hour.GetHourList();
        }

        private GoogleMapValue SetGoogleMapValue(Waypoint waypoint)
        {
            GoogleMapValue googleMapValue = new GoogleMapValue() { Trip = CurrentTrip };
            return googleMapValue.SetGoogleMapValue(waypoint);
        }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            if (View.GoogleMapValue.LatitudeClicked != 0)
            {
                View.GoogleMapValue = SetGoogleMapValue(GetCurrentWayPoint());

                if (View.CurrentWayPoint == View.MaximumWayPoint)
                {
                    View.IsAddWayPointVisible = false;
                }

                DisplaySaveWaypoint();
            }
        }
        public void Save()
        {

            if (View.GoogleMapValue.LatitudeClicked != 0)
            {
                WaypointService.AddWaypoint(GetCurrentWayPoint());
                DisplaySelectWaypoint();
                View.GoogleMapValue = SetGoogleMapValue(null);
                View.GoogleMapValue.LatitudeClicked = 0;
            }
            else
            {
                SaveTrip();
                View.GoogleMapValue = SetGoogleMapValue(null);
                DisplaySelectWaypoint();
                View.DeepList = SiteService.GetSite(View.SelectedSiteId).DeepList;
            }
        }
        public void Finish()
        {
            NavigationService.Redirect(Pages.Pages.DEFAULT);
        }
        private void DisplaySaveWaypoint()
        {
            View.IsVisibleStep1 = false;
            View.IsVisibleStep2 = false;
            View.IsVisibleStep3 = true;
        }
        private Waypoint GetCurrentWayPoint()
        {
            Trip trip = CurrentTrip;
            Player player = PlayerService.AuthenticatePlayer;

            View.CurrentWayPoint = WaypointService.GetNumberOfWayPoint(trip) + 1;
            View.MaximumWayPoint = player.MaximumWaypoint;

            Waypoint waypoint = new Waypoint();
            waypoint.X = View.GoogleMapValue.X;
            waypoint.Y = View.GoogleMapValue.Y;
            waypoint.Latitude = View.GoogleMapValue.LatitudeClicked;
            waypoint.Longitude = View.GoogleMapValue.LongitudeClicked;
            waypoint.Player = player;
            waypoint.DateStart = Convert.ToDateTime((trip.DateStart.ToShortDateString() + " " + View.HourStart));
            waypoint.DateEnd = Convert.ToDateTime((trip.DateEnd.ToShortDateString() + " " + View.HourEnd));
            waypoint.Lure = LureService.GetLure(View.SelectedLureId);
            waypoint.Deep = View.SelectedDeep;
            waypoint.Technique = EnumService.GetEnum(View.SelectedTechnique);
            waypoint.Trip = trip;
            return waypoint;
        }
        private Trip CurrentTrip
        {
            get
            {
                return TripService.GetTrip(View.TripId);
            }
        }
        private void DisplaySelectWaypoint()
        {
            View.IsVisibleStep1 = false;
            View.IsVisibleStep2 = true;
            View.IsVisibleStep3 = false;
        }

        private void SaveTrip()
        {
            Trip trip = new Trip();
            trip.Site = SiteService.GetSite(View.SelectedSiteId);
            trip.Name = View.Name;
            trip.DateStart = View.DateStart;
            trip.DateEnd = trip.DateStart.AddDays(1);
            trip.Player = PlayerService.AuthenticatePlayer;
            View.TripId = TripService.SaveTrip(trip);
        }

        public void Resume()
        {
            Save();
            View.GoogleMapValueResume = SetGoogleMapValue(null);
            View.IsVisibleStep1 = false;
            View.IsVisibleStep2 = false;
            View.IsVisibleStep3 = false;
            View.IsVisibleStep4 = true;
        }
    }
}
