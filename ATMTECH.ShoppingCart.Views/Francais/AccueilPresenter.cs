using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class AccueilPresenter : BaseShoppingCartPresenter<IAccueilPresenter>
    {
        public AccueilPresenter(IAccueilPresenter view)
            : base(view)
        {
        }


        public IProduitService ProduitService { get; set; }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherListeProduitEnVente();
            AfficherListeProduitSlideShow();
        }
        public IList<Product> AfficherListeProduitSlideShow()
        {
            IList<Product> productsSlideShow = ProduitService.ObtenirListeProduitSlideShow(Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED)));
            IList<Product> produitAvecRabaisDe35Pourcent = ProduitService.ObtenirListeProduitEnVente(Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED))).Where(x => x.PercentageSave > 35).ToList();

            IList<Product> produits = new List<Product>();
            if (productsSlideShow.Count > 0)
            {
                foreach (Product product in productsSlideShow.Where(product => !produits.Contains(product)))
                {
                    produits.Add(product);
                }
            }

            if (produitAvecRabaisDe35Pourcent.Count > 0)
            {
                foreach (Product product in produitAvecRabaisDe35Pourcent.Where(product => !produits.Contains(product)))
                {
                    produits.Add(product);
                }
            }

            View.ListeProduitSlideShow = produits;
            return produits;
        }
        public void AfficherListeProduitEnVente()
        {
            View.ListeProduitEnVente = ProduitService.ObtenirListeProduitEnVente(Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED)));
        }

    }
}