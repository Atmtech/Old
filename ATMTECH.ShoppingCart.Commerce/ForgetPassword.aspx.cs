using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class ForgetPassword : PageBaseShoppingCart<ForgetPasswordPresenter, IForgetPasswordPresenter>,IForgetPasswordPresenter
    {
        public string Email { get; set; }
    }
}