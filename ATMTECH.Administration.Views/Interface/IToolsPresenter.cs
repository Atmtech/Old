using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Administration.Views.Interface
{
    public interface IToolsPresenter : IViewBase
    {
        IList<Product> ProductWithoutStock { set; }
        IList<StockTemplate> StockTemplate { set; }
        IList<Enterprise> Enterprise { set; }
        int EnterpriseSelect { get; }
        IList<User> Users { set; }
    }
}
