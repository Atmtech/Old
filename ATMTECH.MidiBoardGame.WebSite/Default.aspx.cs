using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.MidiBoardGame.DAO;
using ATMTECH.MidiBoardGame.Entites;

namespace ATMTECH.MidiBoardGame.WebSite
{
    public partial class Default1 : Page
    {

        public Utilisateur Utilisateur
        {
            get
            {
                return (Utilisateur)Session["Utilisateur"];
            }
            set { Session["Utilisateur"] = value; }
        }

        public void RemplirListeDeroulante(DropDownList dropDownList, object Source, string colonneAffichage)
        {
            dropDownList.DataSource = Source;
            dropDownList.DataTextField = colonneAffichage;
            dropDownList.DataValueField = "Id";
            dropDownList.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RemplirListeDeroulante(ddlJeu, new DAOJeu().ObtenirListeJeuAvecPresence(), "Nom");
                datalisteVote.DataSource = new DAOProposition().ObtenirListeProposition();
                datalisteVote.DataBind();
              
                datalistePresence.DataSource = new DAOPresence().ObtenirListePresenceAujourdhui();
                datalistePresence.DataBind();
            }

            if (Session["Utilisateur"] != null)
            {
                lblNomUtilisateur.Text = Utilisateur.Nom;
                pnlConnecte.Visible = true;
                pnlDeConnecte.Visible = false;
            }
        }


        protected void btnConnecteClick(object sender, EventArgs e)
        {
            if (new DAOUtilisateur().EstIdentifie(txtCourriel.Text, txtMotPasse.Text))
            {
                Utilisateur = new DAOUtilisateur().ObtenirUtilisateur(txtCourriel.Text, txtMotPasse.Text);
                lblNomUtilisateur.Text = Utilisateur.Nom;
                pnlConnecte.Visible = true;
                pnlDeConnecte.Visible = false;
            }
        }

        protected void btnDeconnecterClick(object sender, EventArgs e)
        {
            Utilisateur = null;
            Response.Redirect("Default.aspx");
        }


        protected void btnCreerClick(object sender, EventArgs e)
        {
            new DAOUtilisateur().Ajouter(txtNomCreer.Text, txtNickNameBoardGameGeek.Text, txtCourrielCreer.Text, txtMotDePasseCreer.Text);
            Utilisateur = new DAOUtilisateur().ObtenirUtilisateur(txtCourrielCreer.Text, txtMotDePasseCreer.Text);
            txtCourrielCreer.Text = string.Empty;
            txtNomCreer.Text = String.Empty;
            txtMotDePasseCreer.Text = String.Empty;
            txtNickNameBoardGameGeek.Text = String.Empty;

            Response.Redirect("Default.aspx");
        }

        protected void btnPresenceClick(object sender, EventArgs e)
        {
            new DAOPresence().Ajouter(Utilisateur, Utilitaires.Aujourdhui());
            Response.Redirect("Default.aspx");
        }

        protected void btnImporterMaListeJeuClick(object sender, EventArgs e)
        {
            datalistListeJeuBoardGameGeek.DataSource = new DAOJeu().ObtenirListeJeuBoardGameGeek(Utilisateur);
            datalistListeJeuBoardGameGeek.DataBind();

            pnlImporterListeJeu.Visible = true;
        }

        protected void datalistListeJeuBoardGameGeekItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Ajouter")
            {
                new DAOJeu().Ajouter(e.CommandArgument.ToString(),"1",Utilisateur);
                datalistListeJeuBoardGameGeek.DataSource = new DAOJeu().ObtenirListeJeuBoardGameGeek(Utilisateur);
                datalistListeJeuBoardGameGeek.DataBind();
            }
           
        }


        protected void datalisteVoteItemDataBound(object sender, DataListItemEventArgs e)
        {
            Proposition proposition = (Proposition)e.Item.DataItem;
            Label lblNombreVote = (Label)e.Item.FindControl("lblNombreVote");
            lblNombreVote.Text = new DAOPropositionVote().ObtenirNombreVote(proposition.Id.ToString()).ToString();
        }

        protected void datalisteVoteItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Vote")
            {
                string idMidi = ((Label)e.Item.FindControl("lblIdMidi")).Text;
                new DAOPropositionVote().Ajouter(idMidi, Utilisateur.Id.ToString());
                Response.Redirect("Default.aspx");
            }
            if (e.CommandName == "Retirer")
            {
                string idMidi = ((Label)e.Item.FindControl("lblIdMidi")).Text;
                new DAOPropositionVote().Retirer(idMidi, Utilisateur.Id.ToString());
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnAjouterJeuMidiClick(object sender, EventArgs e)
        {
            new DAOProposition().Ajouter(ddlJeu.SelectedValue, Utilisateur.Id.ToString());
            Response.Redirect("Default.aspx");
        }

      
    }
}