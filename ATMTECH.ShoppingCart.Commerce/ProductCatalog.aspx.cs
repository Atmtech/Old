using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class ProductCatalog : PageBaseShoppingCart<ProductCatalogPresenter, IProductCatalogPresenter>, IProductCatalogPresenter
    {
        public IList<ProductCategory> ProductCategories { set; private get; }
    }
}