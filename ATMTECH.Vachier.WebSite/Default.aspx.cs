using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace ATMTECH.Vachier.WebSite
{
    public partial class Default : PageBase
    {
        public int Depart
        {
            get
            {
                if (Session["Depart"] == null) Session["Depart"] = 0;
                return (int)Session["Depart"];
            }
            set { Session["Depart"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)

            {
                DAOLogger.AjouterTraceVisiteur();

                rptVachier.DataSource = new DAOVachier().ObtenirInsulte(Depart);
                rptVachier.DataBind();

                ddlInsulte.DataSource = new DAOVachier().ObtenirFormuleDeMarde();
                ddlInsulte.DataBind();

                rptTopMerdeux.DataSource = new DAOVachier().ObtenirTop10Merdeux();
                rptTopMerdeux.DataBind();

                rptTopVille.DataSource = new DAOVachier().ObtenirTop10Localisation();
                rptTopVille.DataBind();
            }
        }

        protected string FormatterDescription(string description)
        {
            foreach (string formuleMarde in new DAOVachier().ObtenirFormuleDeMarde())
            {
                description = description.Replace(formuleMarde, "<b>" + formuleMarde + "</b>");
            }
            return description;
        }

        protected string ObtenirNombreTotalVote()
        {
            return new DAOVachier().ObtenirNombreTotalVote();
        }
        protected string ObtenirNombreTotalVille()
        {
            return new DAOVachier().ObtenirNombreTotalVille();
        }

        protected void btnAjouterMerdeOnClick(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;

            bool isValidCaptcha = ValidateReCaptcha(ref errorMessage);

            if (isValidCaptcha)
            {
                new DAOVachier().AjouterInsulte(txtTitre.Text, txtDescription.Text, ddlInsulte.Text);
                Response.Redirect("Default.aspx");
            }
        }

        public bool ValidateReCaptcha(ref string errorMessage)
        {
            var sb = new StringBuilder();
            sb.Append("https://www.google.com/recaptcha/api/siteverify?secret=");

            //our secret key
            var secretKey = "6LcmV6UUAAAAAMeykrGC8GBryus30sm_7RxVc_F9";
            sb.Append(secretKey);

            //response from recaptch control
            sb.Append("&");
            sb.Append("response=");
            var reCaptchaResponse = Request["g-recaptcha-response"];
            sb.Append(reCaptchaResponse);

            //client ip address
            //---- This Ip address part is optional. If you donot want to send IP address you can
            //---- Skip(Remove below 4 lines)
            sb.Append("&");
            sb.Append("remoteip=");
            var clientIpAddress = GetUserIp();
            sb.Append(clientIpAddress);

            //make the api call and determine validity
            using (var client = new WebClient())
            {
                var uri = sb.ToString();
                var json = client.DownloadString(uri);
                var serializer = new DataContractJsonSerializer(typeof(RecaptchaApiResponse));
                var ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
                var result = serializer.ReadObject(ms) as RecaptchaApiResponse;

                //--- Check if we are able to call api or not.
                if (result == null)
                {
                    string test = "Captcha was unable to make the api call";
                }
                else // If Yes
                {
                    //api call contains errors
                    if (result.ErrorCodes != null)
                    {
                        if (result.ErrorCodes.Count > 0)
                        {
                            foreach (var error in result.ErrorCodes)
                            {
                                string test = "reCAPTCHA Error: " + error;
                            }
                        }
                    }
                    else //api does not contain errors
                    {
                        if (!result.Success) //captcha was unsuccessful for some reason
                        {
                            string test = "Captcha did not pass, please try again.";
                        }
                        else //---- If successfully verified. Do your rest of logic.
                        {
                            string test = "Captcha cleared ";
                        }
                    }

                }

            }
            return true;
        }
        private string GetUserIp()
        {
            var visitorsIpAddr = string.Empty;

            if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                visitorsIpAddr = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            else if (!string.IsNullOrEmpty(Request.UserHostAddress))
            {
                visitorsIpAddr = Request.UserHostAddress;
            }

            return visitorsIpAddr;
        }

        protected void rptVachierCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Jaime")
            {
                new DAOVachier().AjouterJaimeInsulte(e.CommandArgument.ToString());
                rptVachier.DataSource = new DAOVachier().ObtenirInsulte(Depart);
                rptVachier.DataBind();
            }
        }

        protected void btnPrecedentOnclick(object sender, EventArgs e)
        {
            Depart -= 10;
            if (Depart < 0) Depart = 0;
            txtRecherche.Text = string.Empty;
            rptVachier.DataSource = new DAOVachier().ObtenirInsulte(Depart);
            rptVachier.DataBind();
            lblNombreMerdeTrouve.Visible = false;
        }

        protected void btnSuivantOnclick(object sender, EventArgs e)
        {
            Depart += 10;
            txtRecherche.Text = string.Empty;
            rptVachier.DataSource = new DAOVachier().ObtenirInsulte(Depart);
            rptVachier.DataBind();
            lblNombreMerdeTrouve.Visible = false;
        }

        public string GetIpAddress()
        {
            var ipAddress = string.Empty;

            if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            else if (!string.IsNullOrEmpty(Request.UserHostAddress))
            {
                ipAddress = Request.UserHostAddress;
            }

            return ipAddress;
        }


        protected void btnRechercherMerde_OnClick(object sender, EventArgs e)
        {
            lblNombreMerdeTrouve.Visible = true;    
            IEnumerable<Insulte> enumerable = new DAOVachier().ObtenirInsulte().Where(x => x.Description.IndexOf(txtRecherche.Text) >= 0).Take(100);
            rptVachier.DataSource = enumerable;
            rptVachier.DataBind();
            lblNombreMerdeTrouve.Text = enumerable.Count().ToString() + " merdes retrouvées";
        }
    }

    [DataContract]
    public class RecaptchaApiResponse
    {
        [DataMember(Name = "success")]
        public bool Success { get; set; }

        [DataMember(Name = "error-codes")]
        public List<string> ErrorCodes { get; set; }
    }

}