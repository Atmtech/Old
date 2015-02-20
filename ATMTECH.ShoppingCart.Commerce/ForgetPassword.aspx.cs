using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class ForgetPassword : PageBaseShoppingCart<MotPasseOubliePresenter, IMotPasseOubliePresenter>, IMotPasseOubliePresenter
    {
        public string Courriel { get; set; }
    }
}