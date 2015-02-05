using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Default1 : PageBaseShoppingCart<DefaultPresenter, IDefaultPresenter>, IDefaultPresenter
    {
        public string QueryStringContent { get; private set; }
        public string ContentValue { set; private get; }
        public IList<Product> FavoritesProduct { set; private get; }
        public Enterprise Enterprise { set; private get; }
    }
}