using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface.Francais
{
    public interface IValiderCommandeService
    {
        bool EstClientValide(Customer client);
        bool EstItemPresentEnInventaire(string idProduit, string grandeur, string couleur);
        bool EstQuantiteValide(int quantite);
    }
}
