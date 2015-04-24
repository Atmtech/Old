using System.Collections.Generic;
using System.Linq;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class CatalogueProduitPresenter : BaseShoppingCartPresenter<ICatalogueProduitPresenter>
    {
        public CatalogueProduitPresenter(ICatalogueProduitPresenter view)
            : base(view)
        {
        }

        public IProduitService ProduitService { get; set; }
        public IClientService ClientService { get; set; }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherListeProduit();
            AfficherLogoMarque();
        }

        public void AfficherLogoMarque()
        {
            if (!string.IsNullOrEmpty(View.Marque))
            {
                View.ImageMarque = "/Images/WebSite/Logo" + View.Marque + ".jpg";
            }
            else
            {
                View.ImageMarque = "";
            }
        }

        public void AfficherListeProduit()
        {

            if (!string.IsNullOrEmpty(View.Recherche))
            {
                IList<Product> produits = ProduitService.ObtenirProduit(View.Recherche);
                View.NombreElementRetrouve = produits.Count;
                View.Produits = ObtenirListeProduitTrier(produits);
            }
            else if (!string.IsNullOrEmpty(View.Marque))
            {
                IList<Product> produits = ProduitService.ObtenirProduitParMarque(View.Marque);
                View.NombreElementRetrouve = produits.Count;
                View.Produits = ObtenirListeProduitTrier(produits);
            }
            else
            {
                NavigationService.Redirect(Pages.Pages.DEFAULT);
            }
        }

        private IList<Product> ObtenirListeProduitTrier(IList<Product> produits)
        {
            if (!string.IsNullOrEmpty(View.Tri))
            {
                switch (View.Tri)
                {
                    case "HighToLow":
                        return produits.OrderByDescending(x => x.UnitPrice).ToList();
                    case "LowToHigh":
                        return produits.OrderBy(x => x.UnitPrice).ToList();
                }
                return produits;
            }
            else
            {
                return produits;
            }
        }

        public void TrierMoinsChereAuPlusChere()
        {

            NavigationService.Redirect(Pages.Pages.PRODUCT_CATALOG, AjouterQueryStringDeTri(new QueryString(PagesId.ORDER_BY_PRICE, "LowToHigh")));

        }

        public void TrierDuPlusChereAuMoinsChere()
        {
            NavigationService.Redirect(Pages.Pages.PRODUCT_CATALOG, AjouterQueryStringDeTri(new QueryString(PagesId.ORDER_BY_PRICE, "HighToLow")));
        }

        private IList<QueryString> AjouterQueryStringDeTri(QueryString queryString)
        {
            IList<QueryString> queryStrings = QueryString.GetQueryString();
            IList<QueryString> queryStringsRetourner = new List<QueryString>();
            foreach (QueryString s in queryStrings)
            {
                if (s.Name != PagesId.ORDER_BY_PRICE)
                {
                    queryStringsRetourner.Add(s);
                }
            }
            queryStringsRetourner.Add(queryString);
            return queryStringsRetourner;
        }
    }
}
