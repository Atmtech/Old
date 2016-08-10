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
    public partial class GererNourriture : PageBase<GererNourriturePresenter, IGererNourriturePresenter>, IGererNourriturePresenter
    {
        public Expedition Expedition
        {
            set { lblNomExpedition.Text = value.Nom; }
        }
        public string IdExpedition
        {
            get { return QueryString.GetQueryStringValue(BaseEntity.ID); }
        }

        public string IdParticipantCuisinier { get { return ddlParticipant.SelectedValue; } }

        public string Nom { get { return txtNomMenu.Text; } set { txtNomMenu.Text = value; } }
        public string Menu { get { return txtMenu.Text; } set { txtMenu.Text = value; } }
        public DateTime Date { get { return Convert.ToDateTime(txtDateMenu.Text); } set { txtDateMenu.Text = value.ToString(); } }
        public IList<Participant> ListeParticipant { set { FillDropDown(ddlParticipant, value); } }

        public IList<Nourriture> ListeNourriture
        {
            set
            {
                listeNourriture.DataSource = value;
                listeNourriture.DataBind();
            }
        }

        protected void lnkAjouterMenuClick(object sender, EventArgs e)
        {
            Presenter.AjouterMenu();
        }

        protected void listeNourritureItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "retirer")
            {
                string idNourriture = e.CommandArgument.ToString();
                Presenter.RetirerNourriture(idNourriture);
            }
        }

        protected void listeNourritureItemDataBound(object sender, DataListItemEventArgs e)
        {
            Nourriture nourriture = (Nourriture)e.Item.DataItem;
            Repeater dataList = (Repeater)e.Item.FindControl("listeParticipant");

            IList<AffichageParticipantNourriture> affichageParticipantNourritures = new List<AffichageParticipantNourriture>();

            foreach (Participant participant in nourriture.Expedition.Participant)
            {
                AffichageParticipantNourriture affichageParticipantNourriture = new AffichageParticipantNourriture
                {
                    IdParticipant = participant.Id,
                    Utilisateur = participant.Utilisateur,
                    Expedition = participant.Expedition,
                    Nourriture = nourriture
                };

                if (nourriture.NourritureParticipant != null)
                {
                    affichageParticipantNourriture.EstParticipantNourriture =
                      nourriture.NourritureParticipant.Any(x => x.Participant.Utilisateur.Id == participant.Utilisateur.Id);
                    NourritureParticipant nourritureParticipant = nourriture.NourritureParticipant.FirstOrDefault(x => x.Participant.Utilisateur.Id == participant.Utilisateur.Id);
                    if (nourritureParticipant != null)
                    {
                        affichageParticipantNourriture.IdNourritureParticipant = nourritureParticipant.Id;
                    }
                }

                affichageParticipantNourritures.Add(affichageParticipantNourriture);

            }

            dataList.DataSource = affichageParticipantNourritures;
            dataList.DataBind();
        }

        protected void listeParticipantItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int idNourriture = Convert.ToInt32(((Label)e.Item.FindControl("lblIdNourriture")).Text);
            int idNourritureParticipant = Convert.ToInt32(((Label)e.Item.FindControl("lblIdNourritureParticipant")).Text);
            int idParticipant = Convert.ToInt32(((Label)e.Item.FindControl("lblIdParticipant")).Text);


            if (e.CommandName == "retirer")
            {
                Presenter.RetirerNourritureParticipant(idNourriture, idNourritureParticipant);
            }

            if (e.CommandName == "ajouter")
            {
                Presenter.AjouterNourritureParticipant(idParticipant, idNourriture, "0");
            }
        }
    }
}