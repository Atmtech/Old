using System;
using System.Collections;
using System.Collections.Generic;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.Entities;
using ATMTECH.Services;
using ATMTECH.Services.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Reports.DTO;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Administration.Views
{
    public class StockReportPresenter : BaseAdministrationPresenter<IStockReportPresenter>
    {
        public IEnterpriseService EnterpriseService { get; set; }
        public IOrderService OrderService { get; set; }
        public IReportService ReportService { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }


        public StockReportPresenter(IStockReportPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.Enterprises = EnterpriseService.GetEnterpriseByAccess(AuthenticationService.AuthenticateUser);

            User user = AuthenticationService.AuthenticateUser;
            if (user == null) return;
            if (!user.IsAdministrator)
            {
                NavigationService.Redirect("default.aspx");
            }
        }
        public void GenerateReport()
        {

            Dictionary<string, string> dictionnaire = new Dictionary<string, string>();
            ReportParameter reportParameter = new ReportParameter
            {
                Assembly = "ATMTECH.ShoppingCart.Services",
                PathToReportAssembly = "ATMTECH.ShoppingCart.Services.Reports.Stock.rdlc",

                ReportFormat = ReportFormat.PDF,
                Parameters = dictionnaire
            };

            Enterprise enterprise = EnterpriseService.GetEnterprise(Convert.ToInt32(View.EnterpriseSelected));

            IList<SalesReportLine> salesReportLines = OrderService.GetSalesReportLine(enterprise, View.DateStart,
                                                                                      View.DateEnd);
            IList<ProductPriceHistoryReportLine> productPriceHistoryReportLines = OrderService.GetProductPriceHistoryReportLine(enterprise, View.DateStart,
                                                                                     View.DateEnd);
            reportParameter.AddDatasource("dsStockReport", salesReportLines);
            reportParameter.AddDatasource("dsProductPriceHistory", productPriceHistoryReportLines);
            ReportService.SaveReport("Stock.pdf", ReportService.GetReport(reportParameter));
        }
    }


}
