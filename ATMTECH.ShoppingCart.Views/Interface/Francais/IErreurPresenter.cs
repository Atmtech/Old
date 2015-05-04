using ATMTECH.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface.Francais
{
    public interface IErreurPresenter : IViewBase
    {
       Message Message { get; set; }
        void AfficherMessage();
    }
}
