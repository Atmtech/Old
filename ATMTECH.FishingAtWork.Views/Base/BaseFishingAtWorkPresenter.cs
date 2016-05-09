using ATMTECH.Views;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.FishingAtWork.Views.Base
{
    public class BaseFishingAtWorkPresenter<TView> : BasePresenter<TView> where TView : class, IViewBase
    {
        public IParameterService ParameterService { get; set; }
        public string CurrentLanguage { get { return LocalizationService.CurrentLanguage; } }

        public BaseFishingAtWorkPresenter(TView view)
            : base(view)
        {
        }

    }
}
