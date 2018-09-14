using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using ATMTECH.Expeditn.Entites;
using ATMTECH.Expeditn.Services;

namespace ATMTECH.Expeditn.Site
{
    public partial class HistoriquePrix : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            placeholderHistorique.Controls.Clear();
            IList<HistoriqueScan> historiqueScans = new ScanService().Obtenir(new UtilisateurService().Obtenir().FirstOrDefault()).OrderBy(x => x.PlanificationScan.Nom).ThenBy(x => x.Prix).ToList();

            string html = string.Empty;
            html += "<div class='row'>";
            html += "<div class='col-sm-8'>";
            html += "<div class='progress' style='margin-bottom: 4px;'> ";
            html += "<div class='progress-bar ' style ='width: {0}%'>{1}</div>";
            html += "</div>";
            html += "</div>";
            html += "<div class='col-sm-4'>{2}</div>";
            html += "</div>";



            string nomCourant = String.Empty;
            IList<HistoriqueDejaAjoute> historiqueDejaAjoutes = new List<HistoriqueDejaAjoute>();
            foreach (HistoriqueScan historiqueScan in historiqueScans)
            {
                if (nomCourant != historiqueScan.PlanificationScan.Nom)
                {
                    LiteralControl literalControlEntete = new LiteralControl
                    {
                        Text = "<h2>" + historiqueScan.PlanificationScan.Nom + "</h2>"
                    };
                    placeholderHistorique.Controls.Add(literalControlEntete);
                };

                nomCourant = historiqueScan.PlanificationScan.Nom;

                if (!historiqueDejaAjoutes.Any(x => x.Id == historiqueScan.PlanificationScan.Id.ToString() && x.Prix == historiqueScan.Prix.ToString()))
                {
                    decimal valeurMaximum = historiqueScans.Where(x => x.Hotel == historiqueScan.Hotel).Max(x => x.Prix);
                    decimal valeurPourcentage = (100 * historiqueScan.Prix) / valeurMaximum;
                    LiteralControl literalControl = new LiteralControl
                    {
                        Text = string.Format(html, Math.Truncate(valeurPourcentage), string.Format("{0:C}", historiqueScan.Prix), historiqueScan.Hotel + " (" + historiqueScan.DateScan + ")")
                    };
                    historiqueDejaAjoutes.Add(new HistoriqueDejaAjoute { Id = historiqueScan.PlanificationScan.Id.ToString(), Prix = historiqueScan.Prix.ToString() });

                    placeholderHistorique.Controls.Add(literalControl);
                }
            }

        }
    }

    public class HistoriqueDejaAjoute
    {
        public string Id { get; set; }
        public string Prix { get; set; }
    }
}