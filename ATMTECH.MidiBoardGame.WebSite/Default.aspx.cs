using System;
using System.Linq;
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
                RemplirListeDeroulante(ddlJeu, new DAOJeu().ObtenirListeJeuAvecPresence().OrderBy(x=>x.Nom), "Nom");
                datalisteVote.DataSource = new DAOProposition().ObtenirListeProposition();
                datalisteVote.DataBind();
                datalistePresence.DataSource = new DAOPresence().ObtenirListePresenceAujourdhui();
                datalistePresence.DataBind();
            }

            if (Session["Utilisateur"] != null)
            {
                lblNomUtilisateur.Text = Utilisateur.Nom;
            }
            else
            {
                Response.Redirect("Identification.aspx");
            }
        }




        protected void btnDeconnecterClick(object sender, EventArgs e)
        {
            Utilisateur = null;
            Response.Redirect("Default.aspx");
        }




        protected void btnPresenceClick(object sender, EventArgs e)
        {
            new DAOPresence().Ajouter(Utilisateur, Utilitaires.Aujourdhui());
            Response.Redirect("Default.aspx");

        }

        protected void btnAjouterJeuMidiClick(object sender, EventArgs e)
        {
            new DAOProposition().Ajouter(ddlJeu.SelectedValue, Utilisateur.Id.ToString());
            Response.Redirect("Default.aspx");
        }


        protected void btnMonProfileClick(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void datalisteVoteItemCommand(object source, RepeaterCommandEventArgs e)
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

        protected void datalisteVoteItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Proposition proposition = (Proposition)e.Item.DataItem;
            Label lblNombreVote = (Label)e.Item.FindControl("lblNombreVote");
            lblNombreVote.Text = new DAOPropositionVote().ObtenirNombreVote(proposition.Id.ToString()).ToString();
        }

        protected void datalistePresenceItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Retirer")
            {
                new DAOPresence().Retirer(Convert.ToInt32(e.CommandArgument), Utilitaires.Aujourdhui(), Utilisateur);
                Response.Redirect("Default.aspx");
            }
        }
    }
}