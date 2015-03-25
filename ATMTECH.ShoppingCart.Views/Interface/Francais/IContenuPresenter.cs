using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface.Francais
{
    public interface IContenuPresenter : IViewBase
    {
        string IdContenu { get; }
        string Contenu { get; set; }
    }
}
