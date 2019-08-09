using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ATMTECH.Vachier.WebSite
{
    public partial class admin : System.Web.UI.Page
    {
        public IList<Insulte> Insultes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Insultes = new DAOVachier().ObtenirInsulte().ToList();
            lblCompte.Text = Insultes.Count.ToString();
        }

        protected void btnTestClick(object sender, EventArgs e)
        {
            lblHttp.Text = "";
            IList<Insulte> obtenirInsulte = new DAOVachier().ObtenirInsulte();
            IList<Exclusion> listeAExclure = new List<Exclusion>();

            string jsonInput = System.IO.File.ReadAllText(Server.MapPath("exclusion.json"));
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            List<Exclusion> listeExclusions = jsonSerializer.Deserialize<List<Exclusion>>(jsonInput);

            string jsonInclusion = System.IO.File.ReadAllText(Server.MapPath("inclusion.json"));
            JavaScriptSerializer jsInclusion = new JavaScriptSerializer();
            List<Inclusion> listeInclusions = jsInclusion.Deserialize<List<Inclusion>>(jsonInclusion);




            foreach (Insulte insulte in obtenirInsulte)
            {
                if (insulte.Description.IndexOf("http:", StringComparison.Ordinal) > 0)
                {
                    string url = insulte.Description.Substring(insulte.Description.IndexOf("http:"), insulte.Description.Length - insulte.Description.IndexOf("http:")).Trim();
                    int positionEspace = url.IndexOf(" ");

                    if (positionEspace != -1)
                        url = url.Substring(0, positionEspace);
                    if (Uri.TryCreate(url, UriKind.Absolute, out var uriResult) && uriResult.Scheme == Uri.UriSchemeHttp)
                    {
                        if (!EstDansListeExclusion(listeExclusions, url))
                        {
                            if (!EstDansListeInclusion(listeInclusions, url))
                            {
                                listeAExclure.Add(new Exclusion
                                {
                                    Url = string.Format("{{ \"Url\":\"{0}\" }},<br>", url)
                                });
                            }
                        }
                    }
                }

                if (insulte.Description.IndexOf("https:", StringComparison.Ordinal) > 0)
                {
                    string url = insulte.Description.Substring(insulte.Description.IndexOf("https:"), insulte.Description.Length - insulte.Description.IndexOf("https:")).Trim();
                    int positionEspace = url.IndexOf(" ");

                    if (positionEspace != -1)
                        url = url.Substring(0, positionEspace);
                    if (Uri.TryCreate(url, UriKind.Absolute, out var uriResult) && uriResult.Scheme == Uri.UriSchemeHttps)
                    {
                        if (!EstDansListeExclusion(listeExclusions, url))
                        {
                            if (!EstDansListeInclusion(listeInclusions, url))
                            {
                                listeAExclure.Add(new Exclusion
                                {
                                    Url = string.Format("{{ \"Url\":\"{0}\" }},<br>", url)
                                });
                            }
                        }
                    }
                }

            }


            foreach (Exclusion liste in listeAExclure.Distinct())
            {

                lblHttp.Text += liste.Url;
            }
        }


        private bool EstDansListeInclusion(List<Inclusion> inclusions, string url)
        {
            foreach (Inclusion inclusion in inclusions)
            {
                if (inclusion.Url.IndexOf(url) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        private bool EstDansListeExclusion(List<Exclusion> listeExclusions, string url)
        {
            return listeExclusions.Any(exclusion => exclusion.Url.Contains(url));
        }
        protected void btnTest2Click(object sender, EventArgs e)
        {

            IList<Insulte> insultes = Insultes;
            string jsonInput = System.IO.File.ReadAllText(Server.MapPath("exclusion.json"));
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            List<Exclusion> exclusion = jsonSerializer.Deserialize<List<Exclusion>>(jsonInput);

            foreach (Insulte insulte in insultes)
            {
                if (exclusion.Any(exclusion1 => insulte.Description.Contains(exclusion1.Url)))
                {
                    new DAOVachier().SupprimerInsulte(insulte);
                }
            }
        }

        protected void btnTest3Click(object sender, EventArgs e)
        {
            lblHttp.Text = new DAOVachier().EstExclus(txtExclus.Text, Server.MapPath("/")).ToString();
        }
    }

    public class Exclusion
    {
        public string Url { get; set; }
    }

    public class Inclusion
    {
        public string Url { get; set; }
    }
}