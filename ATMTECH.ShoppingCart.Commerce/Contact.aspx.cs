using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Contact : PageBaseShoppingCart<ContactPresenter, IContactPresenter>, IContactPresenter
    {
        public string ContactDisplay { set; private get; }
    }
}