using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using ATMTECH.DAO;
using ATMTECH.Entities;
using ATMTECH.Expeditn.DAO;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Entities.DTO;
using ATMTECH.Expeditn.Services.Interface;

namespace ATMTECH.Expeditn.Services
{
    public class ExpediaService : IExpediaService
    {
        public IDAORechercheForfaitExpedia DAORechercheForfaitExpedia { get; set; }
        public IDAOHistoriqueForfaitExpedia DAOHistoriqueForfaitExpedia { get; set; }

        public RechercheForfaitExpedia ObtenirRechercheForfaitExpedia(int id)
        {
           return DAORechercheForfaitExpedia.ObtenirRechercheForfaitExpedia(id);
        }

        public void ObtenirPrixRechercheForfaitExpedia()
        {
            IList<RechercheForfaitExpedia> rechercheForfaitExpedias = new DAORechercheForfaitExpedia().ObtenirRechercheForfaitExpedia();
            foreach (RechercheForfaitExpedia rechercheForfaitExpedia in rechercheForfaitExpedias)
            {
                ObtenirPrix(rechercheForfaitExpedia);
            }

        }

        
        public IList<RechercheForfaitExpedia> ObtenirRechercheForfaitExpedia(User utilisateur)
        {
            return DAORechercheForfaitExpedia.ObtenirRechercheForfaitExpedia().Where(x => x.Utilisateur.Id == utilisateur.Id).ToList();
        }

        public IList<HistoriqueForfaitExpedia> ObtenirHistoriqueForfaitExpedia(RechercheForfaitExpedia rechercheForfaitExpedia)
        {
            IList<HistoriqueForfaitExpedia> obtenirHistoriqueForfaitExpedia = DAOHistoriqueForfaitExpedia.ObtenirHistoriqueForfaitExpedia(rechercheForfaitExpedia);
            foreach (HistoriqueForfaitExpedia historiqueForfaitExpedia in obtenirHistoriqueForfaitExpedia)
            {
                historiqueForfaitExpedia.RechercheForfaitExpedia = rechercheForfaitExpedia;
            }
            return obtenirHistoriqueForfaitExpedia;
        }

        private void ObtenirPrix(RechercheForfaitExpedia rechercheForfaitExpedia)
        {
            string url = rechercheForfaitExpedia.Url;
            Console.WriteLine(@"Traitement en cours pour recherche: {0} Utilisateur:{1}", rechercheForfaitExpedia.Nom, rechercheForfaitExpedia.Utilisateur.Id);
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                myRequest.Timeout = 10000;
                myRequest.Method = "GET";
                WebResponse myResponse = myRequest.GetResponse();
                StreamReader sr = new StreamReader(myResponse.GetResponseStream(), Encoding.Default);
                string result = sr.ReadToEnd();
                string json = result.Substring(result.IndexOf("dataQ = [{ data:"), result.IndexOf("}, ['trackPageView', 'hPvSrp'],['expediaTestingFlag','false']];") - result.IndexOf("dataQ = [{ data:"));
                json = json.Substring(16, json.Length - 16);

                DataExpedia dataExpedia = new JavaScriptSerializer().Deserialize<DataExpedia>(json);

                foreach (HotelList hotelList in dataExpedia.hotelList)
                {
                    HistoriqueForfaitExpedia historiqueForfaitExpedia = new HistoriqueForfaitExpedia
                    {
                        NomHotel = hotelList.hotelName,
                        CompagnieOrganisatrice = hotelList.packages.First().tourOperator,
                        DateDepart = Convert.ToDateTime(dataExpedia.searchAndFilterParams.fromDate),
                        NombreJour = Convert.ToInt32(dataExpedia.searchAndFilterParams.duration.Replace("DAYS", "")),
                        Prix = (decimal)hotelList.packages.First().price,
                        RechercheForfaitExpedia = rechercheForfaitExpedia,
                        GeoLocalisation = rechercheForfaitExpedia.GeoLocalisation,
                        NombreEtoile = hotelList.starRating,
                        AppreciationUtilisateur = hotelList.userRating,
                        NombreUtilisateurAppreciation = hotelList.userRreviewCount
                    };

                    new DAOHistoriqueForfaitExpedia().Enregistrer(historiqueForfaitExpedia);
                    Console.WriteLine(@"Hotel: {0}", hotelList.hotelName);
                }
                Console.WriteLine(@"Traitement terminé pour recherche: {0} Utilisateur:{1}", rechercheForfaitExpedia.Nom, rechercheForfaitExpedia.Utilisateur.Id);
            }
            catch (Exception ex)
            {
                var st = new StackTrace(ex, true);
                var frame = st.GetFrame(0);
                var line = frame.GetFileLineNumber();
                LogException logException = new LogException
                {
                    InnerId = "INTERNAL",
                    Page = "Application sniper",
                    Description = ex.Message + " => ATMTECH.Expeditn.Sniper",
                    StackTrace = "Line number: " + line + "            " + ex.StackTrace
                };

                new DAOLogException().CreateLog(logException);
            }
        }
    }
}
