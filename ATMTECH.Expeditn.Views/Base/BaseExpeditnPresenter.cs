using ATMTECH.Views;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Expeditn.Views.Base
{
    public class BaseExpeditnPresenter<TView> : BasePresenter<TView> where TView : class, IViewBase
    {
        public IParameterService ParameterService { get; set; }
        public string CurrentLanguage { get { return LocalizationService.CurrentLanguage; } }

        public BaseExpeditnPresenter(TView view)
            : base(view)
        {
        }

    }
}
