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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTestClick(object sender, EventArgs e)
        {
            IList<Insulte> obtenirInsulte = new DAOVachier().ObtenirInsulte();
            IList<Exclusion> exclusions = new List<Exclusion>();
            foreach (Insulte insulte in obtenirInsulte)
            {
                if (insulte.Description.IndexOf("http:") > 0)
                {
                    string substring = insulte.Description.Substring(insulte.Description.IndexOf("http:"), insulte.Description.Length - insulte.Description.IndexOf("http:")).Trim();
                    int positionEspace = substring.IndexOf(" ");
                    if (positionEspace == -1)
                        exclusions.Add(new Exclusion
                        {
                            Url = string.Format("{{ \"Url\":\"{0}\" }}<br>",substring.Substring(0, substring.Length))
                        });

                    else
                    {
                        exclusions.Add(new Exclusion
                        {
                            Url = string.Format("{{ \"Url\":\"{0}\" }}<br>", substring.Substring(0, positionEspace))
                        });
                    }
                }
            }

            foreach (Exclusion exclusion in exclusions.Distinct())
            {
                lblHttp.Text += exclusion.Url;
            }
        }

        protected void btnTest2Click(object sender, EventArgs e)
        {
            //IList<Exclusion> exclusions = new List<Exclusion>();

            //exclusions.Add(new Exclusion{Url = "http:1"});
            //exclusions.Add(new Exclusion { Url = "http:2"});

            //string serializeObject = JsonConvert.SerializeObject(exclusions);


            string jsonInput = System.IO.File.ReadAllText(Server.MapPath("exclusion.json"));
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            List<Exclusion> exclusion = jsonSerializer.Deserialize<List<Exclusion>>(jsonInput);


            //string json = System.IO.File.ReadAllText(Server.MapPath("exclusion.json"));

            //JObject o = JObject.Parse(json);
            //foreach (var VARIABLE in o)
            //{
            //    string variableKey = VARIABLE.Key;
            //    string valeur = VARIABLE.Value.ToString();
            //}
        }
    }

    public class Exclusion
    {
        public string Url { get; set; }
    }
}