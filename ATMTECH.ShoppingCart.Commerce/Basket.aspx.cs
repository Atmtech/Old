using System;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Basket : PageBaseShoppingCart<PanierPresenter, IPanierPresenter>, IPanierPresenter
    {
        public Order Commande
        {
            get
            {
                return (Order)Session["CommandeActuel"];
            }
            set
            {
                Session["CommandeActuel"] = value;
            }
        }
        public Order CommandeFinalise
        {
            get
            {
                return (Order)Session["CommandeFinalise"];
            }
            set
            {
                Session["CommandeFinalise"] = value;
            }
        }

        public void RecalculerPanier()
        {



            Presenter.RecalculerPanier();
        }

        protected void btnRecalculerClick(object sender, EventArgs e)
        {
            RecalculerPanier();
        }

        protected void btnFinaliserCommandeClick(object sender, EventArgs e)
        {
            Presenter.FinaliserCommande();
        }

        protected void btnModifierAdresseClick(object sender, EventArgs e)
        {
            Presenter.ModifierAdresse();
        }
    }
}