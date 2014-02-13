using ATMTECH.Entities;
using ATMTECH.Views;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Administration.Views.Base
{
    public class BaseAdministrationPresenter<TView> : BasePresenter<TView> where TView : class, IViewBase
    {
        public IAuthenticationService AuthenticationService { get; set; }

        public BaseAdministrationPresenter(TView view)
            : base(view)
        {
        }
      
    }
}
