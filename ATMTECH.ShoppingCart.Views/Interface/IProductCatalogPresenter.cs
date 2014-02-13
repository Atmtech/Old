using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface
{
    public interface IProductCatalogPresenter : IViewBase
    {
        IList<ProductCategory> ProductCategories { set; }
    }
}
