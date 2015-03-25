using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface.Francais
{
    public interface IValiderClientService
    {
        bool EstClientValide(Customer client);
        bool EstClientExistant(Customer client);
        bool EstCourrielValide(Customer client);
    }
}
