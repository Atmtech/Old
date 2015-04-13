using System;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.Web.Services;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class ExpressCheckoutPaypal : PageBase<ConfirmationPaypalPresenter, IConfirmationPaypalPresenter>, IConfirmationPaypalPresenter
    {
        public PaypalReturn PaypalReturn
        {
            get { return (PaypalReturn)Session["PaypalReturn"]; }
            set { Session["PaypalReturn"] = value; }
        }

        public bool EstFinalise
        {
            set
            {
                if (value)
                {
                    pnlOrderFinalized.Visible = true;
                    pnlAcceptPaypalPayment.Visible = false;
                }
                else
                {
                    pnlOrderFinalized.Visible = false;
                    pnlAcceptPaypalPayment.Visible = true;
                }
                
            }
        }

        public string AffichageCommande
        {
            set { lblAffichageCommande.Text = value; }
        }

        protected void btnAccepterPaiementPaypalClick(object sender, EventArgs e)
        {
            Presenter.FinaliserCommande();
        }

        protected void btnImprimerCommandeClick(object sender, EventArgs e)
        {
            Presenter.ImprimerCommande();
        }
    }
}