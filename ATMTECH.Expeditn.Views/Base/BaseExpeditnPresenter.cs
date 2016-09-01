using ATMTECH.Common.Context;
using ATMTECH.Views;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Expeditn.Views.Base
{
    public class BaseExpeditnPresenter<TView> : BasePresenter<TView> where TView : class, IViewBase
    {
        public IParameterService ParameterService { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }

        public string CurrentLanguage { get { return LocalizationService.CurrentLanguage; } }

        public BaseExpeditnPresenter(TView view)
            : base(view)
        {
        }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();

            string currentPage = Common.Utils.Web.Pages.GetCurrentPage().ToLower();
            if (currentPage == Pages.DEFAULT.ToLower()) return;
            if (currentPage == Pages.IDENTIFICATION.ToLower()) return;
            if (currentPage == Pages.INSCRIPTION.ToLower()) return;
            if (currentPage == Pages.VOIR_EXPEDITION.ToLower()) return;
            if (currentPage == Pages.POURQUOI.ToLower()) return;

            if (AuthenticationService != null)
            {
                if (AuthenticationService.AuthenticateUser == null)
                {
                    NavigationService.Redirect(Pages.DEFAULT);
                }    
            }
            
        }

    }
}
