using ATMTECH.Achievement.Views.Base;
using ATMTECH.Achievement.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Achievement.Views
{
    public class DefaultPresenter : BaseAccomplissementPresenter<IDefaultPresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }

        public DefaultPresenter(IDefaultPresenter view)
            : base(view)
        {
        }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            AuthenticationService.SignIn("sagaan@hotmail.com", "test");

            if (AuthenticationService.AuthenticateUser != null)
            {
                NavigationService.Redirect(Pages.Pages.DISCUSSION);
            }
        }

        public void LoginPage()
        {
            NavigationService.Redirect(Pages.Pages.LOGIN);
        }
    }
}
