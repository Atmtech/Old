using ATMTECH.Views.Interface;
using ATMTECH.Web.Services;

namespace ATMTECH.ShoppingCart.Views.Interface.Francais
{
    public interface IConfirmationPaypalPresenter : IViewBase
    {
        PaypalReturn PaypalReturn { get; set; }
        bool EstFinalise { set; }
        string AffichageCommande { set; }
    }
}
