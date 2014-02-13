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

        public void LaunchReport()
        {
            Dictionary<string, string> dictionnaire = new Dictionary<string, string>();
            ReportParameter reportParameter = new ReportParameter
            {
                Assembly = "ATMTECH.ShoppingCart.Services",
                PathToReportAssembly = "ATMTECH.ShoppingCart.Services.Reports.Sales.rdlc",
                ReportFormat = ReportFormat.PDF,
                Parameters = dictionnaire
            };

            reportParameter.AddDatasource("dsOrderServiceGetSalesReport", OrderService.GetOrdersFromCustomer(new Customer() { Id = 1 }, OrderStatus.IsOrdered));
            ReportService.SaveReport("Sales.pdf", ReportService.GetReport(reportParameter));

        }
    }
}
