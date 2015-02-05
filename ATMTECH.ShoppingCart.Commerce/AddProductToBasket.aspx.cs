using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class AddProductToBasket : PageBaseShoppingCart<AddProductToBasketPresenter, IAddProductToBasketPresenter>, IAddProductToBasketPresenter
    {
        public string IdProduct { get; set; }
        public Product Product { get; set; }
        public bool IsOrderable { set; private get; }
        public int IsSuccesfullyAdded { set; private get; }
        public bool IsOrderableAgainstSecurity { get; set; }
        public bool IsOrderLocked { set; private get; }
    }
}