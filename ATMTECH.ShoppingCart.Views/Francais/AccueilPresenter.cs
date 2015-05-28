using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class AccueilPresenter : BaseShoppingCartPresenter<IAccueilPresenter>
    {
        public IProduitService ProduitService { get; set; }
        public IDAOProduitFichier DAOProduitFichier { get; set; }

        public AccueilPresenter(IAccueilPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherListeProduitEnVente();
            AfficherListeProduitSlideShow();
        }
        public IList<Product> AfficherListeProduitSlideShow()
        {
            IList<Product> listeproduitAfficherDansSlideShow = new List<Product>();
            IList<Product> productsEstSlideShow = ProduitService.ObtenirListeProduitEstSlideShow(Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED)));
            IList<Product> produitAvecRabaisDe35Pourcent = ProduitService.ObtenirListeProduitEnVente(Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED))).Where(x => x.PercentageSave > 35).ToList();
            IList<Product> listeProduits = ProduitService.ObtenirProduit();
            Product produitNewBalance = ObtenirProduitPourUneMarque("Newbalance", listeProduits);
            Product produitNike = ObtenirProduitPourUneMarque("Nike", listeProduits);
            Product produitCalvinKlein = ObtenirProduitPourUneMarque("ck", listeProduits);
            Product produitOakley = ObtenirProduitPourUneMarque("Oakley", listeProduits);
            listeproduitAfficherDansSlideShow = productsEstSlideShow.Concat(produitAvecRabaisDe35Pourcent).ToList();
            listeproduitAfficherDansSlideShow.Add(produitNike);
            listeproduitAfficherDansSlideShow.Add(produitNewBalance);
            listeproduitAfficherDansSlideShow.Add(produitCalvinKlein);
            listeproduitAfficherDansSlideShow.Add(produitOakley);
            View.ListeProduitSlideShow = listeproduitAfficherDansSlideShow;
            return listeproduitAfficherDansSlideShow;
        }
        public void AfficherListeProduitEnVente()
        {
            View.ListeProduitEnVente = ProduitService.ObtenirListeProduitEnVente(Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED)));
        }

        private Product ObtenirProduitPourUneMarque(string marque, IList<Product> produits)
        {
            List<Product> listeProduitsRandom = produits.Where(x => x.Brand == marque).OrderBy(x => Guid.NewGuid()).ToList();
            if (listeProduitsRandom.Count > 0)
            {
                Product produit = listeProduitsRandom.Take(1).ToList()[0];
                produit.ProductFiles = DAOProduitFichier.ObtenirListeFichier(produit.Id);
                return produit;    
            }
            return null;
        }
    }
}