using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Views.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class AdminSitePresenter : BaseFishingAtWorkPresenter<IAdminSitePresenter>
    {
        public ISiteService SiteService { get; set; }
        public AdminSitePresenter(IAdminSitePresenter view)
            : base(view)
        {
        }

        public void OpenSite(int idSite)
        {
            Site site = SiteService.GetSite(idSite);
            GoogleMapValue googleMapValue = new GoogleMapValue();
            View.GoogleMapValue = googleMapValue.SetGoogleMapValue(site);
        }

        public IList<Site> GetSite(string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            return SiteService.GetSiteList();
        }

        public int GetSiteCount()
        {
            return SiteService.GetSiteList().Count;
        }
    }
}
