using System;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Views;
using ATMTECH.FishingAtWork.Views.Interface;
using ATMTECH.FishingAtWork.WebSite.Base;

namespace ATMTECH.FishingAtWork.WebSite
{
    public partial class AdminDefault : PageBaseFishingAtWork, IDefaultPresenter
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