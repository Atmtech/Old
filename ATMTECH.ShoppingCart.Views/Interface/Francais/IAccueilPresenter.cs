using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface.Francais
{
    public interface IAccueilPresenter : IViewBase
    {
        IList<Product> ListeProduitEnVente { get; set; }
    }
}
