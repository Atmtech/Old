using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface.Francais
{
    public interface IEnvoiPostalService
    {
        decimal ObtenirCotationPurolator(Order commande);
        bool EstCodePostalValideAvecPurolator(string codePostal);
    }
}
