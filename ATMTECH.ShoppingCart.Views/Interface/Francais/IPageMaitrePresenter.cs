using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface.Francais
{
    public interface IPageMaitrePresenter : IViewBase
    {
        string NomClient { get; set; }
        string CourrielListeDiffusion { get; set; }
        bool EstConnecte { set; }
        string AffichagePanier { set; }
        string AffichageLangue { set; }
    }
}
