using System;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.Web.Services;

namespace ATMTECH.ShoppingCart.PubJL
{
    public partial class ExpressCheckoutPaypal : PageBaseShoppingCart<ConfirmationPaypalPresenter, IConfirmationPaypalPresenter>, IConfirmationPaypalPresenter
    {

        //public PaypalReturn PaypalReturn
        //{
        //    get { return (PaypalReturn)Session["PaypalReturn"]; }
        //    set
        //    {
        //        Session["PaypalReturn"] = value;

        //    }
        //}

        //public bool IsOrderFinalized
        //{
        //    set
        //    {
        //        if (value)
        //        {
        //            pnlAcceptPaypalPayment.Visible = false;
        //            pnlOrderFinalized.Visible = true;
        //            ((Default)Master).RefreshTotal();
        //        }
        //    }
        //}

        //public string OrderDisplay
        //{
        //    set { lblDisplayOrder.Text = value; }
        //}

        protected void AcceptPaypalPayment(object sender, EventArgs e)
        {
            //btnAcceptPaypalPayment.Enabled = false;
            //Presenter.FinalizeOrder();
        }

        protected void PrintOrderClick(object sender, EventArgs e)
        {
            // Presenter.PrintOrder();
        }

        public PaypalReturn PaypalReturn
        {
            get { return (PaypalReturn)Session["PaypalReturn"]; }
            set
            {
                Session["PaypalReturn"] = value;

            }
        }

        public bool EstFinalise
        {
            set { throw new NotImplementedException(); }
        }

        public string AffichageCommande
        {
            set { throw new NotImplementedException(); }
        }
    }
}