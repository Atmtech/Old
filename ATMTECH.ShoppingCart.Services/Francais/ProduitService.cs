using System.Collections.Generic;
using System.Linq;
using ATMTECH.Common.Constant;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Services.Francais
{
    public class ProduitService : BaseService, IProduitService
    {
        public IDAOProduit DAOProduit { get; set; }
        public IDAOCategorieProduit DAOCategorieProduit { get; set; }
        public IDAOProduitFichier DAOProduitFichier { get; set; }

        public ILocalizationService LocalizationService { get; set; }

        public Product ObtenirProduit(int id)
        {
            return DAOProduit.ObtenirProduit(id);
        }
        public IList<Product> ObtenirProduit(string recherche)
        {
            return DAOProduit.ObtenirProduit(recherche);
        }
        public IList<Product> ObtenirProduitParMarque(string marque)
        {
            return DAOProduit.ObtenirProduitParMarque(marque);
        }
        public IList<Product> ObtenirProduit()
        {
            return DAOProduit.ObtenirProduit();
        }
        public IList<Product> ObtenirListeProduitEnVente(int id)
        {
            return DAOProduit.ObtenirListeProduitEnVente(id);
        }
        public IList<Product> ObtenirListeProduitEstSlideShow(int id)
        {
            return DAOProduit.ObtenirListeProduitEstSlideShow(id);
        }
        public IList<ProductCategory> ObtenirListeCategorie(int id)
        {
            return DAOCategorieProduit.GetAllActive().Where(x => x.Language == LocalizationService.CurrentLanguage && x.Enterprise.Id == id).ToList();
        }
        public IList<CategorieProduit> ObtenirListeCategorieListeDeroulante()
        {
            IList<CategorieProduit> retour = new List<CategorieProduit>();
            CategorieProduit choisir = new CategorieProduit { Code = "_", Description = "Choisir une catégorie" };
            if (LocalizationService.CurrentLanguage == LocalizationLanguage.ENGLISH) choisir.Description = "Choose a category";
            retour.Add(choisir);

            foreach (CategorieProduit categorieProduit in ObtenirListeCategorieForce()) retour.Add(categorieProduit);
            
            CategorieProduit categorieProduitLigne = new CategorieProduit { Code = "_", Description = ":::::::::::: Les marques ::::::::::::" };
            if (LocalizationService.CurrentLanguage == LocalizationLanguage.ENGLISH) categorieProduitLigne.Description = ":::::::::::: Brand ::::::::::::";
            retour.Add(categorieProduitLigne);

            foreach (CategorieProduit categorieProduit in ObtenirListeMarque()) retour.Add(categorieProduit);
            
            return retour;
        }
        public IList<ProductCategory> ObtenirListeCategorie()
        {
            return DAOCategorieProduit.GetAllActive();
        }
        public IList<ProductFile> ObtenirFichierProduit(Enterprise enterprise)
        {
            return DAOProduitFichier.ObtenirFichierProduit(enterprise);
        }
        public IList<ProductFile> ObtenirFichierProduit()
        {
            return DAOProduitFichier.GetAllActive();
        }
        public void EnregistrerFichierProduit(ProductFile productFile)
        {
            DAOProduitFichier.Save(productFile);
        }
        public int Enregistrer(Product product)
        {
            return DAOProduit.Save(product);
        }
        public IList<CategorieProduit> ObtenirListeMarque()
        {
            IList<CategorieProduit> listeMarque = new List<CategorieProduit>();

            listeMarque.Add(new CategorieProduit { Code = "Anvil", Description = "Anvil" });
            listeMarque.Add(new CategorieProduit { Code = "AuthenticH", Description = "AuthenticH" });
            listeMarque.Add(new CategorieProduit { Code = "Bella", Description = "Bella" });
            listeMarque.Add(new CategorieProduit { Code = "ck", Description = "Calvin Klein" });
            listeMarque.Add(new CategorieProduit { Code = "Cozy", Description = "Cozy" });
            listeMarque.Add(new CategorieProduit { Code = "Driduck", Description = "Dri duck" });
            listeMarque.Add(new CategorieProduit { Code = "Flexfit", Description = "Flexfit" });
            listeMarque.Add(new CategorieProduit { Code = "Gildan", Description = "Gildan" });
            listeMarque.Add(new CategorieProduit { Code = "Kati", Description = "Kati" });
            listeMarque.Add(new CategorieProduit { Code = "KingFashion", Description = "King Fashions" });
            listeMarque.Add(new CategorieProduit { Code = "MO", Description = "M & O Knits" });
            listeMarque.Add(new CategorieProduit { Code = "Newbalance", Description = "New Balance" });
            listeMarque.Add(new CategorieProduit { Code = "Nike", Description = "Nike" });
            listeMarque.Add(new CategorieProduit { Code = "oakley", Description = "Oakley" });
            listeMarque.Add(new CategorieProduit { Code = "Outdoorcap", Description = "Outdoorcap" });
            listeMarque.Add(new CategorieProduit { Code = "Soleil", Description = "Soleil" });
            listeMarque.Add(new CategorieProduit { Code = "Sportsman", Description = "Sportsman" });
            listeMarque.Add(new CategorieProduit { Code = "SportT", Description = "SportT" });
            listeMarque.Add(new CategorieProduit { Code = "Valuecap", Description = "Valuecap" });
            listeMarque.Add(new CategorieProduit { Code = "VanHeusen", Description = "VanHeusen" });
            listeMarque.Add(new CategorieProduit { Code = "Yupoong", Description = "Yupoong" });
            return listeMarque;
        }
        public IList<CategorieProduit> ObtenirListeCategorieForce()
        {
            IList<CategorieProduit> listeCategorie = new List<CategorieProduit>();
            if (LocalizationService.CurrentLanguage == LocalizationLanguage.FRENCH)
            {
                listeCategorie.Add(new CategorieProduit { Code = "Accessoires", Description = "Accessoires" });
                listeCategorie.Add(new CategorieProduit { Code = "Chapeau", Description = "Chapeau" });
                listeCategorie.Add(new CategorieProduit { Code = "Gilet", Description = "Gilet" });
                listeCategorie.Add(new CategorieProduit { Code = "Manteau", Description = "Manteau" });
                listeCategorie.Add(new CategorieProduit { Code = "Pantalon", Description = "Pantalon" });
                listeCategorie.Add(new CategorieProduit { Code = "Polos", Description = "Polos" });
                listeCategorie.Add(new CategorieProduit { Code = "T-shirt", Description = "T-shirt" });
            }
            else
            {
                listeCategorie.Add(new CategorieProduit { Code = "Accessoires", Description = "Accessoires" });
                listeCategorie.Add(new CategorieProduit { Code = "Chapeau", Description = "Chapeau" });
                listeCategorie.Add(new CategorieProduit { Code = "Gilet", Description = "Gilet" });
                listeCategorie.Add(new CategorieProduit { Code = "Manteau", Description = "Manteau" });
                listeCategorie.Add(new CategorieProduit { Code = "Pantalon", Description = "Pantalon" });
                listeCategorie.Add(new CategorieProduit { Code = "Polos", Description = "Polos" });
                listeCategorie.Add(new CategorieProduit { Code = "T-shirt", Description = "T-shirt" });
            }
            return listeCategorie;
        }
    }

    public class CategorieProduit
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}

