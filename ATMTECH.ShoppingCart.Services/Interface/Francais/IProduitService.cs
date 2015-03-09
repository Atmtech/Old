using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface.Francais
{
    public interface IProduitService
    {
        Product ObtenirProduit(int id);
        IList<Product> ObtenirListeProduitEnVente(int id);
    }
}
