using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface.Francais
{
    public interface ICourrielService
    {
        void EnvoyerConfirmationCreationClient(Customer client);
        void EnvoyerConfirmationCommande(Order commande);
        void EnvoyerInformationCommande(Order commande);
        void EnvoyerMotPasseOublie(Customer client);
    }
}
