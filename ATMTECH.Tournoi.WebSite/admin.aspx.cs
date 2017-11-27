using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using ATMTECH.Tournoi.DAO;
using ATMTECH.Tournoi.Entites;

namespace ATMTECH.Tournoi.WebSite
{
    public partial class admin : System.Web.UI.Page
    {
        public Saison SaisonCourante
        {
            get
            {
                return new DAOTournoi().ObtenirSaison().FirstOrDefault();
            }
        }

        public IList<MatchSaison> Horaire
        {
            get
            {
                Saison saison = new DAOTournoi().ObtenirSaison().FirstOrDefault();
                return new DAOTournoi().ObtenirMatchSaisonReguliere(saison);
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Refresh();
            }
        }

        private void Refresh()
        {
            GridViewHoraire.DataSource = Horaire;
            GridViewHoraire.DataBind();

            lblPartieTotalAJouer.Text = "Partie à jouer: " + (Horaire.Count() - Horaire.Count(x => x.Gagnant.Id != 0)) + " sur " + Horaire.Count();
            //GridViewHelper helper = new GridViewHelper(this.GridViewHoraire);
            //helper.RegisterGroup("Date", true, true);
            //helper.GroupHeader += helper_GroupHeader;

            //helper.ApplyGroupSort();

        }

        private void helper_GroupHeader(string groupname, object[] values, GridViewRow row)
        {
            if (groupname == "Date")
            {
                row.BackColor = Color.LightGray;

                DateTime test = Convert.ToDateTime(row.Cells[0].Text);

                row.Cells[0].Text = string.Format("<div style='padding:5px 5px 5px 5px;font-weight:bold;'>Parties du {0}</div>", test.ToString("dddd dd MMMM , yyyy"));
            }
        }

        protected void TrierGrilleHoraire(object sender, GridViewSortEventArgs e)
        {
            if (Horaire != null)
            {
                GridViewHoraire.DataSource = Horaire.OrderBy(x => x.Date);// SortDirection.ToLower() == "desc" ? TrierPar(HoraireSaison, e.SortExpression + " desc") : TrierPar(HoraireSaison, e.SortExpression + " asc");
                GridViewHoraire.DataBind();
            }
        }

        protected void btnFaireCalendrierClick(object sender, EventArgs e)
        {
            new DAOTournoi().ConstruireCalendrier(SaisonCourante, Convert.ToInt32(txtIdNombrePartieParJour.Text), Convert.ToDateTime(txtDateDepart.Text), Convert.ToInt32(txtNombreMatchAvecChacun.Text));
        }

        protected void btnAccueilClick(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }


        protected void btnSaveMatchClick(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewHoraire.Rows)
            {
                TextBox txtId = (TextBox)row.FindControl("txtId");
                TextBox txtIdLocal = (TextBox)row.FindControl("txtIdLocal");
                TextBox txtIdVisiteur = (TextBox)row.FindControl("txtIdVisiteur");
                TextBox txtScoreLocal = (TextBox)row.FindControl("txtScoreLocal");
                TextBox txtScoreVisiteur = (TextBox)row.FindControl("txtScoreVisiteur");

                DropDownList ddlProlongation = (DropDownList)row.FindControl("ddlProlongation");
                TextBox txtMessage = (TextBox)row.FindControl("txtMessage");

                string idGagnant;
                string idPerdant;
                string nombreButGagnant;
                string nombreButPerdant;
                string nombrePointGagnant = "2";
                string nombrePointPerdant = "0";
                if (!string.IsNullOrEmpty(txtScoreLocal.Text))
                {
                    if (Convert.ToInt32(txtScoreLocal.Text) > Convert.ToInt32(txtScoreVisiteur.Text))
                    {
                        idGagnant = txtIdLocal.Text;
                        nombreButGagnant = txtScoreLocal.Text;
                        idPerdant = txtIdVisiteur.Text;
                        nombreButPerdant = txtScoreVisiteur.Text;
                    }
                    else
                    {
                        idGagnant = txtIdVisiteur.Text;
                        nombreButGagnant = txtScoreVisiteur.Text;
                        idPerdant = txtIdLocal.Text;
                        nombreButPerdant = txtScoreLocal.Text;
                    }
                    if (ddlProlongation.SelectedValue == "1")
                        nombrePointPerdant = "1";
                    if (Convert.ToInt32( nombreButGagnant) + Convert.ToInt32(nombreButPerdant) > 0)
                    {
                        string sql = string.Format("UPDATE MatchSaison SET [Message] = '{0}'," +
                                                   "[PerteEnSurtemps] = {1}," +
                                                   "[Gagnant] = {2}," +
                                                   "[Perdant] = {3}," +
                                                   "[NombreButGagnant] = {4}," +
                                                   "[NombreButPerdant] = {5}," +
                                                   "[NombrePointGagnant] =  {6}," +
                                                   "[NombrePointPerdant] =  {7} " +
                                                   "WHERE Id = {8}", txtMessage.Text.Replace("'", "''"), ddlProlongation.SelectedValue, idGagnant, idPerdant, nombreButGagnant, nombreButPerdant, nombrePointGagnant, nombrePointPerdant, txtId.Text);

                        new BaseDAO().ExecuterSql(sql);
                    }
                  
                }
            }
            Refresh();
            //  Response.Redirect("~/admin.aspx");
        }

        protected void btnRafraichirClick(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}