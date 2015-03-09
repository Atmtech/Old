using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Services.Francais
{
    public class ValiderCommandeService : BaseService, IValiderCommandeService
    {
        public IMessageService MessageService { get; set; }

        public bool EstClientValide(Customer client)
        {
            if (client == null)
            {
                MessageService.ThrowMessage(ErrorCode.SC_CUSTOMER_IS_NULL);
                return false;
            }
            return true;
        }
    }
}

