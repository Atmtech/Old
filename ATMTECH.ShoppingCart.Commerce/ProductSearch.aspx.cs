using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class ProductSearch : PageBaseShoppingCart<ProductSearchPresenter, IProductSearchPresenter>, IProductSearchPresenter
    {
        public IList<Product> Products { set; private get; }
        public string Search { get; private set; }
    }
}