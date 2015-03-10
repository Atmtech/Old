using System.Collections.Generic;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.ShoppingCart.Services.Francais
{
    public class ProduitService : BaseService, IProduitService
    {
        public IDAOProduit DAOProduit { get; set; }
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
    }
}

