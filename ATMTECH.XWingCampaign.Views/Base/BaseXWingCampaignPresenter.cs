using ATMTECH.Views;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.XWingCampaign.Views.Base
{
    public class BaseXWingCampaignPresenter<TView> : BasePresenter<TView> where TView : class, IViewBase
    {
        public IParameterService ParameterService { get; set; }
        public string CurrentLanguage { get { return LocalizationService.CurrentLanguage; } }

        public BaseXWingCampaignPresenter(TView view)
            : base(view)
        {
        }

    }
}
