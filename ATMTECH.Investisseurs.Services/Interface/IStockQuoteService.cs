using System.Collections.Generic;
using ATMTECH.Investisseurs.Entities;

namespace ATMTECH.Investisseurs.Services.Interface
{
    public interface IStockQuoteService
    {
        IList<StockQuote> GetQuote(string symbols);
    }
}
