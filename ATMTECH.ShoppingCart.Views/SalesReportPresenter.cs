using System.Collections.Generic;
using ATMTECH.Services;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Views
{
    public class SalesReportPresenter : BaseShoppingCartPresenter<ISalesReportPresenter>
    {
        public IOrderService OrderService { get; set; }
        public ATMTECH.Services.Interface.IReportService ReportService { get; set; }

        public SalesReportPresenter(ISalesReportPresenter view)
            : base(view)
        {
        }

       
    }
}
