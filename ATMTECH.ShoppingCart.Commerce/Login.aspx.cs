using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Login : PageBaseShoppingCart<LoginPresenter, ILoginPresenter>, ILoginPresenter
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsLogged { set; private get; }
        public bool IsAdministrator { set; private get; }
        public bool IsCreateCustomerPossible { set; private get; }
    }
}