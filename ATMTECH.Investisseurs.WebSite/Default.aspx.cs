using System;
using System.Collections.Generic;
using ATMTECH.Investisseurs.Entities;
using ATMTECH.Investisseurs.Views;
using ATMTECH.Investisseurs.Views.Interface;
using ATMTECH.Investisseurs.WebSite.Base;

namespace ATMTECH.Investisseurs.WebSite
{
    public partial class Default : PageBaseInvestisseurs, IDefaultPresenter
    {
        public DefaultPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();

        }
        protected void GetQuoteClick(object sender, EventArgs e)
        {
            Presenter.GetQuote(txtStockQuote.Text);
        }

        public bool IsLogged { get; set; }

        public IList<StockQuote> StockQuotes
        {
            set
            {
                if (value.Count > 0)
                {
                    pnlBuyStock.Visible = true;
                    foreach (StockQuote stockQuote in value)
                    {
                        lblAsk.Text = stockQuote.Ask.ToString();
                        lblBid.Text = stockQuote.Bid.ToString();
                        lblSymBol.Text = txtStockQuote.Text;
                    }
                }

            }
        }

        public string InformationPlayer
        {
            set { lblPlayer.Text = value; }
        }

        protected void BuyQuoteClick(object sender, EventArgs e)
        {
            Presenter.BuyQuote(lblSymBol.Text, Convert.ToInt32(txtQuantity.Text));
        }
    }
}