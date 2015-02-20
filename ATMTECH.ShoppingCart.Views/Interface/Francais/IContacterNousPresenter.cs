using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface.Francais
{
    public interface IContacterNousPresenter : IViewBase
    {
        string Courriel { get; set; }
        string Telephone { get; set; }
        string Message { get; set; }
    }
}
