using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface.Francais
{
    public interface ICatalogueProduitPresenter : IViewBase
    {
        IList<Product> Produits { set; }
        string Recherche { get; }
        string Marque { get; }
        string Tri { get; }
        string ImageMarque { set; }
        int NombreElementRetrouve { get; set; }
    }
}
