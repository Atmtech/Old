using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ATMTECH.Expeditn.Entites;
using ATMTECH.Expeditn.Services;

namespace ATMTECH.Expeditn.Site.UserControl
{
    public partial class Participant : UserControlBase
    {
        public event EventHandler SurAction;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Affichage();

            }
        }

        public void Affichage()
        {
            Expedition expedition = ExpeditionService.Obtenir(IdExpedition);
            repeaterParticipant.DataSource = expedition.ListeUtilisateur;
            repeaterParticipant.DataBind();
        }

        protected void btnFermerModalClick(object sender, EventArgs e)
        {
            NavigationService.RafraichirPage();
        }

        
        protected void repeaterParticipantItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Enlever")
            {
                Expedition expedition = ExpeditionService.Obtenir(IdExpedition);
                Utilisateur utilisateurAEnlever = UtilisateurService.Obtenir(e.CommandArgument.ToString());
                foreach (Utilisateur utilisateur in expedition.ListeUtilisateur)
                {
                    if (utilisateur.Id == utilisateurAEnlever.Id)
                    {
                        expedition.ListeUtilisateur.Remove(utilisateur);
                        break;
                    }
                }

                ExpeditionService.Enregistrer(expedition);
                repeaterParticipant.DataSource = expedition.ListeUtilisateur;
                repeaterParticipant.DataBind();

                SurAction?.Invoke(this, EventArgs.Empty);

            }
        }

        protected void repeaterParticipantItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Expedition expedition = ExpeditionService.Obtenir(IdExpedition);

            if ((e.Item.DataItem as Utilisateur).Id == expedition.Administrateur.Id)
            {
                (e.Item.FindControl("btnEnlever") as Button).Visible = false;
                (e.Item.FindControl("lblEstAdministrateur") as Label).Visible = true;
            }
            else
            {
                (e.Item.FindControl("lblEstAdministrateur") as Label).Visible = false;
            }
        }


        protected void btnRechercher_OnClick(object sender, EventArgs e)
        {
            Rechercher();
        }

        private void Rechercher()
        {
            IList<Utilisateur> obtenirUtilisateur = UtilisateurService.Obtenir();
            IList<Utilisateur> retrouve = new List<Utilisateur>();

            Expedition expedition = ExpeditionService.Obtenir(IdExpedition);

            foreach (Utilisateur utilisateur in obtenirUtilisateur)
            {
                foreach (string s in txtRechercherUtilisateur.Text.ToLower().Split(' '))
                {
                    if (utilisateur.Recherche.Contains(s))
                    {
                        if (!retrouve.Contains(utilisateur))
                            if (expedition.ListeUtilisateur.FirstOrDefault(x => x.Id == utilisateur.Id) == null)
                                retrouve.Add(utilisateur);
                    }
                }
            }

            repeaterListeUtilisateur.DataSource = retrouve;
            repeaterListeUtilisateur.DataBind();
        }

        protected void repeaterListeUtilisateur_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Ajouter")
            {
                Expedition expedition = ExpeditionService.Obtenir(IdExpedition);
                Utilisateur utilisateur = new UtilisateurService().Obtenir(e.CommandArgument.ToString());
                if (expedition.ListeUtilisateur.All(x => x.Id != utilisateur.Id))
                {
                    expedition.ListeUtilisateur.Add(utilisateur);
                }
                ExpeditionService.Enregistrer(expedition);
                Rechercher();
            }
        }
    }
}