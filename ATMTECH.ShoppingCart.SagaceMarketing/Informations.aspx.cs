using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.SagaceMarketing
{
    public partial class Informations : PageBaseShoppingCart<InformationsPresenter, IInformationsPresenter>, IInformationsPresenter
    {
        public string InformationDisplay
        {
            set { lblInformation.Text = value; }
        }
    }
}