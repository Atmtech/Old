using System;
using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class ProductCatalog : PageBase<CatalogueProduitPresenter, ICatalogueProduitPresenter>,
                                          ICatalogueProduitPresenter
    {
        public IList<Product> Produits
        {
            set
            {
                ListeProduit.Produits = value;
            }
        }

        public string Recherche { get { return QueryString.GetQueryStringValue(PagesId.SEARCH); } }
        public string Marque { get { return QueryString.GetQueryStringValue(PagesId.BRAND); } }
        public string ImageMarque
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    imgLogoMarque.ImageUrl = value;
                    pnlMarque.Visible = true;
                }
                else
                {
                    pnlMarque.Visible = false;
                }
            }
        }
    }
}