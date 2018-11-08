using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using ATMTECH.Expeditn.DAO;
using ATMTECH.Expeditn.Entites;
using ATMTECH.Expeditn.Entites.DTO;
using MongoDB.Bson;

namespace ATMTECH.Expeditn.Services
{
    public class SuiviPrixService : BaseService
    {

        public ObjectId Enregistrer(SuiviPrix suiviPrix)
        {
            return new DAOSuiviPrix().Enregistrer(suiviPrix);
        }
        public IList<SuiviPrix> ObtenirsuiviPrix()
        {
            return new DAOSuiviPrix().Obtenir();
        }



        public SuiviPrix ObtenirsuiviPrix(string id)
        {
            return new DAOSuiviPrix().Obtenir(id);
        }


        public IList<SuiviPrix> ObtenirsuiviPrix(Utilisateur utilisateur)
        {
            return new DAOSuiviPrix().Obtenir().Where(x => x.Utilisateur.Id == utilisateur.Id).ToList();
        }

        public IList<HistoriqueSuiviPrix> Obtenir(Utilisateur utilisateur)
        {
            return new DAOHistoriqueSuiviPrix().Obtenir().Where(x => x.SuiviPrix.Utilisateur.Id == utilisateur.Id).ToList();
        }

        public void ScanExpedia(SuiviPrix suiviPrix)
        {
            using (var webBrowser = new WebBrowser())
            {
                webBrowser.Tag = suiviPrix;
                webBrowser.ScriptErrorsSuppressed = true;
                webBrowser.DocumentCompleted += Expedia_DocumentCompleted1;
                webBrowser.Navigate(suiviPrix.UrlSuiviPrix);

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
                    HistoriqueSuiviPrix historique = new HistoriqueSuiviPrix();
                    historique.SuiviPrix = (SuiviPrix)webBrowser.Tag;
                    historique.DateSuiviPrix = DateTime.Now;
                    historique.TypeSuiviPrix = "Expedia";
                    historique.Hotel = modeleExpediaOffer.hotel.name;
                    historique.CompagnieAviation = modeleExpediaOffer.trip.departureFlight.flightSegments[0].airline.name;
                    if (modeleExpediaOffer.hotel.reviewSummary != null)
                        historique.CoteTotalAppreciation = modeleExpediaOffer.hotel.reviewSummary.averageOverallRating.ToString();
                    historique.DateDepart = modeleExpediaOffer.trip.departureFlight.flightSegments[0].departure.localTime;
                    historique.DateRetour = modeleExpediaOffer.trip.returnFlight.flightSegments[0].departure.localTime;
                    historique.NombreEtoile = modeleExpediaOffer.hotel.rating[0].value.ToString();
                    historique.OperateurEnChargeDuVoyage = modeleExpediaOffer.tourOperator.name;
                    historique.PlanRepas = modeleExpediaOffer.hotel.mealPlan.name;
                    historique.Prix = modeleExpediaOffer.price.pricePerPassenger;
                    historique.VilleDepart = modeleExpediaOffer.trip.departureFlight.flightSegments[0].departure.airport.city;
                    historique.VilleArrive = modeleExpediaOffer.trip.departureFlight.flightSegments[0].arrival.airport.city;

                    if (modeleExpediaOffer.hotel.reviewSummary != null)
                        historique.NombreTotalAppreciation = modeleExpediaOffer.hotel.reviewSummary.total.ToString();

                    new DAOHistoriqueSuiviPrix().Enregistrer(historique);
                }


            }
        }


        public void Supprimer(SuiviPrix suiviPrix)
        {
            IList<HistoriqueSuiviPrix> historiqueSuivi = Obtenir(suiviPrix.Utilisateur).Where(x => x.SuiviPrix.Id.ToString() == suiviPrix.Id.ToString()).ToList();
            foreach (HistoriqueSuiviPrix historiqueSuiviPrix in historiqueSuivi)
            {
                new DAOHistoriqueSuiviPrix().Supprimer(historiqueSuiviPrix.Id.ToString());
            }
            new DAOSuiviPrix().Supprimer(suiviPrix.Id.ToString());
        }
    }
}

