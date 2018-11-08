using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ATMTECH.Expeditn.Entites;
using MongoDB.Bson;

namespace ATMTECH.Expeditn.Site.UserControl
{
    public partial class CoutActivites : UserControlBase
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
            ddlParticipantDepense.DataSource = expedition.ListeUtilisateur;
            ddlParticipantDepense.DataTextField = "Affichage";
            ddlParticipantDepense.DataValueField = "Id";
            ddlParticipantDepense.DataBind();

            ddlParticipantReset.DataSource = expedition.ListeUtilisateur;
            ddlParticipantReset.DataTextField = "Affichage";
            ddlParticipantReset.DataValueField = "Id";
            ddlParticipantReset.DataBind();

            if (expedition.ListeActivite != null)
            {
                ddlTypeActivite.DataSource = expedition.ListeActivite.GroupBy(x => x.TypeActivite).ToList().Select(activiteGroupe => activiteGroupe.Key).ToList();
                ddlTypeActivite.DataBind();
            }

            placeHolderDepense.Controls.Clear();
            placeHolderDepense.Controls.Add(new Literal { Text = ExpeditionService.GenererAffichageDepense(expedition) });


        }


        protected void btnAjouterDepense_OnClick(object sender, EventArgs e)
        {
            Expedition expedition = ExpeditionService.Obtenir(IdExpedition);
            Utilisateur utilisateur = UtilisateurService.Obtenir(ddlParticipantDepense.SelectedValue);
            if (expedition.ListeDepense == null) expedition.ListeDepense = new List<Depense>();

            Depense depense = new Depense
            {
                Utilisateur = utilisateur,
                Montant = txtMontant.Text,
                TypeActivite = ddlTypeActivite.Text
            };
            ExpeditionService.Enregistrer(depense);
            expedition.ListeDepense.Add(depense);
            ExpeditionService.Enregistrer(expedition);
            NavigationService.RafraichirPage();
        }

        protected void btnFermerModal_OnClick(object sender, EventArgs e)
        {
            NavigationService.RafraichirPage();
        }

        protected void btnInitialiserRepartition_OnClick(object sender, EventArgs e)
        {
            Expedition expedition = ExpeditionService.Obtenir(IdExpedition);
            IList<Depense> depenses = new List<Depense>();
            foreach (Depense depense in expedition.ListeDepense)
            {
                if (depense.Utilisateur.Id != ObjectId.Parse(ddlParticipantReset.SelectedValue))
                {
                    depenses.Add(depense);
                }
                else
                {
                    ExpeditionService.Supprimer(depense);
                }
            }
            expedition.ListeDepense = depenses;
            ExpeditionService.Enregistrer(expedition);
           NavigationService.RafraichirPage();
        }
    }
}