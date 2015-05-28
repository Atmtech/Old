using System.Collections.Generic;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Services;

namespace ATMTECH.ShoppingCart.Views.Interface.Francais
{
    public interface IPageMaitrePresenter : IViewBase
    {
        string NomClient { get; set; }
        string CourrielListeDiffusion { get; set; }
        bool EstConnecte { set; }
        string AffichagePanier { set; }
        string AffichageLangue { set; }
        IList<FilArianne> FilArianne { set; }
    }
}
