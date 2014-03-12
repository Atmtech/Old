using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface
{
    public interface IAddProductToBasketPresenter : IViewBase
    {
        string IdProduct { get; set; }
        Product Product { get; set; }
        bool IsOrderable { set; }
        int IsSuccesfullyAdded { set; }
        bool IsOrderableAgainstSecurity { get; set; }
        bool IsOrderLocked { set; }
    }
}
