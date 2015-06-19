using System;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;
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

        public Order Commande
        {
            set
            {
                string html =
                  "<div class='Row'><div class='Cell'><p>{0}</p></div><div class='Cell'><p>{1}</p></div></div>";

                foreach (OrderLine ligneCommandeLine in value.OrderLines)
                {
                    html = string.Format(html,ligneCommandeLine.ProductDescription, ligneCommandeLine.Quantity);
                    Literal literal = new Literal { Text = html };
                    placeHolderListeCommandePasse.Controls.Add(literal);
                }

                lblCoutLivraison.Text = value.ShippingTotal.ToString("c");
                lblSousTotal.Text = value.SubTotal.ToString("c");
                lblTaxeFederale.Text = value.CountryTax.ToString("c");
                lblTaxeProvinciale.Text = value.RegionalTax.ToString("c");
                lblGrandTotal.Text = value.GrandTotal.ToString("c");

            }
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