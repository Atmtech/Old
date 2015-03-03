using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Contact : PageBase<ContacterNousPresenter, IContacterNousPresenter>, IContacterNousPresenter
    {
        public string Courriel { get; set; }
        public string Telephone { get; set; }
        public string Message { get; set; }
    }
}