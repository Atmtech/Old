using System;
using ATMTECH.Services.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Francais;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class ConfirmationPaypalPresenter : BaseShoppingCartPresenter<IConfirmationPaypalPresenter>
    {
        public IPaypalService PayPalService { get; set; }
        public ICommandeService CommandeService { get; set; }
        public IReportService ReportService { get; set; }

        public ConfirmationPaypalPresenter(IConfirmationPaypalPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherCommande();
        }
        public void AfficherCommande()
        {
            View.PaypalReturn = PayPalService.GetReplyFromPaypal();
            int id = Convert.ToInt32(View.PaypalReturn.ResponseDetails.InvoiceID);
            View.AffichageCommande = CommandeService.AfficherCommande(id);
        }
        public void FinaliserCommande()
        {
            if (PayPalService.FinishPaypalTransaction(View.PaypalReturn))
            {
                int orderId = Convert.ToInt32(View.PaypalReturn.ResponseDetails.InvoiceID);
                Order order = CommandeService.ObtenirCommande(orderId);
                CommandeService.FinaliserCommande(order);
                View.EstFinalise = true;
                return;
            }

            View.EstFinalise = false;
            MessageService.ThrowMessage(CodeErreur.ADM_PAYPAL_FINISH_FAILED);
        }
        public void ImprimerCommande()
        {
            int orderId = Convert.ToInt32(View.PaypalReturn.ResponseDetails.InvoiceID);
            Order order = CommandeService.ObtenirCommande(orderId);
            CommandeService.ImprimerCommande(order);
        }
    }
}
