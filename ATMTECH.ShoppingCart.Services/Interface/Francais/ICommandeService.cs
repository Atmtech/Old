using System.Collections.Generic;
using System.IO;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface.Francais
{
    public interface ICommandeService
    {
        Order Enregistrer(Order commande);
        Order ObtenirCommandeSouhaite(Customer customer);
        Order AjouterLigneCommande(int idInventaire, int quantite);
        Order FinaliserCommande(Order commande);
        void FinaliserCommandeAvecPaypal(Order commande);
        Order ImprimerCommande(Order commande);
        Order ObtenirCommande(int id);
        IList<Order> ObtenirCommande(Customer customer);
        Order ValiderCoupon(Order commande, string coupon);
        bool ConfirmerCommande(int id);
        IList<Order> ObtenirCommande();
        IList<OrderLine> ObtenirLigneCommande();
        void SupprimerLigneCommande(OrderLine ligneCommande);
        Stream ObtenirFacturePourPdf(Order commande);
        Order EffacerCoupon(Order commande);
    }
}
