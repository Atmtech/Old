using System;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.Web.Services;

namespace ATMTECH.ShoppingCart.WebSite
{
    public partial class ExpressCheckoutPaypal : PageBaseShoppingCart<ExpressCheckoutPaypalPresenter, IExpressCheckoutPaypalPresenter>, IExpressCheckoutPaypalPresenter
    {

        public PaypalReturn PaypalReturn
        {
            get { return (PaypalReturn)Session["PaypalReturn"]; }
            set { Session["PaypalReturn"] = value; }
        }

        public string OrderReportPath
        {
            get { return Server.MapPath("~/Reports/Order.rdlc"); }
        }


        public bool IsOrderFinalized
        {
            set
            {
                if (value)
                {
                    pnlAcceptPaypalPayment.Visible = false;
                    pnlOrderFinalized.Visible = true;
                }
            }
        }

        protected void AcceptPaypalPayment(object sender, EventArgs e)
        {
            Presenter.FinalizeOrder();
        }

        protected void PrintOrderClick(object sender, EventArgs e)
        {
            Presenter.PrintOrder();
        }
    }
}