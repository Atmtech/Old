using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface.Francais
{
    public interface IPanierPresenter : IViewBase
    {
        Order Commande { get; set; }
        Order CommandeFinalise { get; set; }
    }
}
