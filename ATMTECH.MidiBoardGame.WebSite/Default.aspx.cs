using System;
using System.Web.UI;
using System.Web.UI.WebControls;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RemplirListeDeroulante(ddlJeu, new DAOJeu().ObtenirListeJeu(), "Nom");
                datalisteVote.DataSource = new DAOMidi().ObtenirListeMidi();
                datalisteVote.DataBind();
            }

            if (Session["Utilisateur"] != null)
            {
                lblNomUtilisateur.Text = Utilisateur.Nom;
                pnlConnecte.Visible = true;
                pnlDeConnecte.Visible = false;
            }


        }

        public void RemplirListeDeroulante(DropDownList dropDownList, object Source, string colonneAffichage)
        {
            dropDownList.DataSource = Source;
            dropDownList.DataTextField = colonneAffichage;
            dropDownList.DataValueField = "Id";
            dropDownList.DataBind();
        }


        protected void btnAjouterJeuClick(object sender, EventArgs e)
        {
            new DAOJeu().Ajouter(txtNomJeu.Text);
            RemplirListeDeroulante(ddlJeu, new DAOJeu().ObtenirListeJeu(), "Nom");
            txtNomJeu.Text = "";
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

        protected void btnCreerClick(object sender, EventArgs e)
        {
            new DAOUtilisateur().Ajouter(txtNomCreer.Text, txtCourrielCreer.Text, txtMotDePasseCreer.Text);
            Utilisateur = new DAOUtilisateur().ObtenirUtilisateur(txtCourrielCreer.Text, txtMotDePasseCreer.Text);
            txtCourrielCreer.Text = string.Empty;
            txtNomCreer.Text = String.Empty;
            txtMotDePasseCreer.Text = String.Empty;

            Response.Redirect("Default.aspx");
        }

        protected void btnAjouterJeuMidiClick(object sender, EventArgs e)
        {
            new DAOMidi().Ajouter(ddlJeu.SelectedValue, Utilisateur.Id.ToString());
            Response.Redirect("Default.aspx");
        }

        protected void datalisteVoteItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Vote")
            {
                string idMidi = ((Label)e.Item.FindControl("lblIdMidi")).Text;
                new DAOMidiVote().Ajouter(idMidi, Utilisateur.Id.ToString());
                Response.Redirect("Default.aspx");
            }
            if (e.CommandName == "Retirer")
            {
                string idMidi = ((Label)e.Item.FindControl("lblIdMidi")).Text;
                new DAOMidiVote().Retirer(idMidi, Utilisateur.Id.ToString());
                Response.Redirect("Default.aspx");
            }
        }

        protected void datalisteVoteItemDataBound(object sender, DataListItemEventArgs e)
        {
            Midi midi = (Midi)e.Item.DataItem;
            Label lblNombreVote = (Label)e.Item.FindControl("lblNombreVote");
            lblNombreVote.Text = new DAOMidiVote().ObtenirNombreVote(midi.Id.ToString()).ToString();
        }

        protected void btnDeconnecterClick(object sender, EventArgs e)
        {
            Utilisateur = null;
            Response.Redirect("Default.aspx");
        }
    }
}