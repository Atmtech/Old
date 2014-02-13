using System;
using System.Web.UI.WebControls;
using ATMTECH.FishingAtWork.Services.Base;
using ATMTECH.FishingAtWork.Views;
using ATMTECH.FishingAtWork.Views.Interface;
using ATMTECH.FishingAtWork.WebSite.Base;
using ATMTECH.Web.Controls.Edition;

namespace ATMTECH.FishingAtWork.WebSite
{
    public partial class Shopping : PageBaseFishingAtWork, IShoppingPresenter
    {
        public ShoppingPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        protected void LureRowCommandClick(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "AddToCart")
            {
                GridViewRow gvRow = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                AlphaNumTextBoxAvance txtQuantity = (AlphaNumTextBoxAvance)gvRow.FindControl("txtQuantity");

                int quantity = 0;
                quantity = String.IsNullOrEmpty(txtQuantity.Text) ? 0 : Convert.ToInt32(txtQuantity.Text);
                Presenter.AddToBasket(Constant.BASKET_TYPE_LURE, Convert.ToInt32(e.CommandArgument), quantity);
            }

        }
    }
}