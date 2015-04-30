using System;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class ThankYouForYourOrder : PageBase<MerciCommandePresenter, IMerciCommandePresenter>, IMerciCommandePresenter
    {
        public int IdCommande { get { return Convert.ToInt32(QueryString.GetQueryStringValue(PagesId.ORDER_ID)); } }
        public Order Commande
        {
            set
            {
                lblNumeroCommande.Text = value.Id.ToString();
                lblSousTotal.Text = value.SubTotal.ToString("c");
                lblTaxeProvinciale.Text = value.RegionalTax.ToString("c");
                lblTaxeFederale.Text = value.CountryTax.ToString("c");
                lblCoutLivraison.Text = value.ShippingTotal.ToString("c");
                lblGrandTotal.Text = value.GrandTotal.ToString("c");
            }
        }

        protected void btnImprimerCommandeClick(object sender, EventArgs e)
        {
            Presenter.ImprimerCommande();
        }
    }
}