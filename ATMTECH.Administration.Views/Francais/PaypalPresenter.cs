using System;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface.Francais;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Administration.Views.Francais
{
    public class PaypalPresenter : BaseAdministrationPresenter<IPaypalPresenter>
    {
        public IPaypalService PayPalService { get; set; }
        public PaypalPresenter(IPaypalPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.PaypalReturn = PayPalService.GetReplyFromPaypal();
            View.PaypalReussi = PayPalService.FinishPaypalTransaction(View.PaypalReturn);
        }
    }
}
