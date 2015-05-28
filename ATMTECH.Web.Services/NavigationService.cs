using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using ATMTECH.Common.Constant;
using ATMTECH.Common.Context;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Entities;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Web.Services
{
    public class NavigationService : BaseService, INavigationService
    {
        public IDAOTitrePage DAOTitrePage { get; set; }
        public IDAOProduit DAOProduit { get; set; }

        public void AjouterPageFilArianne(string page, string langue)
        {
            Product obtenirProduit = null;
            if (page.IndexOf("AddProductToBasket") > 0)
            {
                int id = Convert.ToInt32(page.Substring(page.IndexOf("ProductId") + 10, page.Length - page.IndexOf("ProductId") - 10));
                obtenirProduit = DAOProduit.ObtenirProduit(id);
            }

            FilArianne filArianne = new FilArianne();
            filArianne.Page = page;
            filArianne.Titre = obtenirProduit != null
                ? (langue == LocalizationLanguage.FRENCH ? obtenirProduit.NameFrench : obtenirProduit.NameEnglish)
                : ObtenirTitrePage(page, langue);

            ListePageAcceder.Add(filArianne);
        }

        public string ObtenirTitrePage(string page, string langue)
        {
            string pageSimple = Path.GetFileName(page);
            TitrePage titrePage = DAOTitrePage.ObtenirTitrePage(pageSimple);
            if (titrePage == null) return "N/A";
            return langue == LocalizationLanguage.FRENCH ? titrePage.TitreFr : titrePage.TitreEn;
        }

        public IList<FilArianne> ListePageAcceder
        {
            get
            {
                if (HttpContext.Current.Session["ListePageAcceder"] == null)
                    HttpContext.Current.Session["ListePageAcceder"] = new List<FilArianne>();
                return HttpContext.Current.Session["ListePageAcceder"] as IList<FilArianne>;
            }
            set
            {
                HttpContext.Current.Session["ListePageAcceder"] = value;
            }
        }

        public void Redirect(string page)
        {
            ContextSessionManager.Context.Response.Redirect(page);
        }
        public void Redirect(string page, IList<QueryString> queryString)
        {
            string queryStringTemp = string.Empty;

            foreach (QueryString s in queryString)
            {
                queryStringTemp += s.Name + "=" + s.Value + "&";
            }
            ContextSessionManager.Context.Response.Redirect(page + "?" + queryStringTemp);
        }


        private string CapitalizeFirst(string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1).ToLower();
        }
        public CountryIp GetInformationIpInfoDb()
        {
            try
            {
                string ip = ContextSessionManager.Context.Request.UserHostName;
                if (ip != "127.0.0.1" && ip != "::1")
                {

                    string url = string.Format("http://api.ipinfodb.com/v3/ip-city/?key=784b00c1233a988d47b6bfbfbd2fa55dc41279ec9781162bbe9d7ce36d001b0f&ip={0}", ip);
                    using (WebClient client = new WebClient())
                    {
                        string s = client.DownloadString(url);
                        string[] response = s.Split(';');
                        CountryIp countryIp = new CountryIp
                            {
                                Ip = ip,
                                CountryName = CapitalizeFirst(response[4]),
                                Region = CapitalizeFirst(response[5]),
                                City = CapitalizeFirst(response[6]),
                                PostalCode = response[7]
                            };
                        return countryIp;
                    }
                }
            }
            catch (System.Exception)
            {


            }


            return null;

        }

        public void Refresh()
        {
            ContextSessionManager.Context.Response.Redirect(ContextSessionManager.Context.Request.RawUrl);
        }
        public void Refresh(IList<QueryString> queryStrings)
        {
            string queryStringTemp = queryStrings.Aggregate(string.Empty, (current, s) => current + (s.Name + "=" + s.Value + "&"));

            if (ContextSessionManager.Context.Request.RawUrl.IndexOf("?") == -1)
            {
                ContextSessionManager.Context.Response.Redirect(ContextSessionManager.Context.Request.RawUrl + "?" + queryStringTemp);
            }
            else
            {
                ContextSessionManager.Context.Response.Redirect(ContextSessionManager.Context.Request.RawUrl + queryStringTemp);
            }

        }
        public IList<QueryString> GetQueryString()
        {
            return QueryString.GetQueryString();
        }

        public string GetQueryStringValue(string key)
        {
            return QueryString.GetQueryStringValue(key);
        }
    }

    public class FilArianne
    {
        public string Titre { get; set; }
        public string Page { get; set; }
        public string NomProduit { get; set; }
    }
}
