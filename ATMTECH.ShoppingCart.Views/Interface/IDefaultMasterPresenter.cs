using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface
{
    public interface IDefaultMasterPresenter : IViewBase
    {
        bool IsLogged { set; }
        string Name { set; }
        int NumberOfItemInBasket { set; }
        string ImageCorp { set; }
        int ProductCount { set; }
        string Welcome { set; }
        decimal TotalPrice { set; }
        string Language { set; }
        Enterprise Enterprise { set; }
    }
}
