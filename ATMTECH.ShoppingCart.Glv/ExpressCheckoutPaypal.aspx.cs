using System;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.Web.Services;

namespace ATMTECH.ShoppingCart.Glv
{
    public partial class ExpressCheckoutPaypal : PageBaseShoppingCart<ExpressCheckoutPaypalPresenter, IExpressCheckoutPaypalPresenter>, IExpressCheckoutPaypalPresenter
    {

        public PaypalReturn PaypalReturn
        {
            get { return (PaypalReturn)Session["PaypalReturn"]; }
            set
            {
                Session["PaypalReturn"] = value;

            }
        }

        public bool IsOrderFinalized
        {
            set
            {
                if (value)
                {
                    pnlAcceptPaypalPayment.Visible = false;
                    pnlOrderFinalized.Visible = true;
                    ((Default)Master).RefreshTotal();
                }
            }
        }

        public string OrderDisplay
        {
            set { lblDisplayOrder.Text = value; }
        }

        protected void AcceptPaypalPayment(object sender, EventArgs e)
        {
            btnAcceptPaypalPayment.Enabled = false;
            Presenter.FinalizeOrder();
        }

        protected void PrintOrderClick(object sender, EventArgs e)
        {
            Presenter.PrintOrder();
        }
    }
}