using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface
{
    public interface IProductSearchPresenter : IViewBase
    {
        IList<Product> Products { set; }
        string Search { get; }
    }
}
