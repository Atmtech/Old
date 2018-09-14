using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using ATMTECH.Expeditn.DAO;
using ATMTECH.Expeditn.Entites;
using ATMTECH.Expeditn.Entites.DTO;

namespace ATMTECH.Expeditn.Services
{
    public class ScanService : BaseService
    {

        public void Enregistrer(PlanificationScan planificationScan)
        {
            new DAOPlanificationScan().Enregistrer(planificationScan);
        }
        public IList<PlanificationScan> ObtenirPlanificationScan()
        {
            return new DAOPlanificationScan().Obtenir();
        }

        public IList<PlanificationScan> ObtenirPlanificationScan(Utilisateur utilisateur)
        {
            return new DAOPlanificationScan().Obtenir().Where(x => x.Utilisateur.Id == utilisateur.Id).ToList();
        }

        public IList<HistoriqueScan> Obtenir(Utilisateur utilisateur)
        {
            return new DAOHistoriqueScan().Obtenir().Where(x => x.PlanificationScan.Utilisateur.Id == utilisateur.Id).ToList();
        }

        public void ScanExpedia(PlanificationScan planificationScan)
        {
            using (var webBrowser = new WebBrowser())
            {
                webBrowser.Tag = planificationScan;
                webBrowser.ScriptErrorsSuppressed = true;
                webBrowser.DocumentCompleted += Expedia_DocumentCompleted1;
                webBrowser.Navigate(planificationScan.UrlScan);

                while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
            }
        }

        private void Expedia_DocumentCompleted1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser webBrowser = (WebBrowser)sender;
            if (webBrowser.ReadyState == WebBrowserReadyState.Complete)
            {
                string html = webBrowser.DocumentText;
                html = html.Substring(html.IndexOf("window.__INITIAL_STATE__"), html.Length - html.IndexOf("window.__INITIAL_STATE__") - 1);
                html = html.Substring(0, html.IndexOf("\"searchParams\":") - 1);
                html = "{" + html.Substring(html.IndexOf("\"offers\":"), html.Length - html.IndexOf("\"offers\":") - 1) + "}";
                ModeleExpedia modeleExpedia = new JavaScriptSerializer().Deserialize<ModeleExpedia>(html);
                foreach (Offer modeleExpediaOffer in modeleExpedia.offers)
                {
                    HistoriqueScan historique = new HistoriqueScan
                    {
                        PlanificationScan = (PlanificationScan)webBrowser.Tag,
                        DateScan = DateTime.Now,
                        TypeScan = "Expedia",
                        Hotel = modeleExpediaOffer.hotel.name,
                        CompagnieAviation = modeleExpediaOffer.trip.departureFlight.flightSegments[0].airline.name,
                        CoteTotalAppreciation = modeleExpediaOffer.hotel.reviewSummary.averageOverallRating.ToString(),
                        DateDepart = modeleExpediaOffer.trip.departureFlight.flightSegments[0].departure.localTime,
                        DateRetour = modeleExpediaOffer.trip.returnFlight.flightSegments[0].departure.localTime,
                        NombreEtoile = modeleExpediaOffer.hotel.rating[0].value.ToString(),
                        NombreTotalAppreciation = modeleExpediaOffer.hotel.reviewSummary.total.ToString(),
                        OperateurEnChargeDuVoyage = modeleExpediaOffer.tourOperator.name,
                        PlanRepas = modeleExpediaOffer.hotel.mealPlan.name,
                        Prix = modeleExpediaOffer.price.pricePerPassenger,
                        VilleDepart = modeleExpediaOffer.trip.departureFlight.flightSegments[0].departure.airport.city,
                        VilleArrive = modeleExpediaOffer.trip.departureFlight.flightSegments[0].arrival.airport.city,
                    };
                    new DAOHistoriqueScan().Enregistrer(historique);
                }


            }
        }


    }
}

