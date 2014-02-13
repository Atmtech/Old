using ATMTECH.Template.Views.Base;
using ATMTECH.Template.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Template.Views
{
    public class DefaultPresenter : BaseTemplatePresenter<IDefaultPresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }

        public DefaultPresenter(IDefaultPresenter view)
            : base(view)
        {
        }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            AuthenticationService.SignIn("riov01", "test");
            
        }

    }
}
