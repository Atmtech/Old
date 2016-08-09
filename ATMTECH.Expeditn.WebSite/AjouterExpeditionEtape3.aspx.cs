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
    public partial class AjouterExpeditionEtape3 : PageBase<AjouterExpeditionEtape3Presenter, IAjouterExpeditionEtape3Presenter>, IAjouterExpeditionEtape3Presenter
    {
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
            throw new NotImplementedException();
        }

        protected void lnkAjouterActiviteExpeditionClick(object sender, EventArgs e)
        {
            Presenter.AjouterActivite();
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

            if (e.CommandName == "ajouterparticipant")
            {

                // pnlAjouterParticipant.Visible = true;
                //string idEtape = e.CommandArgument.ToString();
                //Presenter.RetirerEtape(idEtape);
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
                    Nom = participant.Utilisateur.FirstNameLastName,
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

        protected void listeParticipantItemCommand(object source, RepeaterCommandEventArgs repeaterCommandEventArgs)
        {
        

            AffichageParticipantEtape affichageParticipantEtape = (AffichageParticipantEtape)repeaterCommandEventArgs.Item.DataItem;
            //TextBox txtMontant = (TextBox)dataListCommandEventArgs.Item.FindControl("txtMontant");

            //DataGridItem dgi = (DataGridItem)(((Control)sender).NamingContainer);
            //string TextValue = ((TextBox)dgi.Cells[0].Controls[1]).Text;


            //if (e.CommandName == "retirer")
            //{
            //    Presenter.RetirerEtapeParticipant(e.CommandArgument.ToString());
            //}

            //if (e.CommandName == "ajouter")
            //{
            //    Presenter.AjouterEtapeParticipant(affichageParticipantEtape.IdParticipant, affichageParticipantEtape.IdEtapeParticipant, txtMontant.Text.Replace(",", "."));
            //}
        }


        protected void txtMontantChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}