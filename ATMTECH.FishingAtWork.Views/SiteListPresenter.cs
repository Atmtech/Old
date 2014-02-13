using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Views.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class SiteListPresenter : BaseFishingAtWorkPresenter<ISiteListPresenter>
    {
        public ISiteService SiteService { get; set; }
        public SiteListPresenter(ISiteListPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.SitesList = SiteService.GetSiteList();
        }

        public void GetInformation(int siteId)
        {
          View.SiteInformation =  SiteService.GetSite(siteId);
        }

        public void OpenSiteList()
        {
            NavigationService.Redirect(Pages.Pages.SITE_LIST);
        }
    }
}
