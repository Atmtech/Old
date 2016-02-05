using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface.Francais;
using ATMTECH.Services;
using ATMTECH.Services.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Services.Reports.DTO;

namespace ATMTECH.Administration.Views.Francais
{
    public class RapportPresenter : BaseAdministrationPresenter<IRapportPresenter>
    {
        public IReportService ReportService { get; set; }
        public ICommandeService CommandeService { get; set; }
        public IEnterpriseService EnterpriseService { get; set; }
        public IOrderService OrderService { get; set; }
        public ICourrielService CourrielService { get; set; }

        public RapportPresenter(IRapportPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.TitreRapport = View.NomRapport;
        }

        public void GenererRapport()
        {
            switch (View.NomRapport)
            {
                case "Inventaire":
                    GenererRapportInventaire();
                    break;
                case "UneCommande":
                    Order commande = CommandeService.ObtenirCommande(View.NoCommande);
                    CommandeService.ImprimerCommande(commande);
                    commande.Customer.User.Login = "atmtech.vincent@gmail.com";
                    CourrielService.EnvoyerCommandeFinaliser(commande, CommandeService.ObtenirFacturePourPdf(commande));

                    break;
                case "VenteParMois":
                    GenererRapportVenteParMois();
                    break;
                case "VenteImputation":
                    GenererRapportVenteParImputation();
                    break;
                case "ControleInventaire":
                    GenererRapportControleInventaire();
                    break;
                case "ValiderAvecPayPal":
                    ValiderCommandePaypal();
                    break;
            }
        }

        private void ValiderCommandePaypal()
        {
            Enterprise enterprise = EnterpriseService.GetEnterprise(View.Entreprise.Id);
            IList<Order> orders = OrderService.GetAllToValidatePaypal(enterprise, View.DateDepart, View.DateFin).OrderByDescending(x => x.FinalizedDate).ToList();
            string html = "<table><tr style='font-weight:bold;background-color:gray;color:white;'><td>Date</td><td>Nom</td><td>Numéro de facture</td><td>Hors taxes</td></tr>";
            foreach (Order order in orders)
            {
                html += "<tr>";
                html += "<td>";
                html += order.FinalizedDate;
                html += "</td>";
                html += "<td>";
                html += order.CustomerFullName;
                html += "</td>";
                html += "<td>";
                html += order.Id;
                html += "</td>";
                html += "<td>";
                html += order.GrandTotal;
                html += "</td>";
                html += "</tr>";
            }

            html += "</table>";
            View.ResultatValidationPayPal = html;
        }

        public void GenererRapportInventaire()
        {
            Dictionary<string, string> dictionnaire = new Dictionary<string, string>();
            ReportParameter reportParameter = new ReportParameter
            {
                Assembly = "ATMTECH.ShoppingCart.Services",
                PathToReportAssembly = "ATMTECH.ShoppingCart.Services.Reports.Stock.rdlc",

                ReportFormat = ReportFormat.PDF,
                Parameters = dictionnaire
            };

            Enterprise enterprise = EnterpriseService.GetEnterprise(View.Entreprise.Id);

            IList<SalesReportLine> salesReportLines = OrderService.GetSalesReportLine(enterprise, View.DateDepart,
                                                                                      View.DateFin);
            IList<ProductPriceHistoryReportLine> productPriceHistoryReportLines = OrderService.GetProductPriceHistoryReportLine(enterprise, View.DateDepart,
                                                                                     View.DateFin);
            reportParameter.AddDatasource("dsStockReport", salesReportLines);
            reportParameter.AddDatasource("dsProductPriceHistory", productPriceHistoryReportLines);
            ReportService.SaveReport("Stock.pdf", ReportService.GetReport(reportParameter));
        }
        public void GenererRapportVenteParMois()
        {
            Dictionary<string, string> dictionnaire = new Dictionary<string, string>();
            ReportParameter reportParameter = new ReportParameter
            {
                Assembly = "ATMTECH.ShoppingCart.Services",
                PathToReportAssembly = "ATMTECH.ShoppingCart.Services.Reports.Sales.rdlc",

                ReportFormat = ReportFormat.PDF,
                Parameters = dictionnaire
            };
            Enterprise enterprise = EnterpriseService.GetEnterprise(View.Entreprise.Id);
            IList<SalesReportLine> salesReportLines = OrderService.GetSalesReportLine(enterprise, View.DateDepart, View.DateFin);
            reportParameter.AddDatasource("dsSalesReport", salesReportLines);
            ReportService.SaveReport("Sales.pdf", ReportService.GetReport(reportParameter));
        }
        public void GenererRapportVenteParImputation()
        {

            Dictionary<string, string> dictionnaire = new Dictionary<string, string>();
            ReportParameter reportParameter = new ReportParameter
            {
                Assembly = "ATMTECH.ShoppingCart.Services",
                PathToReportAssembly = "ATMTECH.ShoppingCart.Services.Reports.SalesByOrderInformation.rdlc",

                ReportFormat = ReportFormat.PDF,
                Parameters = dictionnaire
            };

            Enterprise enterprise = EnterpriseService.GetEnterprise(View.Entreprise.Id);

            IList<SalesByOrderInformationReportLine> salesReportLines = OrderService.GetSalesByOrderInformationReportLine(enterprise, View.DateDepart,
                                                                                      View.DateFin);

            reportParameter.AddDatasource("dsSalesByInformationOrder", salesReportLines);
            ReportService.SaveReport("SalesByOrderInformation.pdf", ReportService.GetReport(reportParameter));
        }

        public void GenererRapportControleInventaire()
        {

            Dictionary<string, string> dictionnaire = new Dictionary<string, string>();
            ReportParameter reportParameter = new ReportParameter
            {
                Assembly = "ATMTECH.ShoppingCart.Services",
                PathToReportAssembly = "ATMTECH.ShoppingCart.Services.Reports.StockControl.rdlc",
                ReportFormat = ReportFormat.PDF,
                Parameters = dictionnaire
            };


            IList<StockControlReportLine> stockControlReportLines = OrderService.GetStockControlReport();

            reportParameter.AddDatasource("dsStockControl", stockControlReportLines);
            ReportService.SaveReport("StockControl.pdf", ReportService.GetReport(reportParameter));
        }
    }
}
