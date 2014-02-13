using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.SagaceMarketing
{
    public partial class Contact : PageBaseShoppingCart<ContactPresenter, IContactPresenter>, IContactPresenter
    {
        public string ContactDisplay
        {
            set { lblContact.Text = value;   }
        }
    }
}