using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface.Francais
{
    public interface IInventaireService
    {
        IList<Stock> ObtenirInventaire();
        int ObtenirInventaireTechnosport(string idProduit, string grandeur, string couleur);
        int Enregistrer(Stock stock);
    }
}
