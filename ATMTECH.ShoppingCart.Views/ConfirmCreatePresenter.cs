using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Views
{
    public class ConfirmCreatePresenter : BaseShoppingCartPresenter<IConfirmCreatePresenter>
    {
        public ICustomerService CustomerService { get; set; }
        public ConfirmCreatePresenter(IConfirmCreatePresenter view)
            : base(view)
        {
        }

        public void ConfirmCreate()
        {
            View.IsConfirmed = CustomerService.ConfirmCreate(View.IdConfirm);

        }
    }
}
