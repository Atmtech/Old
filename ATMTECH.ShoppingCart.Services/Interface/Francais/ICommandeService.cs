using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface.Francais
{
    public interface ICommandeService
    {
        Order Enregistrer(Order commande);
        Order ObtenirCommandeSouhaite(Customer customer);
        Order AjouterLigneCommande(int idInventaire, int quantite);
        Order FinaliserCommande(Order commande);
        Order ImprimerCommande(Order commande);
        Order ObtenirCommande(int id);
        IList<Order> ObtenirCommande(Customer customer);
        Order ValiderCoupon(Order commande, string coupon);
    }
}
