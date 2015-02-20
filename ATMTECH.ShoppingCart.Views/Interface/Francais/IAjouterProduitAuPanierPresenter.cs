using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface.Francais
{
    public interface IAjouterProduitAuPanierPresenter : IViewBase
    {
        int IdProduit { get; }
        Product Produit { get; set; }
        int Inventaire { get; set; }
        int Quantite { get; set; }
        bool EstPossibleDeCommander { get; set; }
    }
}
