using ATMTECH.Investisseurs.Services.Interface;
using ATMTECH.Shell;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Investisseurs.Services.Base
{
    public class InvestisseursInitializer : BaseModuleInitializer
    {
        public override void InitDependency()
        {
            // Site
            AddDependency<IStockQuoteService, StockQuoteService>();
            AddDependency<ILocalizationService, LocalizationService>();
             
        }
    }
}
