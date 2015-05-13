using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface.Francais
{
    public interface IAjouterProduitAuPanierPresenter : IViewBase
    {
        int IdProduit { get; }
        Product Produit { get; set; }
        int Inventaire { get; set; }
        int Quantite { get; set; }
        string Couleur { get; set; }
        string Taille { get; set; }
        IList<string> ListeDeroulanteCouleurs { set; }
        IList<Couleur> ListeCouleurs { set; }
        IList<Taille> Tailles { set; }
        bool EstPossibleDeCommander { get; set; }
        decimal PrixUnitaireOriginal { set; }
        decimal PrixUnitaireEnSolde { set; }
    }
}
