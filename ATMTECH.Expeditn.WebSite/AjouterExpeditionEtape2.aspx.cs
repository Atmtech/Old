using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class AjouterExpeditionEtape2 : PageBase<AjouterExpeditionEtape2Presenter, IAjouterExpeditionEtape2Presenter>, IAjouterExpeditionEtape2Presenter
    {
        public string IdExpedition
        {
            get { return QueryString.GetQueryStringValue(BaseEntity.ID); }
        }

        public string Recherche
        {
            get { return txtRechercheUtilisateur.Text; }
            set
            {
                txtRechercheUtilisateur.Text = value;
            }
        }

        public IList<User> ListeUtilisateurPourAjouter
        {
            set
            {
                listeUtilisateur.DataSource = value;
                listeUtilisateur.DataBind();
            }
        }

        public IList<Participant> ListeParticipant
        {
            set
            {
                listeParticipant.DataSource = value;
                listeParticipant.DataBind();
            }
        }

        protected void lnkPasserEtape3CreationExpeditionClick(object sender, EventArgs e)
        {
            Presenter.RedirigerEtape3();
        }

        protected void lnkTerminerCreationExpedition(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        protected void lnkRechercherUtilisateurClick(object sender, EventArgs e)
        {
            lblAucuneRechercheUtilisateurEffectue.Visible = Presenter.RechercherUtilisateur() <= 0;
        }

        protected void listeUtilisateurItemCommand(object source, DataListCommandEventArgs dataListCommandEventArgs)
        {
            if (dataListCommandEventArgs.CommandName == "ajouter")
            {
                string idUser = dataListCommandEventArgs.CommandArgument.ToString();
                Presenter.AjouterParticipant(idUser);
            }

            if (dataListCommandEventArgs.CommandName == "retirer")
            {
                string idUser = dataListCommandEventArgs.CommandArgument.ToString();
                Presenter.RetirerParticipant(idUser);
            }

        }
    }
}