using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface.Francais
{
    public interface ICommandeService
    {
        Order Enregistrer(Order commande);
        Order ObtenirCommandeSouhaite(Customer customer);
        Order AjouterLigneCommande(int idInventaire, int quantite);
    }
}
