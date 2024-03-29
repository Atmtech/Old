﻿using System;
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
    public class SalesReportPresenter : BaseAdministrationPresenter<ISalesReportPresenter>
    {
        public IEnterpriseService EnterpriseService { get; set; }
        public IOrderService OrderService { get; set; }
        public IReportService ReportService { get; set; }

        public SalesReportPresenter(ISalesReportPresenter view)
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
                PathToReportAssembly = "ATMTECH.ShoppingCart.Services.Reports.Sales.rdlc",

                ReportFormat = ReportFormat.PDF,
                Parameters = dictionnaire
            };

            Enterprise enterprise = EnterpriseService.GetEnterprise(Convert.ToInt32(View.EnterpriseSelected));

            IList<SalesReportLine> salesReportLines = OrderService.GetSalesReportLine(enterprise, View.DateStart,
                                                                                      View.DateEnd);

            reportParameter.AddDatasource("dsSalesReport", salesReportLines);
            ReportService.SaveReport("Sales.pdf", ReportService.GetReport(reportParameter));
        }
    }


}
