using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Web.UI.WebControls;
using ATMTECH.Tournoi.DAO;
using ATMTECH.Tournoi.Entites;
using TheArtOfDev.HtmlRenderer;

namespace ATMTECH.Tournoi.WebSite
{
    public partial class Default : System.Web.UI.Page
    {
        public string Filtre
        {
            get
            {
                if (Session["Filtre"] == null) Session["Filtre"] = "";
                return Session["Filtre"].ToString();
            }
            set
            {
                Session["Filtre"] = value;
            }
        }

        public IList<EquipeSaison> ListeEquipeSaison
        {
            get
            {
                Saison saison = new DAOTournoi().ObtenirSaison().FirstOrDefault();
                return new DAOTournoi().ObtenirEquipeSaisonReguliere(saison);
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

        public Saison SaisonCourante
        {
            get
            {
                return new DAOTournoi().ObtenirSaison().FirstOrDefault();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Refresh();
                ddlEquipe.DataSource = ListeEquipeSaison;
                ddlEquipe.DataTextField = "NomEquipe";
                ddlEquipe.DataValueField = "IdEquipe";
                ddlEquipe.DataBind();

            }

        }

        private void Refresh()
        {
            lblNomSaison.Text = SaisonCourante.Nom;
            GridViewPosition.DataSource = ListeEquipeSaison;
            GridViewPosition.DataBind();

            if (!string.IsNullOrEmpty(Filtre))
            {
                IList<MatchSaison> matchSaisons = Horaire.Where(x =>
                        x.Local.Id.ToString() == Filtre || x.Visiteur.Id.ToString() == Filtre)
                    .ToList();
                GridViewHoraire.DataSource = matchSaisons;
            }
            else
            {
                GridViewHoraire.DataSource = Horaire;
            }

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


        protected void SetSortDirection(string sortDirection)
        {

            if (SortDirection == "ASC") SortDirection = "DESC";
            else if (SortDirection == "DESC") SortDirection = "ASC";
            else if (SortDirection == "") SortDirection = "ASC";
        }

        public string SortDirection
        {
            get { return ViewState["SortDirection"] == null ? string.Empty : ViewState["SortDirection"].ToString(); }
            set
            {
                ViewState["SortDirection"] = value;
            }
        }


        protected void TrierGrillePosition(object sender, GridViewSortEventArgs e)
        {
            SetSortDirection(SortDirection);
            if (ListeEquipeSaison != null)
            {
                GridViewPosition.DataSource = SortDirection.ToLower() == "desc" ? TrierPar(ListeEquipeSaison, e.SortExpression + " desc") : TrierPar(ListeEquipeSaison, e.SortExpression + " asc");
                GridViewPosition.DataBind();
            }
        }

        protected void TrierGrilleHoraire(object sender, GridViewSortEventArgs e)
        {
            if (Horaire != null)
            {
                GridViewHoraire.DataSource = Horaire.OrderBy(x => x.Date);// SortDirection.ToLower() == "desc" ? TrierPar(Horaire, e.SortExpression + " desc") : TrierPar(Horaire, e.SortExpression + " asc");
                GridViewHoraire.DataBind();
            }
        }

        public IEnumerable<T> TrierPar<T>(IEnumerable<T> list, string sortExpression)
        {
            sortExpression += "";
            string[] parts = sortExpression.Split(' ');
            bool descending = false;

            if (parts.Length > 0 && parts[0] != "")
            {
                var property = parts[0];

                if (parts.Length > 1)
                {
                    descending = parts[1].ToLower().Contains("esc");
                }

                PropertyInfo prop = typeof(T).GetProperty(property);

                if (prop == null)
                {
                    throw new Exception("No property '" + property + "' in + " + typeof(T).Name + "'");
                }

                if (descending)
                    return list.OrderByDescending(x => prop.GetValue(x, null));
                else
                    return list.OrderBy(x => prop.GetValue(x, null));
            }

            return list;
        }



        protected void GridViewPositionOnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Present") new BaseDAO().ExecuterSql("INSERT INTO Presence (Equipe,Date) VALUES (" + e.CommandArgument + ",Convert(date, getdate())) ");
            if (e.CommandName == "Absent") new BaseDAO().ExecuterSql("DELETE FROM Presence WHERE Equipe = " + e.CommandArgument + " and Date = Convert(date, getdate()) ");
            Refresh();
        }


        protected void btnFiltrerClick(object sender, EventArgs e)
        {
            Filtre = ddlEquipe.SelectedValue;
            Refresh();

        }

        protected void btnResetFiltreClick(object sender, EventArgs e)
        {
            Filtre = "";
            Refresh();
        }
    }


}