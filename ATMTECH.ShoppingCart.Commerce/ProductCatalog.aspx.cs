using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class ProductCatalog : PageBaseShoppingCart<CatalogueProduitPresenter, ICatalogueProduitPresenter>, ICatalogueProduitPresenter
    {
        public IList<Product> Produits { set; private get; }
        public string Recherche { get; set; }
    }
}