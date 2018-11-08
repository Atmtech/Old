using System;
using System.Web.UI.WebControls;

namespace ATMTECH.Expeditn.Site
{
    public partial class TableauBordPage : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifierAcces();

            if (!Page.IsPostBack)
            {
                repeaterExpedition.DataSource = ExpeditionService.ObtenirMesExpedition(PageMaitre.UtilisateurAuthentifie);
                repeaterExpedition.DataBind();
                repeaterSuiviPrix.DataSource = SuiviPrixService.ObtenirsuiviPrix(PageMaitre.UtilisateurAuthentifie);
                repeaterSuiviPrix.DataBind();
            }
        }

        protected void repeaterExpedition_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Modifier")
            {
                Response.Redirect("ModifierExpedition.aspx?IdExpedition=" + e.CommandArgument);
            }
        }

        protected void btnAjouterExpedition_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("AjouterExpedition.aspx");
        }

        protected void repeaterSuiviPrix_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Modifier")
            {
                Response.Redirect("ModifierSuiviPrix.aspx?IdSuiviPrix=" + e.CommandArgument);
            }
        }

        protected void btnAjouterSuiviDePrix_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("AjouterSuiviPrix.aspx");
        }
    }
}