using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Administration.Views.Interface
{
    public interface IDataEditorPresenter : IViewBase
    {
        string Entity { get; }
        string NameSpace { get; }
        object EnterpriseList { set; }
        string Enterprise { get; }
        string InnerTitle { set; }
        string IsEnterpriseRuled { get; }

        bool IsInserting { get; set; }
        int? IdCopy { set; }

        IList<Product> ProductWithoutStock { set; }
        IList<StockTemplate> StockTemplate { set; }
    }
}
