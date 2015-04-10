using System;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class ConfirmationPaypalPresenter : BaseShoppingCartPresenter<IConfirmationPaypalPresenter>
    {
        public IPaypalService PayPalService { get; set; }
        public ICommandeService CommandeService { get; set; }
        public ATMTECH.Services.Interface.IReportService ReportService { get; set; }

        public ConfirmationPaypalPresenter(IConfirmationPaypalPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            //base.OnViewInitialized();
            //View.PaypalReturn = PayPalService.GetReplyFromPaypal();
            //int orderId = Convert.ToInt32(View.PaypalReturn.ResponseDetails.InvoiceID);
            //View.AffichageCommande = OrderService.GetOrderWithFormat(orderId);
        }

        public void FinaliserCommande()
        {
            //if (PayPalService.FinishPaypalTransaction(View.PaypalReturn))
            //{
            //    int orderId = Convert.ToInt32(View.PaypalReturn.ResponseDetails.InvoiceID);
            //    Order order = OrderService.GetOrder(orderId);

            //    if (OrderService.FinalizeOrder(order, null) != -1)
            //    {
            //        View.EstFinalise = true;
            //        return;
            //    }
            //}

            //View.EstFinalise = false;
            //MessageService.ThrowMessage(ErrorCode.ADM_PAYPAL_FINISH_FAILED);
        }


        public void ImprimerCommande()
        {
            //int orderId = Convert.ToInt32(View.PaypalReturn.ResponseDetails.InvoiceID);
            //Order order = OrderService.GetOrder(orderId);
            //OrderService.PrintOrder(order);
        }
    }
}
