using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

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
              description =  description.Replace(formuleMarde, "<b>" + formuleMarde + "</b>");
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
            new DAOVachier().AjouterInsulte(txtTitre.Text, txtDescription.Text);
            Response.Redirect("Default.aspx");
            ;
        }

        protected void rptVachierCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Jaime")
            {
                new DAOVachier().AjouterJaimeInsulte(e.CommandArgument.ToString());
                Response.Redirect("Default.aspx");
            }
            
        }

        protected void btnPrecedentOnclick(object sender, EventArgs e)
        {
            Depart -= 18;
            if (Depart < 0) Depart = 0;
            rptVachier.DataSource = new DAOVachier().ObtenirInsulte(Depart);
            rptVachier.DataBind();
        }

        protected void btnSuivantOnclick(object sender, EventArgs e)
        {
            Depart += 18;
            rptVachier.DataSource = new DAOVachier().ObtenirInsulte(Depart);
            rptVachier.DataBind();
        }

        protected void btnTestOnclick(object sender, EventArgs e)
        {
            new DAOVachier().AjouterInsulte("test","crevette");
        }
    }
}