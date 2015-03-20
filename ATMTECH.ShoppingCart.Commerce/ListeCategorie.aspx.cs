using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class ListeCategorie : PageBase<ListeCategoriePresenter, IListeCategoriePresenter>,
                                          IListeCategoriePresenter
    {
        protected void btnCategorieClick(object sender, EventArgs e)
        {
            Button bouton = (sender as Button);
            if (bouton != null) Presenter.AfficherProduitPourCategorieChoisi(bouton.Text);
        }

        public IList<Product> ListeProduitParCategorie
        {
            get { return (IList<Product>)Session["ListeProduitParCategorie"]; }
            set
            {
                ListeProduit.ProduitParRangee = 3;
                ListeProduit.Produits = value;
                ListeProduit.Langue = Presenter.CurrentLanguage;
                Session["ListeProduitParCategorie"] = value;
            }
        }
    }
}