using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.WebControls;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Basket : PageBase<PanierPresenter, IPanierPresenter>, IPanierPresenter
    {
        public Order Commande
        {
            get { return (Order)Session["CommandeActuel"]; }
            set
            {
                Session["CommandeActuel"] = value;

                AffichagePanier();

                lblCoutLivraison.Text = value.ShippingTotal.ToString("c");
                lblSousTotal.Text = value.SubTotal.ToString("c");
                lblTaxeFederale.Text = value.CountryTax.ToString("c");
                lblTaxeProvinciale.Text = value.RegionalTax.ToString("c");
                lblGrandTotal.Text = value.GrandTotal.ToString("c");

                AffichageValeurCoupon(value);
            }
        }

        public string AdresseLivraison { get { return lblAdresseLivraison.Text; } set { lblAdresseLivraison.Text = value; } }
        public string AdresseFacturation { get { return lblAdresseFacturation.Text; } set { lblAdresseFacturation.Text = value; } }
        public bool EstCommandable { get { return btnFinaliserCommande.Enabled; } set { btnFinaliserCommande.Enabled = value; } }
        public bool EstSansAdresseFacturation
        {
            get { return lblSansAdresseFacturation.Visible; }
            set
            {
                lblSansAdresseFacturation.Visible = value;
                lblAdresseFacturation.Visible = !value;
            }
        }
        public bool EstSansAdresseLivraison
        {
            get { return lblSansAdresseLivraison.Visible; }
            set
            {
                lblSansAdresseLivraison.Visible = value;
                lblAdresseLivraison.Visible = !value;
            }
        }
        public string Coupon { get { return txtCoupon.Text; } set { txtCoupon.Text = value; } }
        public void RecalculerPanier()
        {
            int i = 0;
            var listeQuantite = new Dictionary<int, int>();
            foreach (Numeric textBox in from DataListItem row in dataListeCommande.Items select (Numeric)row.FindControl("txtQuantite"))
            {
                listeQuantite.Add(i, Convert.ToInt32(textBox.Text));
                i++;
            }
            Presenter.RecalculerPanier(listeQuantite);
        }

        protected void btnFinaliserCommandeClick(object sender, EventArgs e)
        {
            Presenter.FinaliserCommande();
        }
        protected void btnModifierAdresseClick(object sender, EventArgs e)
        {
            Presenter.ModifierAdresse();
        }
        protected void dataListeCommande_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "SupprimerLigneCommande")
            {
                Presenter.SupprimerLigneCommande(Convert.ToInt32(e.CommandArgument));
                RecalculerPanier();
            }
            if (e.CommandName == "RecalculerCommande")
            {
                RecalculerPanier();
            }
        }
        protected void btnValiderCouponClick(object sender, EventArgs e)
        {
            Presenter.ValiderCoupon();
            AffichagePanier();
        }

        private void AffichagePanier()
        {
            dataListeCommande.DataSource = ((Order)Session["CommandeActuel"]).OrderLines;
            dataListeCommande.DataBind();
        }
        private void AffichageValeurCoupon(Order commande)
        {
            if (commande.Coupon != null && commande.Coupon.PercentageSave != 0)
            {
                lblGrandTotalApresCoupon.Text = commande.GrandTotalWithCoupon.ToString("c");
                lblGrandTotalApresCoupon.Visible = true;
                lblGrandTotal.Font.Strikeout = true;
            }
            else
            {
                lblGrandTotalApresCoupon.Visible = false;
                lblGrandTotal.Font.Strikeout = false;
            }
        }
    }
}