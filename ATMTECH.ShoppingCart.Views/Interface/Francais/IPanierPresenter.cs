using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface.Francais
{
    public interface IPanierPresenter : IViewBase
    {
        Order Commande { get; set; }
        string AdresseLivraison { get; set; }
        string AdresseFacturation { get; set; }
        bool EstCommandable { get; set; }
        bool EstSansAdresseFacturation { get; set; }
        bool EstSansAdresseLivraison { get; set; }
        string Coupon { get; set; }
    }
}