using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface.Francais
{
    public interface IValiderCommandeService
    {
        bool EstClientValide(Customer client);

    }
}
