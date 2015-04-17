using System;
using System.Collections;
using System.Collections.Generic;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface.Francais;
using ATMTECH.Services;
using ATMTECH.Services.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Services.Reports.DTO;

namespace ATMTECH.Administration.Views.Francais
{
    public class RapportPresenter : BaseAdministrationPresenter<IRapportPresenter>
    {
        public IReportService ReportService { get; set; }
        public ICommandeService CommandeService { get; set; }

        public RapportPresenter(IRapportPresenter view)
            : base(view)
        {
        }


        public void GenererRapport()
        {
            switch (View.NomRapport)
            {
                case "VenteParProduit":
                    break;
                case "UneCommande":
                    break;
                case "ListeCommande":
                    break;
            }
        }

        private void Generer(string rdlc, IEnumerable valeurs, string nomRapportPdf)
        {
            Dictionary<string, string> dictionnaire = new Dictionary<string, string>();
            ReportParameter reportParameter = new ReportParameter
            {
                Assembly = "ATMTECH.ShoppingCart.Services",
                PathToReportAssembly = "ATMTECH.ShoppingCart.Services.Reports." + rdlc + ".rdlc",

                ReportFormat = ReportFormat.PDF,
                Parameters = dictionnaire
            };

            reportParameter.AddDatasource("dsDataSource", valeurs);
            ReportService.SaveReport(nomRapportPdf, ReportService.GetReport(reportParameter));
        }
    }
}
