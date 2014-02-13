using ATMTECH.Achievement.Views.Base;
using ATMTECH.Achievement.Views.Interface;
using ATMTECH.Entities;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Achievement.Views
{
    public class LoginPresenter : BaseAccomplissementPresenter<ILoginPresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }
        public IParameterService ParameterService { get; set; }


        public LoginPresenter(ILoginPresenter view)
            : base(view)
        {
        }

        public void FillData(User user)
        {
        }

        public void Redirect(string page)
        {
            NavigationService.Redirect(page);
        }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            FillData(AuthenticationService.AuthenticateUser);
        }
        public void SignIn(string homePage)
        {
            User user = AuthenticationService.SignIn(View.UserName, View.Password);
            if (user != null)
            {
                FillData(user);
                NavigationService.Redirect(homePage);
            }
        }

        public void SignOut(string homePage)
        {
            AuthenticationService.SignOut();
            NavigationService.Redirect(homePage);
        }



    }
}
