using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class MotPasseOubliePresenter : BaseShoppingCartPresenter<IMotPasseOubliePresenter>
    {
        public MotPasseOubliePresenter(IMotPasseOubliePresenter view)
            : base(view)
        {
        }

        public ICustomerService CustomerService { get; set; }

        public void EnvoyerMotPasseOublie()
        {
            CustomerService.SendForgetPassword(View.Courriel);
        }
    }
}