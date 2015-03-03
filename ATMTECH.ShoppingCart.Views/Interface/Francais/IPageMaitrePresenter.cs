using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface.Francais
{
    public interface IPageMaitrePresenter : IViewBase
    {
        string NomClient { get; set; }
        bool EstConnecte { set; }
        decimal GrandTotalPanier { set; }
        decimal NombreTotalItemPanier { set; }
    }
}
