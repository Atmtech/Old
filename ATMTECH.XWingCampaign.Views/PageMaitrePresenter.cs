using ATMTECH.Web.Services.Interface;
using ATMTECH.XWingCampaign.Views.Base;
using ATMTECH.XWingCampaign.Views.Interface;

namespace ATMTECH.XWingCampaign.Views
{
    public class PageMaitrePresenter : BaseXWingCampaignPresenter<IPageMaitrePresenter>
    {
        public PageMaitrePresenter(IPageMaitrePresenter view)
            : base(view)
        {
        }

        public IAuthenticationService AuthenticationService { get; set; }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
        }
    }
}