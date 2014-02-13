using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Views
{
    public class ForgetPasswordPresenter : BaseShoppingCartPresenter<IForgetPasswordPresenter>
    {
        public ICustomerService CustomerService { get; set; }

        public ForgetPasswordPresenter(IForgetPasswordPresenter view)
            : base(view)
        {
        }

        public void SendMail()
        {
            CustomerService.SendForgetPassword(View.Email);
        }
    }
}
