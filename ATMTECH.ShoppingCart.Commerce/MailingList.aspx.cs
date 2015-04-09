using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class MailingList : PageBase<PublicationCourrielPresenter, IPublicationCourrielPresenter>, IPublicationCourrielPresenter
    {
        public string CourrielAEnlever { get; set; }
    }
}