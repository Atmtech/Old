using ATMTECH.Investisseurs.Services.Interface;
using ATMTECH.Investisseurs.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Investisseurs.Views
{
    public class DefaultPresenter : BaseInvestisseursPresenter<IDefaultPresenter>
    {

        public IStockQuoteService StockQuoteService { get; set; }
        public ITransactionService TransactionService { get; set; }
        public IPlayerService PlayerService { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }

        public DefaultPresenter(IDefaultPresenter view)
            : base(view)
        {
        }

        public void GetQuote(string symbols)
        {
            View.StockQuotes = StockQuoteService.GetQuote(symbols);
        }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            AuthenticationService.SignIn("riov01", "test");
            View.IsLogged = PlayerService.AuthenticatePlayer != null;
        }

        public void BuyQuote(string symbol, int quantity)
        {
            TransactionService.BuyAction(quantity, symbol);
        }
    }
}
