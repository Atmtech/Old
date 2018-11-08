using System;
using System.Net;
using System.Web;
using ATMTECH.StockGame.Entites;
using MongoDB.Driver;

namespace ATMTECH.StockGame.DAO
{
    public class DAOLocalisation : BaseDAO<Localisation>

    {
        public Localisation ObtenirInformationLocalisation(string ip)
        {
            string url = string.Format("http://api.ipinfodb.com/v3/ip-city/?key=784b00c1233a988d47b6bfbfbd2fa55dc41279ec9781162bbe9d7ce36d001b0f&ip={0}", ip);
            using (WebClient client = new WebClient())
            {
                string s = client.DownloadString(url);
                string[] response = s.Split(';');
                Localisation localisation = new Localisation
                {
                    Ip = ip,
                    DateCreation = DateTime.Now,
                    Pays = CapitalizeFirst(response[4]),
                    Region = CapitalizeFirst(response[5]),
                    Ville = CapitalizeFirst(response[6]),
                    CodePostal = response[7]
                };
                return localisation;
            }
        }

        public void AjouterTraceVisiteur()
        {
            string ip = HttpContext.Current.Request.UserHostName;
            if (ip != "127.0.0.1" && ip != "::1")
            {
                Localisation localisation = ObtenirInformationLocalisation(ip);
                IMongoCollection<Localisation> mongoCollection = Database.GetCollection<Localisation>("Localisation");
                mongoCollection.InsertOneAsync(localisation);
            }
        }

        private string CapitalizeFirst(string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1).ToLower();
        }
    }

}