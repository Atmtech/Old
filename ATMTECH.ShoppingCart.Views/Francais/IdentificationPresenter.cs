using System;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Views
{
    public class IdentificationPresenter : BaseShoppingCartPresenter<IIdentificationPresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }
        public ICustomerService CustomerService { get; set; }

        public IdentificationPresenter(IIdentificationPresenter view)
            : base(view)
        {
        }

        public void Identification()
        {
            User user = AuthenticationService.SignIn(View.NomUtilisateurIdentification, View.MotPasseIdentification);
            if (user != null)
            {
                NavigationService.Redirect(Pages.Pages.DEFAULT);
            }
        }

        public void CreerUtilisateur()
        {
            if (string.IsNullOrEmpty(View.CourrielCreation))
            {
                MessageService.ThrowMessage(Web.Services.ErrorCode.ADM_CREATE_USER_MANDATORY);
                return;
            }

            if (string.IsNullOrEmpty(View.MotPasseCreation))
            {
                MessageService.ThrowMessage(Web.Services.ErrorCode.ADM_CREATE_USER_MANDATORY);
                return;
            }

            if (View.MotPasseCreation != View.MotPasseConfirmationCreation)
            {
                MessageService.ThrowMessage(ErrorCode.SC_PASSWORD_DONT_EQUAL_PASSWORD_CONFIRM);
                return;
            }

            User user = new User
                {
                    Email = View.CourrielCreation,
                    Login = View.CourrielCreation,
                    Password = View.MotPasseCreation,
                    FirstName = View.PrenomCreation,
                    LastName = View.NomCreation
                };
            Customer customer = new Customer
                {
                    User = user,
                    Enterprise = new Enterprise
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
