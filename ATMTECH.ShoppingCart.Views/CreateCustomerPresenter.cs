using System;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.ErrorCode;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Views
{
    public class CreateCustomerPresenter : BaseShoppingCartPresenter<ICreateCustomerPresenter>
    {
        public ICustomerService CustomerService { get; set; }
        public IParameterService ParameterService { get; set; }
        public CreateCustomerPresenter(ICreateCustomerPresenter view)
            : base(view)
        {
        }

        public void CreateCustomer()
        {
            //if (View.CaptchaTextBox != View.CaptchaSession)
            //{
            //    MessageService.ThrowMessage(ErrorCode.SC_CAPTCHA_INVALID);
            //}

            if (View.Password != View.PasswordConfirmation)
            {
                MessageService.ThrowMessage(ErrorCode.SC_PASSWORD_DONT_EQUAL_PASSWORD_CONFIRM);
            }
            User user = new User() { FirstName = View.FirstName, LastName = View.LastName, Password = View.Password, Login = View.UserName, Email = View.Email };
            Customer customer = new Customer() { User = user };
            customer.Enterprise = new Enterprise() { Id = Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED)) };
            View.CreateSuccess = CustomerService.CreateCustomer(customer);
        }
    }
}
