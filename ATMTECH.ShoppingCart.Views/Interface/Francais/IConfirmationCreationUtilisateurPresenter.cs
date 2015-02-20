using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface.Francais
{
    public interface IConfirmationCreationUtilisateurPresenter : IViewBase
    {
        int IdConfirmationUtilisateur { get; }
        bool EstConfirme { set; }
    }
    
}
