using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface
{
    public interface IDefaultPresenter : IViewBase
    {
        string QueryStringContent { get; }
        string ContentValue { set; }

        IList<Product> FavoritesProduct { set; }
        Enterprise Enterprise { set; }

    }
}
