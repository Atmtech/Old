using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface.Francais
{
    public interface IMerciCommandePresenter : IViewBase
    {
        int IdCommande { get;  }
        Order Commande { set; }
    }
}
