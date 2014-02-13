using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATMTECH.Web.Services.Interface
{
    public interface IPaypalService
    {
        void SendPaypalRequest(PaypalDto paypalDto);
        PaypalReturn GetReplyFromPaypal();
        bool FinishPaypalTransaction(PaypalReturn paypalReturn);
    }
}
