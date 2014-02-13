using System;
using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Administration.Views.Interface
{
    public interface ISalesReportPresenter : IViewBase
    {
        IList<Enterprise> Enterprises { set; }
        string EnterpriseSelected { get; }
        DateTime DateStart { get; }
        DateTime DateEnd { get; }
    }
}
