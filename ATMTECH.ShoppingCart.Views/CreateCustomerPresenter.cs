using System;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Views
{
    public class CreateCustomerPresenter : BaseShoppingCartPresenter<ICreateCustomerPresenter>
    {
        public ICustomerService CustomerService { get; set; }
        public CreateCustomerPresenter(ICreateCustomerPresenter view)
            : base(view)
        {
        }

        public void CreateCustomer()
        {

            if (String.IsNullOrEmpty(View.UserName))
            {
                MessageService.ThrowMessage(Web.Services.ErrorCode.ADM_CREATE_USER_MANDATORY);
            }

            if (String.IsNullOrEmpty(View.Password))
            {
                MessageService.ThrowMessage(Web.Services.ErrorCode.ADM_CREATE_USER_MANDATORY);
            }

            if (View.Password != View.PasswordConfirmation)
            {
                MessageService.ThrowMessage(ErrorCode.SC_PASSWORD_DONT_EQUAL_PASSWORD_CONFIRM);
            }
            User user = new User { FirstName = View.FirstName, LastName = View.LastName, Password = View.Password, Login = View.UserName, Email = View.Email };
            Customer customer = new Customer
                {
                    User = user,
                    Enterprise =
                        new Enterprise
                            {
                                Id = Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED))
                            }
                };
            View.CreateSuccess = CustomerService.CreateCustomer(customer);
        }
    }
}
