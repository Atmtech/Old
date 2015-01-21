using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Administration.Views.Interface
{
    public interface IStockTransactionPresenter : IViewBase
    {

        IList<Stock> Stocks { set; }
    }
}
