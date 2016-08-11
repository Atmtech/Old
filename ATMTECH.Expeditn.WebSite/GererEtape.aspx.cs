using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Entities.DTO;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class GererEtape : PageBase<GererEtapePresenter, IGererEtapePresenter>, IGererEtapePresenter
    {
        public Expedition Expedition
        {
            set { lblNomExpedition.Text = value.Nom; }
        }

        public string IdExpedition
        {
            get { return QueryString.GetQueryStringValue(BaseEntity.ID); }
        }

        public IList<Etape> ListeEtape
        {
            set
            {
                listeActivite.DataSource = value;
                listeActivite.DataBind();
            }
        }

        public IList<Vehicule> ListeVehicule { set { FillDropDown(ddlVehicule, value); } }
        public string IdVehicule { get { return ddlVehicule.SelectedValue; } }
        public string Nom { get { return txtNomEtape.Text; } set { txtNomEtape.Text = value; } }
        public DateTime Debut { get { return Convert.ToDateTime(txtDebutEtape.Text); } set { txtDebutEtape.Text = value.ToString(); } }
        public DateTime Fin { get { return Convert.ToDateTime(txtFinEtape.Text); } set { txtFinEtape.Text = value.ToString(); } }
        public string Distance { get { return txtDistance.Text; } set { txtDistance.Text = value; } }

        protected void lnkPasserEtape4CreationExpeditionClick(object sender, EventArgs e)
        {
            Presenter.RedirigerPageGererNourriture();
        }

        protected void lnkAjouterActiviteExpeditionClick(object sender, EventArgs e)
        {
            Presenter.AjouterEtape();
            txtNomEtape.Text = "";
            txtDebutEtape.Text = "";
            txtDistance.Text = "";
            txtFinEtape.Text = "";
        }

        protected void listeActiviteItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "retirer")
            {
                string idEtape = e.CommandArgument.ToString();
                Presenter.RetirerEtape(idEtape);
            }

        }

        protected void listeActiviteItemDataBound(object sender, DataListItemEventArgs e)
        {
            Etape etape = (Etape)e.Item.DataItem;
            Repeater dataList = (Repeater)e.Item.FindControl("listeParticipant");

            IList<AffichageParticipantEtape> affichageParticipantEtapes = new List<AffichageParticipantEtape>();
            foreach (Participant participant in etape.Expedition.Participant)
            {

                AffichageParticipantEtape affichageParticipantEtape = new AffichageParticipantEtape
                {
                    IdParticipant = participant.Id,
                    Utilisateur = participant.Utilisateur,
                    Etape = etape,
                    Expedition = etape.Expedition
                };
                if (etape.EtapeParticipant != null)
                {
                    affichageParticipantEtape.EstParticipantEtape =
                        etape.EtapeParticipant.Any(x => x.Participant.Utilisateur.Id == participant.Utilisateur.Id);
                    EtapeParticipant etapeParticipant = etape.EtapeParticipant.FirstOrDefault(x => x.Participant.Utilisateur.Id == participant.Utilisateur.Id);
                    if (etapeParticipant != null)
                    {
                        affichageParticipantEtape.IdEtapeParticipant = etapeParticipant.Id;
                    }
                }

                affichageParticipantEtapes.Add(affichageParticipantEtape);
            }

            dataList.DataSource = affichageParticipantEtapes;
            dataList.DataBind();
        }

        protected void listeParticipantItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int idEtape = Convert.ToInt32(((Label) e.Item.FindControl("lblIdEtape")).Text);
            int idEtapeParticipant = Convert.ToInt32(((Label)e.Item.FindControl("lblIdEtapeParticipant")).Text);
            int idParticipant = Convert.ToInt32(((Label)e.Item.FindControl("lblIdParticipant")).Text);

            if (e.CommandName == "retirer")
            {
                Presenter.RetirerEtapeParticipant(idEtape, idEtapeParticipant);
            }

            if (e.CommandName == "ajouter")
            {
                Presenter.AjouterEtapeParticipant(idParticipant, idEtape);
            }
        }
    }
}