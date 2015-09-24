using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface.Francais
{
    public interface IDAOProduitFichier
    {
        IList<ProductFile> ObtenirListeFichier(int id);
        IList<ProductFile> GetAllActive();
        int Save(ProductFile productFile);
        IList<ProductFile> ObtenirFichierProduit(Enterprise enterprise);
    }
}
