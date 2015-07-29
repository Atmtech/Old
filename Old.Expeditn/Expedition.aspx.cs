using System;
using System.Linq;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class ExpeditionPage : PageBase<ExpeditionPresenter, IExpeditionPresenter>, IExpeditionPresenter
    {
        public bool EstAdministrateur
        {
            set
            {
                txtTitreExpedition.Enabled = value;
                txtDateDebut.Enabled = value;
                txtDateFin.Enabled = value;
                txtPays.Enabled = value;
                txtRegion.Enabled = value;
                txtdescriptionExpedition.Enabled = value;
              //  ddlUtilisateur.Enabled = value;
                btnAjouterUtilisateurAExpedition.Enabled = false;
            }
        }

        public int IdExpedition
        {
            get { return Convert.ToInt32(QueryString.GetQueryStringValue(PagesId.EXPEDITION)); }
        }
        public Expedition Expedition
        {
            set
            {

                txtTitreExpedition.Text = value.Nom;
                txtDateDebut.Text = value.DateDebut.ToString();
                txtDateFin.Text = value.DateFin.ToString();
                txtPays.Text = value.Pays;
                txtRegion.Text = value.Region;
                txtdescriptionExpedition.Text = value.Description;
                lblBudget.Text = string.Format("{0:C}", value.Budget);

                dataListeParticipant.DataSource = value.Participant.OrderByDescending(x => x.EstAdministrateurExpedition);
                dataListeParticipant.DataBind();

                dataListEtape.DataSource = value.Etape;
                dataListEtape.DataBind();
            }
        }

        private void MasquerTout()
        {
            pnlEtape.Visible = false;
            pnlInformationGenerales.Visible = false;
            pnlParticipant.Visible = false;
        }

        protected void btnInformationGeneraleClick(object sender, EventArgs e)
        {
            MasquerTout();
            pnlInformationGenerales.Visible = true;
        }

        protected void btnEtapeClick(object sender, EventArgs e)
        {
            MasquerTout();
            pnlEtape.Visible = true;
        }

        protected void btnParticipantClick(object sender, EventArgs e)
        {
            MasquerTout();
            pnlParticipant.Visible = true;
        }

        protected void btnAfficherListeMaterielExpeditionClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        protected void btnImprimerExpeditionClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}