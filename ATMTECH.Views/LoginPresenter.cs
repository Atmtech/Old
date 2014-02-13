using ATMTECH.Entities;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Views
{
    public class LoginPresenter : BasePresenter<ILoginPresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }

        public LoginPresenter(ILoginPresenter view)
            : base(view)
        {
        }

        public void FillData(User user)
        {
            if (user != null)
            {
                View.FullName = user.FirstNameLastName;
                View.IsLogged = true;
                View.IsAdministrator = user.IsAdministrator;
            }
            else
            {
                View.IsLogged = false;
            }

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
