using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web.UI.WebControls;
using ATMTECH.Tournoi.DAO;
using ATMTECH.Tournoi.Entites;

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

        public IList<MatchSaison> HoraireSaison
        {
            get
            {
                Saison saison = new DAOTournoi().ObtenirSaison().FirstOrDefault();
                return new DAOTournoi().ObtenirMatchSaisonReguliere(saison);
            }
        }

        public IList<MatchSerie> MatchSeries
        {
            get { return new DAOTournoi().ObtenirMatchSerie(new Serie { Id = 1 }); }
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
                IList<MatchSaison> matchSaisons = HoraireSaison.Where(x =>
                        x.Local.Id.ToString() == Filtre || x.Visiteur.Id.ToString() == Filtre)
                    .ToList();
                GridViewHoraire.DataSource = matchSaisons;
            }
            else
            {
                GridViewHoraire.DataSource = HoraireSaison;
            }
            GridViewHoraire.DataBind();
            lblPartieTotalAJouer.Text = "Partie à jouer: " + (HoraireSaison.Count() - HoraireSaison.Count(x => x.Gagnant.Id != 0)) + " sur " + HoraireSaison.Count();

            GridViewSerieRonde1.DataSource = MatchSeries.Where(x=>x.Ronde == 1);
            GridViewSerieRonde1.DataBind();

            GridViewSerieRonde2.DataSource = MatchSeries.Where(x => x.Ronde == 2);
            GridViewSerieRonde2.DataBind();

            GridViewSerieRonde3.DataSource = MatchSeries.Where(x => x.Ronde == 3);
            GridViewSerieRonde3.DataBind();

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
            if (HoraireSaison != null)
            {
                GridViewHoraire.DataSource = HoraireSaison.OrderBy(x => x.Date);// SortDirection.ToLower() == "desc" ? TrierPar(HoraireSaison, e.SortExpression + " desc") : TrierPar(HoraireSaison, e.SortExpression + " asc");
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