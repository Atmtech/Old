
using ATMTECH.Investisseurs.Entities;

namespace ATMTECH.Investisseurs.Services.Interface
{
    public interface ITransactionService
    {
        
        void BuyAction(int quantity, string symbol);
        void SellAction(int quantity, double currentValue, string symbol);
    }
}
