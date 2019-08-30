using ATMTECH.PredictionNHL.Entites;
using System;
using System.Web.UI.WebControls;

namespace ATMTECH.PredictionNHL.Web
{
    public partial class TableauBordPage : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifierAcces();

            if (!Page.IsPostBack)
            {
                ddlDatePrediction.DataSource = NhlService.ObtenirDateSaison();
                ddlDatePrediction.DataBind();

                
                Refresh();

            }
        }

        protected void ddlDatePrediction_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            repeaterPrediction.DataSource = NhlService.ConvertirCeduleVisiteurLocal(ddlDatePrediction.SelectedValue, ddlDatePrediction.SelectedValue, PageMaitre.UtilisateurAuthentifie);
            repeaterPrediction.DataBind();

            repeaterClassement.DataSource = ClassementService.ObtenirClassement(NhlService.ObtenirDateDebutSaison());
            repeaterClassement.DataBind();
        }

        protected void repeaterPrediction_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "enregistrer")
            {
                int rowid = (e.Item.ItemIndex);
                TextBox txtPredictionPointageLocal = (TextBox)repeaterPrediction.Items[rowid].FindControl("txtPredictionPointageLocal");
                TextBox txtPredictionPointageVisiteur = (TextBox)repeaterPrediction.Items[rowid].FindControl("txtPredictionPointageVisiteur");

                Prediction prediction = new Prediction
                {
                    GamePrimaryKey = Convert.ToInt32(((Label)repeaterPrediction.Items[rowid].FindControl("lblGamePrimaryKey")).Text),
                    Utilisateur = PageMaitre.UtilisateurAuthentifie,
                    PointageLocal = Convert.ToInt32(txtPredictionPointageLocal.Text),
                    PointageVisiteur = Convert.ToInt32(txtPredictionPointageVisiteur.Text)
                };


                if (prediction.PointageLocal == prediction.PointageVisiteur)
                {
                    PageMaitre.AfficherMessage("Vous ne pouvez pas enregistrer un pointage nul", TypeMessage.Erreur);
                }
                else
                {
                    PredictionService.Enregistrer(prediction);
                    Refresh();
                }
            }
        }

        //protected void repeaterExpedition_OnItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "Modifier")
        //    {
        //        Response.Redirect("ModifierExpedition.aspx?IdExpedition=" + e.CommandArgument);
        //    }
        //}

        //protected void btnAjouterExpedition_OnClick(object sender, EventArgs e)
        //{
        //    Response.Redirect("AjouterExpedition.aspx");
        //}

        //protected void repeaterSuiviPrix_OnItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "Modifier")
        //    {
        //        Response.Redirect("ModifierSuiviPrix.aspx?IdSuiviPrix=" + e.CommandArgument);
        //    }
        //}

        //protected void btnAjouterSuiviDePrix_OnClick(object sender, EventArgs e)
        //{
        //    Response.Redirect("AjouterSuiviPrix.aspx");
        //}
    }
}