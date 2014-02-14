using System;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Views;
using ATMTECH.FishingAtWork.Views.Interface;
using ATMTECH.FishingAtWork.WebSite.Base;

namespace ATMTECH.FishingAtWork.WebSite
{
    public partial class Site : PageBaseFishingAtWork, IDefaultPresenter
    {
        public DefaultPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();

        }

        protected void btnSetClick(object sender, EventArgs e)
        {
            googleMapResume.Latitude = Convert.ToDouble(latitude.Text.Replace(".", ","));
            googleMapResume.Longitude = Convert.ToDouble(longitude.Text.Replace(".", ","));
            googleMapResume.SetPosition();
        }

        public GoogleMapValue GoogleMapValue { get; set; }

        public Trip CurrentTrip
        {
            get;
            set;
        }

        public bool IsPanelCurrentTrip
        {
            get;
            set;
        }

        public bool IsPanelNoTrip
        {
            get;
            set;
        }

        public int TotalPlayerOnTrip
        {
            get;
            set;
        }

        public bool IsLogged
        {
            get;
            set;
        }
    }
}