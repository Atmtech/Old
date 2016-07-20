using ATMTECH.Views;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.CalculPeche.Views.Base
{
    public class BaseCalculPechePresenter<TView> : BasePresenter<TView> where TView : class, IViewBase
    {
        public IParameterService ParameterService { get; set; }
        public string CurrentLanguage { get { return LocalizationService.CurrentLanguage; } }

        public BaseCalculPechePresenter(TView view)
            : base(view)
        {
        }

    }
}
