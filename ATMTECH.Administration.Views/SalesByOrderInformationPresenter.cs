using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.Entities;
using ATMTECH.Services;
using ATMTECH.Services.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Reports.DTO;

namespace ATMTECH.Administration.Views
{
    public class SalesByOrderInformationPresenter : BaseAdministrationPresenter<ISalesByOrderInformationPresenter>
    {
        public IEnterpriseService EnterpriseService { get; set; }
        public IOrderService OrderService { get; set; }
        public IReportService ReportService { get; set; }

        public SalesByOrderInformationPresenter(ISalesByOrderInformationPresenter view)
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
                PathToReportAssembly = "ATMTECH.ShoppingCart.Services.Reports.SalesByOrderInformation.rdlc",

                ReportFormat = ReportFormat.PDF,
                Parameters = dictionnaire
            };

            Enterprise enterprise = EnterpriseService.GetEnterprise(Convert.ToInt32(View.EnterpriseSelected));

            IList<SalesByOrderInformationReportLine> salesReportLines = OrderService.GetSalesByOrderInformationReportLine(enterprise, View.DateStart,
                                                                                      View.DateEnd);

            reportParameter.AddDatasource("dsSalesByInformationOrder", salesReportLines);
            ReportService.SaveReport("SalesByOrderInformation.pdf", ReportService.GetReport(reportParameter));
        }
    }


}
