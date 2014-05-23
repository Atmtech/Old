using ATMTECH.Common.Context;
using ATMTECH.Entities;
using ATMTECH.Utils.Web;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;
using ATMTECH.Web.Services.PaypalSandboxService;

namespace ATMTECH.Web.Services
{
    public class PaypalService : BaseService, IPaypalService
    {
        public IParameterService ParameterService { get; set; }
        public IMessageService MessageService { get; set; }
        public ILogService LogService { get; set; }
        public void SendPaypalRequest(PaypalDto paypalDto)
        {
            SetExpressCheckoutRequestDetailsType reqDetails =
               new SetExpressCheckoutRequestDetailsType
               {
                   ReturnURL = Pages.GetCurrentHttpServer() + "/ExpressCheckoutPaypal.aspx",
                   CancelURL = Pages.GetCurrentHttpServer() + "/Default.aspx",
                   NoShipping = "1",
                   InvoiceID = paypalDto.OrderId,
                   OrderDescription = paypalDto.OrderDescription,
                   OrderTotal = new BasicAmountType()
                   {
                       currencyID = CurrencyCodeType.CAD,
                       Value = paypalDto.TotalPrice.ToString().Replace(",", ".").Replace(" ", "")
                   }
               };

            PaymentDetailsType paymentDetails = new PaymentDetailsType();
            PaymentDetailsItemType item = new PaymentDetailsItemType
            {
                Amount = new BasicAmountType
                            {
                                currencyID = CurrencyCodeType.CAD,
                                Value = paypalDto.TotalPrice.ToString().Replace(",", ".").Replace(" ", "")
                            },

                Name = paypalDto.ProductName,
                Number = paypalDto.ProductId,
                Quantity = paypalDto.Quantity.ToString()
            };

            paymentDetails.PaymentDetailsItem = new[] { item };
            reqDetails.PaymentDetails = new[] { paymentDetails };
            SetExpressCheckoutReq req = new SetExpressCheckoutReq()
            {
                SetExpressCheckoutRequest = new SetExpressCheckoutRequestType()
                {
                    Version = "63",
                    SetExpressCheckoutRequestDetails = reqDetails
                }
            };

            CustomSecurityHeaderType type = GetCustomSecurityHeaderType();
            PayPalAPIAAInterfaceClient paypalAAInt = new PayPalAPIAAInterfaceClient();
            var resp = paypalAAInt.SetExpressCheckout(ref type, req);
            if (resp.Errors != null && resp.Errors.Length > 0)
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.ADM_PAYPAL_SEND_FAILED, resp.Errors[0].LongMessage);
            }
            else
            {
                //if (ParameterService.GetValue("Environment") != "PROD")
                //{
                //    ContextSessionManager.Context.Response.Redirect(string.Format("{0}?cmd=_express-checkout&token={1}",
                //      "https://www.sandbox.paypal.com/cgi-bin/webscr", resp.Token));
                //}
                //else
                //{
                    ContextSessionManager.Context.Response.Redirect(string.Format("{0}?cmd=_express-checkout&token={1}",
                      "https://www.paypal.com/cgi-bin/webscr", resp.Token));
                //}
            }
        }
        public PaypalReturn GetReplyFromPaypal()
        {
            string token = ContextSessionManager.Context.Request.QueryString["token"];
            CustomSecurityHeaderType type = GetCustomSecurityHeaderType();
            GetExpressCheckoutDetailsReq req = new GetExpressCheckoutDetailsReq()
            {
                GetExpressCheckoutDetailsRequest = new GetExpressCheckoutDetailsRequestType()
                {
                    Version = "63.0",
                    Token = token
                }
            };

            PayPalAPIAAInterfaceClient paypalAAInt = new PayPalAPIAAInterfaceClient();
            GetExpressCheckoutDetailsResponseType resp = paypalAAInt.GetExpressCheckoutDetails(ref type, req);
            if (resp.Errors != null && resp.Errors.Length > 0)
            {
                throw new System.Exception("Erreur appel à Paypal: " +
                    resp.Errors[0].LongMessage);
            }
            GetExpressCheckoutDetailsResponseDetailsType respDetails = resp.GetExpressCheckoutDetailsResponseDetails;
            PaypalReturn paypalReturn = new PaypalReturn()
            {
                Response = resp,
                ResponseDetails = respDetails
            };
            return paypalReturn;
        }
        public bool FinishPaypalTransaction(PaypalReturn paypalReturn)
        {
            GetExpressCheckoutDetailsResponseType resp = paypalReturn.Response;
            CustomSecurityHeaderType type = GetCustomSecurityHeaderType();
            DoExpressCheckoutPaymentReq payReq = new DoExpressCheckoutPaymentReq()
            {
                DoExpressCheckoutPaymentRequest = new DoExpressCheckoutPaymentRequestType()
                {
                    Version = "63.0",
                    DoExpressCheckoutPaymentRequestDetails = new DoExpressCheckoutPaymentRequestDetailsType()
                    {
                        Token = resp.GetExpressCheckoutDetailsResponseDetails.Token,
                        PaymentAction = PaymentActionCodeType.Sale,
                        PaymentActionSpecified = true,
                        PayerID = resp.GetExpressCheckoutDetailsResponseDetails.PayerInfo.PayerID,
                        PaymentDetails = new[] {
                                new PaymentDetailsType()
                                {
                                    OrderTotal = new BasicAmountType()
                                    {
                                        currencyID = CurrencyCodeType.CAD,
                                        Value =  paypalReturn.ResponseDetails.PaymentDetails[0].OrderTotal.Value
                                    }
                                }
                            }
                    }
                }
            };

            PayPalAPIAAInterfaceClient paypalAAInt = new PayPalAPIAAInterfaceClient();
            DoExpressCheckoutPaymentResponseType doResponse = paypalAAInt.DoExpressCheckoutPayment(ref type, payReq);

            if (doResponse.Errors != null && doResponse.Errors.Length > 0)
            {
                Message message = new Message
                    {
                        Description = "Finish paypal failed: " + doResponse.Errors[0].LongMessage
                    };
                LogService.LogException(message);

                return false;
            }

            return true;
        }
        private CustomSecurityHeaderType GetCustomSecurityHeaderType()
        {
            CustomSecurityHeaderType type = new CustomSecurityHeaderType();
            if (ParameterService.GetValue("Environment") != "PROD")
            {
                type.Credentials = new UserIdPasswordType()
                {
                    Username = "louise_api1.pubjl.com",
                    Password = "BNCVURP73DC6Y74S",
                    Signature = "AFcWxV21C7fd0v3bYYYRCpSSRl31AgyJ2t3pDKSd8PcS5xlZCHYLtkxV"
                };
            }
            else
            {
                type.Credentials = new UserIdPasswordType()
                {
                    Username = "louise_api1.pubjl.com",
                    Password = "BNCVURP73DC6Y74S",
                    Signature = "AFcWxV21C7fd0v3bYYYRCpSSRl31AgyJ2t3pDKSd8PcS5xlZCHYLtkxV"
                };
            }
            return type;
        }
    }

    public class PaypalDto
    {
        public string OrderId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string OrderDescription { get; set; }
        public string ProductName { get; set; }
        public string ProductId { get; set; }
        public double TotalPrice { get { return Price * Quantity; } }
    }

    public class PaypalReturn
    {
        public GetExpressCheckoutDetailsResponseType Response { get; set; }
        public GetExpressCheckoutDetailsResponseDetailsType ResponseDetails { get; set; }
    }
}
