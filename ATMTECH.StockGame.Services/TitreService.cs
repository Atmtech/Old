using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using ATMTECH.StockGame.DAO;
using ATMTECH.StockGame.Entites;
using Newtonsoft.Json;
using RestSharp;

namespace ATMTECH.StockGame.Services
{
    public class TitreService : BaseService
    {

        public IList<Titre> VendreTitreAvecOrdre()
        {
            List<Titre> titres = new BaseDAO<Titre>().Obtenir().Where(x => x.ValeurOrdrePourVendre > 0).ToList();
            IList<Titre> titreVendu = new List<Titre>();
            foreach (Titre titre in titres)
            {
                Titre rechercherTitreSurInternet = RechercherTitreSurInternet(titre.Code);
                if (rechercherTitreSurInternet.ValeurActuelle >= titre.ValeurOrdrePourVendre)
                {
                    VendreTitre(titre.Id.ToString(), titre.Utilisateur.Id.ToString());
                    titreVendu.Add(titre);
                }
            }
            return titreVendu;
        }

        public IList<Titre> Obtenir(Utilisateur utilisateur)
        {
            return new BaseDAO<Titre>().Obtenir().Where(x => x.Utilisateur.Id == utilisateur.Id).ToList();
        }

        public string ObtenirRang(Utilisateur utilisateur)
        {
            IList<Utilisateur> utilisateurs = new BaseDAO<Utilisateur>().Obtenir().OrderByDescending(x => x.Solde).ToList();
            int i = 0;
            int rang = 0;
            foreach (var courant in utilisateurs)
            {
                i++;
                if (courant.Id == utilisateur.Id)
                {
                    rang = i;
                }
            }
            return rang + " de " + i;
        }

        public IList<Classement> ObtenirClassement()
        {
            IList<Utilisateur> utilisateurs = new BaseDAO<Utilisateur>().Obtenir().OrderByDescending(x => x.Solde).ToList();
            IList<Classement> classements = new List<Classement>();
            int rang = 0;
            foreach (Utilisateur utilisateur in utilisateurs)
            {
                rang++;
                decimal soldeAction = Obtenir(utilisateur).Sum(x => x.ValeurActuelle * x.Nombre);
                Classement classement = new Classement
                {
                    Nom = utilisateur.Affichage,
                    Rang = rang,
                    Solde = utilisateur.Solde,
                    SoldeAction = utilisateur.Solde + soldeAction
                };
                classements.Add(classement);
            }
            return classements;
        }

        public IList<Symbole> ObtenirSymboles()
        {
            var client = new RestClient("https://api.iextrading.com/1.0/ref-data/symbols");
            var response = client.Execute<List<Symbole>>(new RestRequest());
            List<Symbole> responseData = response.Data;
            return responseData;
        }

        public static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.ToLocalTime().AddMilliseconds(unixTime);
        }

        public IList<Titre> ObtenirTitreActif()
        {
            IList<Titre> titres = new List<Titre>();
            var client = new RestClient("https://api.iextrading.com/1.0/stock/market/list/mostactive");
            var response = client.Execute<List<TitreActif>>(new RestRequest());
            foreach (TitreActif titreActif in response.Data)
            {
                Titre titre = new Titre
                {
                    Bourse = titreActif.PrimaryExchange,
                    Code = titreActif.Symbol,
                    ValeurActuelle = Convert.ToDecimal(titreActif.LatestPrice.Replace(".", ",")),
                    ValeurOuverture = Convert.ToDecimal(titreActif.Open.Replace(".", ",")),
                    Nom = titreActif.CompanyName,
                    PourcentageVariationEntreFermetureEtActuel = Convert.ToDecimal(titreActif.ChangePercent.Replace(".", ",")),
                };
                titres.Add(titre);
            }
            return titres;
        }

        public Titre RechercherTitreSurInternet(string code)
        {
            Titre titre = new Titre();
            var client = new RestClient("https://api.iextrading.com/1.0/stock/" + code.ToLower() + "/quote");
            var response = client.Execute<List<Quote>>(new RestRequest());
            if (response.Content != "Unknown symbol" && !string.IsNullOrEmpty(code))
            {
                Quote responseData = response.Data.FirstOrDefault();
                titre.ValeurActuelle = Convert.ToDecimal(responseData.LatestPrice.Replace(".", ","));
                titre.Bourse = responseData.PrimaryExchange;
                titre.Nom = responseData.CompanyName;
                titre.DateDerniereTransaction = FromUnixTime(Convert.ToInt64(responseData.LatestUpdate)).ToString();
                titre.Code = code.ToUpper();
                titre.PourcentageVariationEntreFermetureEtActuel = Convert.ToDecimal(responseData.ChangePercent.Replace(".", ","));
                titre.ValeurOuverture = Convert.ToDecimal(responseData.Open.Replace(".", ","));

                var clientLogo = new RestClient("https://api.iextrading.com/1.0/stock/" + code.ToLower() + "/logo");
                var responseTest = clientLogo.Execute<List<Logo>>(new RestRequest());
                Logo logo = responseTest.Data.FirstOrDefault();
                titre.Logo = logo.Url;

            }

            return titre;
        }

        public void RafraichirValeurActuelle(Utilisateur utilisateur)
        {
            IList<Titre> obtenir = Obtenir(utilisateur).Where(x => x.ValeurVendu == 0).ToList();
            foreach (Titre titre in obtenir)
            {
                titre.ValeurActuelle = RechercherTitreSurInternet(titre.Code).ValeurActuelle;
                new BaseDAO<Titre>().Enregistrer(titre);
            }
        }

        public void AcheterTitre(string code, string idUtilisateur, int nombre)
        {
            var utilisateur = DAOUtilisateur.Obtenir(idUtilisateur).FirstOrDefault();
            decimal commission = ObtenirCommission();
            Titre titre = RechercherTitreSurInternet(code);
            titre.Utilisateur = utilisateur;
            titre.DateAchat = DateTime.Now;
            titre.ValeurAchat = titre.ValeurActuelle;
            titre.CommissionAchat = commission;
            titre.Nombre = nombre;
            titre.ValeurOrdrePourVendre = 0;

            if (utilisateur.Solde > titre.ValeurActuelle * nombre + commission)
            {
                utilisateur.Solde = utilisateur.Solde - (titre.ValeurActuelle * nombre + commission);
                new BaseDAO<Utilisateur>().Enregistrer(utilisateur);
                new BaseDAO<Titre>().Enregistrer(titre);
                new NavigationService().RafraichirPage();
            }
            else
            {
                throw new Exception("Vous n'avez pas assez d'argent pour pouvoir passer cette ordre");
            }
        }

        public void VendreTitre(string idTitre, string idUtilisateur)
        {
            var utilisateure = DAOUtilisateur.Obtenir(idUtilisateur).FirstOrDefault();
            Titre titre = new BaseDAO<Titre>().Obtenir().FirstOrDefault(x => x.Id.ToString() == idTitre);
            Titre titreVendu = RechercherTitreSurInternet(titre.Code);
            titre.Utilisateur = utilisateure;
            titre.ValeurVendu = titreVendu.ValeurActuelle;
            titre.CommissionVendu = ObtenirCommission();
            titre.ValeurOrdrePourVendre = 0;
            utilisateure.Solde = utilisateure.Solde + (titre.ValeurVendu * titre.Nombre) - ObtenirCommission();

            new BaseDAO<Titre>().Enregistrer(titre);
            new BaseDAO<Utilisateur>().Enregistrer(utilisateure);
            new NavigationService().RafraichirPage();
        }

        public decimal ObtenirCommission()
        {
            IList<Parametre> parametres = new BaseDAO<Parametre>().Obtenir();
            if (parametres.Count > 0)
            {
                return Convert.ToDecimal(parametres.FirstOrDefault(x => x.Code.ToLower() == "commission").Valeur);
            }
            Parametre parametreEnregistrer = new Parametre
            {
                Code = "commission",
                Valeur = "30"
            };
            new BaseDAO<Parametre>().Enregistrer(parametreEnregistrer);
            return 30;
        }

        public void AjouterOrdre(string idTitre, decimal valeur)
        {
            Titre titre = new BaseDAO<Titre>().Obtenir().FirstOrDefault(x => x.Id.ToString() == idTitre);
            if (titre.ValeurVendu == 0)
            {
                titre.ValeurOrdrePourVendre = valeur;
                new BaseDAO<Titre>().Enregistrer(titre);
            }
        }

        public void EnleverOrdre(string idTitre)
        {
            Titre titre = new BaseDAO<Titre>().Obtenir().FirstOrDefault(x => x.Id.ToString() == idTitre);
            titre.ValeurOrdrePourVendre = 0;
            new BaseDAO<Titre>().Enregistrer(titre);
        }

    }

    public class Logo
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }

    public class Quote
    {
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }
        [JsonProperty(PropertyName = "companyName")]
        public string CompanyName { get; set; }
        [JsonProperty(PropertyName = "primaryExchange")]
        public string PrimaryExchange { get; set; }
        [JsonProperty(PropertyName = "latestPrice")]
        public string LatestPrice { get; set; }
        [JsonProperty(PropertyName = "changePercent")]
        public string ChangePercent { get; set; }
        [JsonProperty(PropertyName = "open")]
        public string Open { get; set; }
        [JsonProperty(PropertyName = "latestUpdate")]
        public string LatestUpdate { get; set; }
    }

    public class TitreActif
    {
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }
        [JsonProperty(PropertyName = "companyName")]
        public string CompanyName { get; set; }
        [JsonProperty(PropertyName = "open")]
        public string Open { get; set; }
        [JsonProperty(PropertyName = "latestPrice")]
        public string LatestPrice { get; set; }
        [JsonProperty(PropertyName = "changePercent")]
        public string ChangePercent { get; set; }
        [JsonProperty(PropertyName = "primaryExchange")]
        public string PrimaryExchange { get; set; }
    }

    public class Symbole
    {
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public string Affichage => "(" + Symbol + ") " + Name;
    }
}
