using System;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services;
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
        public ICustomerService CustomerService { get; set; }

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
        public void CreateCustomer()
        {
            if (String.IsNullOrEmpty(View.EmailCreate))
            {
                MessageService.ThrowMessage(Web.Services.ErrorCode.ADM_CREATE_USER_MANDATORY);
            }

            if (String.IsNullOrEmpty(View.PasswordCreate))
            {
                MessageService.ThrowMessage(Web.Services.ErrorCode.ADM_CREATE_USER_MANDATORY);
            }

            if (View.PasswordCreate != View.PasswordConfirmation)
            {
                MessageService.ThrowMessage(ErrorCode.SC_PASSWORD_DONT_EQUAL_PASSWORD_CONFIRM);
            }
            User user = new User { FirstName = View.FirstNameCreate, LastName = View.LastNameCreate, Password = View.PasswordCreate, Login = View.EmailCreate, Email = View.EmailCreate };
            Customer customer = new Customer
            {
                User = user,
                Enterprise =
                    new Enterprise
                    {
                        Id = Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED))
                    }
            };
            if (CustomerService.CreateCustomer(customer))
            {
                MessageService.ThrowMessage(Web.Services.ErrorCode.ADM_CREATE_SUCCESS);
            }
        }


    }
}
