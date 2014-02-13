using System;
using System.Configuration;
using ATMTECH.BDD.Object.Base;

namespace ATMTECH.BDD.Object
{
    public class Page : Element
    {

        public Page(string url)
        {
            Naviguer(ObtenirUrlAbsolu(url));
        }

        protected void Naviguer(string url)
        {
            Driver.Navigate().GoToUrl(url);

        }

        private static readonly Uri _baseUri = new Uri(ConfigurationManager.AppSettings["BaseURI"]);

        private string ObtenirUrlAbsolu(string chemin)
        {
            return chemin.StartsWith("http") ? chemin : new Uri(_baseUri, chemin).AbsoluteUri;
        }

    }
}
