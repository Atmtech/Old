using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.WebSite
{
    public partial class Default1 : PageBaseShoppingCart<DefaultPresenter, IDefaultPresenter>, IDefaultPresenter
    {
        public string QueryStringContent
        {
            get { throw new System.NotImplementedException(); }
        }

        public string ContentValue
        {
            set { throw new System.NotImplementedException(); }
        }
    }
}