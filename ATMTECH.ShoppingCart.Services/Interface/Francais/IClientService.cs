using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface.Francais
{
    public interface IClientService
    {
        Customer ClientAuthentifie { get; }
        Customer Creer(Customer client);
        Customer Enregistrer(Customer client);
    }
}
