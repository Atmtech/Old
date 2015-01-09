using System;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Views
{
    public class ExpressCheckoutPaypalPresenter : BaseShoppingCartPresenter<IExpressCheckoutPaypalPresenter>
    {
        public IPaypalService PayPalService { get; set; }
        public IOrderService OrderService { get; set; }
        public ATMTECH.Services.Interface.IReportService ReportService { get; set; }

        public ExpressCheckoutPaypalPresenter(IExpressCheckoutPaypalPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.PaypalReturn = PayPalService.GetReplyFromPaypal();
            int orderId = Convert.ToInt32(View.PaypalReturn.ResponseDetails.InvoiceID);
            View.OrderDisplay = OrderService.GetOrderWithFormat(orderId);
        }

        public void FinalizeOrder()
        {
            if (PayPalService.FinishPaypalTransaction(View.PaypalReturn))
            {
                int orderId = Convert.ToInt32(View.PaypalReturn.ResponseDetails.InvoiceID);
                Order order = OrderService.GetOrder(orderId);

                if (OrderService.FinalizeOrder(order, null) != -1)
                {
                    View.IsOrderFinalized = true;
                    return;
                }
            }

            View.IsOrderFinalized = false;
            MessageService.ThrowMessage(ErrorCode.ADM_PAYPAL_FINISH_FAILED);
        }


        public void PrintOrder()
        {
            int orderId = Convert.ToInt32(View.PaypalReturn.ResponseDetails.InvoiceID);
            Order order = OrderService.GetOrder(orderId);
            OrderService.PrintOrder(order);
        }
    }
}
