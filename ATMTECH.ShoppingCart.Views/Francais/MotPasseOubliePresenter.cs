using ATMTECH.ShoppingCart.Services.Interface.Francais;
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

        public IClientService ClientService { get; set; }

        public void EnvoyerMotPasseOublie()
        {
            ClientService.EnvoyerMotPasseOublie(View.Courriel);
        }
    }
}