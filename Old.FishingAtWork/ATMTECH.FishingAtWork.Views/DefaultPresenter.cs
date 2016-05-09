using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Views.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class DefaultPresenter : BaseFishingAtWorkPresenter<IDefaultPresenter>
    {
        public ISiteService SiteService { get; set; }
        public IPlayerService PlayerService { get; set; }
        public ITripService TripService { get; set; }

        public DefaultPresenter(IDefaultPresenter view)
            : base(view)
        {
        }


        private GoogleMapValue SetGoogleMapValue(Waypoint waypoint)
        {
            Trip trip = CurrentTrip;
            if (trip != null)
            {
                GoogleMapValue googleMapValue = new GoogleMapValue() { Trip = trip };
                return googleMapValue.SetGoogleMapValue(waypoint);
            }
            return null;
        }


        private Trip CurrentTrip
        {
            get
            {
                if (PlayerService.AuthenticatePlayer != null)
                {
                    Trip trip = TripService.GetTripToday(PlayerService.AuthenticatePlayer);
                    View.CurrentTrip = trip;
                    if (trip != null)
                    {
                        View.IsPanelCurrentTrip = true;
                        View.IsPanelNoTrip = false;
                    }
                    else
                    {
                        View.IsPanelCurrentTrip = false;
                        View.IsPanelNoTrip = true;
                    }
                    return trip;
                }
                return null;
            }
        }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();

            if (PlayerService.AuthenticatePlayer == null)
            {
                View.IsLogged = false;
            }
            else
            {
                View.IsLogged = true;
            }

            if (CurrentTrip != null)
            {
                View.GoogleMapValue = SetGoogleMapValue(null);
                View.TotalPlayerOnTrip = SiteService.GetPlayerCountSite(CurrentTrip.Site);
            }

        }
    }
}
