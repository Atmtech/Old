using System.Collections.Generic;
using System.Linq;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;

namespace ATMTECH.Administration.Views
{
    public class StockTransactionPresenter : BaseAdministrationPresenter<IStockTransactionPresenter>
    {
        public IStockService StockService { get; set; }
        public StockTransactionPresenter(IStockTransactionPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.Stocks = StockService.GetAllStock();
        }

        public string GetStockInformation(int id)
        {
            string html = string.Empty;
            Stock stock = StockService.GetStock(id);
            IList<StockTransaction> stockTransactions = StockService.GetAllStockTransaction();
            stockTransactions = stockTransactions.Where(x => x.Stock.Id == stock.Id).ToList();

            html += "<h2>" + stock.ComboboxDescription + "</h2><hr>";

            if (stockTransactions.Count == 0)
            {
                html += "Aucune transaction de commande sur cet inventaire";

            }
            else
            {
                html += "<table style='border:solid 1px #7F4614;width:600px;'>";
                html += "<tr style='background-color:goldenrod;color:white;font-size:15px;font-weight:bold;'><th>Date transaction</th><th>Quantité</th><th>Numero de commande</th></tr>";
                foreach (StockTransaction stockTransaction in stockTransactions)
                {
                    html += "<tr><td>" + stockTransaction.DateCreated + "</td><td>" + stockTransaction.Transaction + "</td><td>" + stockTransaction.Stock.Id + "</td></tr>";
                }
                html += "</table>";
            }

            int currentStockStatus = StockService.GetCurrentStockStatus(stock);
            html += "<table style='font-weight:bold;'><tr><td>Le nombre initial en inventaire</td><td>" + stock.InitialState + "</td></tr>";
            html += "<tr><td>Le nombre actuellement en inventaire</td><td>" + currentStockStatus + "</td></tr></table>";
            return html;
        }
    }
}
