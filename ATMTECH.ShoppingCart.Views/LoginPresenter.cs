using System;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.Web.Services.Interface;
using ILoginPresenter = ATMTECH.ShoppingCart.Views.Interface.ILoginPresenter;

namespace ATMTECH.ShoppingCart.Views
{
    public class LoginPresenter : BaseShoppingCartPresenter<ILoginPresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }
        public IEnterpriseService EnterpriseService { get; set; }

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

            int idEnterprise = Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED));
            View.IsCreateCustomerPossible = EnterpriseService.GetEnterprise(idEnterprise).IsCreateCustomerPossible;
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
