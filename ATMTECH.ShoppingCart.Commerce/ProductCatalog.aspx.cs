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
                dataListProduitTrouve.DataSource = value;
                dataListProduitTrouve.DataBind();
            }
        }
        public string Recherche
        {
            get { return QueryString.GetQueryStringValue(PagesId.SEARCH); }
        }
    }
}