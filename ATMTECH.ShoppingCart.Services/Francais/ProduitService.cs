using System.Collections.Generic;
using System.Linq;
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
        public ILocalizationService LocalizationService { get; set; }

        public Product ObtenirProduit(int id)
        {
            return DAOProduit.ObtenirProduit(id);
        }

        public IList<Product> ObtenirProduit(string recherche)
        {
            return DAOProduit.ObtenirProduit(recherche);
        }

        public IList<Product> ObtenirProduit()
        {
            return DAOProduit.ObtenirProduit();
        }

        public IList<Product> ObtenirListeProduitEnVente(int id)
        {
            return DAOProduit.ObtenirListeProduitEnVente(id);
        }

        public IList<ProductCategory> ObtenirListeCategorie(int id)
        {
            return DAOCategorieProduit.GetAllActive().Where(x => x.Language == LocalizationService.CurrentLanguage && x.Enterprise.Id == id).ToList();
        }
    }
}

