using System.Collections.Generic;
using ATMTECH.Investisseurs.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Investisseurs.Views.Interface
{
    public interface IDefaultPresenter : IViewBase
    {
        bool IsLogged { get; set; }
        IList<StockQuote> StockQuotes { set; }
        string InformationPlayer { set; }
    }
}
