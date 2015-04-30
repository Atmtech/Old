using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Content : PageBase<ContenuPresenter, IContenuPresenter>, IContenuPresenter
    {
        public string IdContenu { get { return QueryString.GetQueryStringValue(PagesId.CONTENT_ID); } }
        public string Contenu { get { return lblContenu.Text; } set { lblContenu.Text = value; } }
    }
}