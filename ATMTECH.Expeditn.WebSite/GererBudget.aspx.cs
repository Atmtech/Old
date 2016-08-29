using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Entities.DTO;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class GererBudget : PageBase<GererBudgetPresenter, IGererBudgetPresenter>, IGererBudgetPresenter
    {
        public Expedition Expedition
        {
            set { lblNomExpedition.Text = value.Nom; }
        }

        public string IdExpedition { get { return QueryString.GetQueryStringValue(BaseEntity.ID); } }

        public IList<Participant> ListeParticipant
        {
            set
            {
                FillDropDown(ddlParticipant, value);
            }
        }


        public IList<AffichageSommeInvesti> ListeAffichageSommeInvestis
        {
            set
            {
                listeDepenseParPersonne.DataSource = value;
                listeDepenseParPersonne.DataBind();

                lblGrandTotal.Text = value.Sum(x => x.MontantTotal).ToString("C");
                lblTotalAutomobile.Text = value.Sum(x => x.MontantEtapeAutomobile).ToString("C");
                lblTotalBateau.Text = value.Sum(x => x.MontantEtapeBateau).ToString("C");
                lblTotalNourriture.Text = value.Sum(x => x.MontantNourriture).ToString("C");
                lblTotalAutres.Text = value.Sum(x => x.MontantAutre).ToString("C");
            }
        }

        public IList<AffichageRepartitionMontant> ListeRepartitionMontants 
        {
            set
            {

                lblTotalPourcentageAutomobile.Text = (value.Sum(x => x.NombrePresenceEtapeAutomobile) / value.Sum(x => x.NombreTotalEtapeAutomobile)).ToString("P");
                lblTotalPourcentageBateau.Text = (value.Sum(x => x.NombrePresenceEtapeBateau) / value.Sum(x => x.NombreTotalEtapeBateau)).ToString("P");
                lblTotalPourcentageNourriture.Text = (value.Sum(x => x.NombreRepas) / value.Sum(x => x.NombreTotalRepas)).ToString("P");
                lblTotalAutomobileRepartition.Text = value.Sum(x => x.MontantAvecPourcentageDuTotalAutomobile).ToString("C");
                lblTotalBateauRepartition.Text = value.Sum(x => x.MontantAvecPourcentageDuTotalBateau).ToString("C");
                lblTotalNourritureRepartition.Text = value.Sum(x => x.MontantAvecPourcentageDesRepas).ToString("C");
                lblTotalAutresRepartition.Text = value.Sum(x => x.MontantAvecPourcentageAutres).ToString("C");
                lblGrandTotalRepartition.Text = value.Sum(x => x.MontantTotal).ToString("C");

                listeRepartitionMontant.DataSource = value;
                listeRepartitionMontant.DataBind();
            } 
        }

        public IList<AffichageMontantDu> ListeMontantDu
        {
            set
            {
                listeMontantDu.DataSource = value;
                listeMontantDu.DataBind();
            }
        }

        protected void lnkRepartitionDepenseNourritureClick(object sender, EventArgs e)
        {
            Presenter.RepartirNourriture(ddlParticipant.SelectedValue, txtMontant.ValeurDecimal);
        }

        protected void lnkRepartitionDepenseAutomobileClick(object sender, EventArgs e)
        {
            Presenter.RepartirAutomobile(ddlParticipant.SelectedValue, txtMontant.ValeurDecimal);
        }

        protected void lnkRepartitionDepenseBateauClick(object sender, EventArgs e)
        {
            Presenter.RepartirBateau(ddlParticipant.SelectedValue, txtMontant.ValeurDecimal);

        }

        protected void lnkRepartitionDepenseAutreClick(object sender, EventArgs e)
        {
            Presenter.RepartirAutre(ddlParticipant.SelectedValue, txtMontant.ValeurDecimal);

        }
    }
}