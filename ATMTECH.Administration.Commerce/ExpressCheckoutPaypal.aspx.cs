using System;
using ATMTECH.Administration.Views.Francais;
using ATMTECH.Administration.Views.Interface.Francais;
using ATMTECH.Web.Services;

namespace ATMTECH.Administration.Commerce
{
    public partial class ExpressCheckoutPaypal : PageBase<PaypalPresenter, IPaypalPresenter>, IPaypalPresenter
    {

        public PaypalReturn PaypalReturn
        {
            get { return (PaypalReturn)Session["PaypalReturn"]; }
            set
            {
                Session["PaypalReturn"] = value;
                lblNoCommande.Text = value.ResponseDetails.InvoiceID;
                lblDescriptionCommande.Text = value.ResponseDetails.PaymentDetails[0].OrderDescription;
                lblPrix.Text = value.ResponseDetails.PaymentDetails[0].OrderTotal.Value;
                lblPayeur.Text = value.ResponseDetails.PayerInfo.PayerName.FirstName + " " +
                                 value.ResponseDetails.PayerInfo.PayerName.LastName;
            }
        }

        public bool PaypalReussi
        {
            set
            {
                if (value)
                {
                    lblResultat.Text = "Succès";
                }
                else
                {
                    lblResultat.Text = "Échec";
                }
            }

        }
    }
}