using ATMTECH.Entities;
using ATMTECH.Scrum.Views.Base;
using ATMTECH.Scrum.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Scrum.Views
{
    public class LoginPresenter : BaseScrumPresenter<ILoginPresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }
        public LoginPresenter(ILoginPresenter view)
            : base(view)
        {
        }

        public void SignIn()
        {
            User user = AuthenticationService.SignIn(View.UserName, View.Password);
            View.IsLogged = user != null;
        }
    }
}
