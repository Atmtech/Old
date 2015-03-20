using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface.Francais
{
    public interface IListeCategoriePresenter : IViewBase
    {
        IList<Product> ListeProduitParCategorie { get; set; }
        
    }
}
