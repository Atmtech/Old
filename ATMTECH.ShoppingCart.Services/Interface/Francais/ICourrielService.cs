using System.IO;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface.Francais
{
    public interface ICourrielService
    {
        void EnvoyerConfirmationCreationClient(Customer client);
        void EnvoyerConfirmationCommandeEstEnLivraison(Order commande, Stream facture);
        void EnvoyerCommandeFinaliser(Order commande, Stream facture);
        void EnvoyerMotPasseOublie(Customer client);
        void EnvoyerCommandeACourriel(Order commande, Stream pdf, string adresseCourriel);

        bool EnvoyerCourriel(string to, string from, string subject, string body);

    }
}
