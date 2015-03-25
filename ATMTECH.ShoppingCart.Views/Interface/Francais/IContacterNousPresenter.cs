using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface.Francais
{
    public interface IContacterNousPresenter : IViewBase
    {
        string Nom { get; set; }
        string Courriel { get; set; }
        string Telephone { get; set; }
        string Message { get; set; }
    }
}
