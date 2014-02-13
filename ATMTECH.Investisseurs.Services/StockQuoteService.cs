using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using ATMTECH.Investisseurs.Entities;
using ATMTECH.Investisseurs.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.Investisseurs.Services
{
    public class StockQuoteService : BaseService, IStockQuoteService
    {

        //        1 day: http://ichart.finance.yahoo.com/b?s=MSFT
        //5 days: http://ichart.finance.yahoo.com/w?s=MSFT
        //3 months: http://chart.finance.yahoo.com/c/3m/msft
        //6 months: http://chart.finance.yahoo.com/c/6m/msft
        //1 year: http://chart.finance.yahoo.com/c/1y/msft
        //2 years: http://chart.finance.yahoo.com/c/2y/msft
        //5 years: http://chart.finance.yahoo.com/c/5y/msft
        //Max: http://chart.finance.yahoo.com/c/my/msft

        //a	Ask	a2	Average Daily Volume	a5	Ask Size
        //b	Bid	b2	Ask (Real-time)	b3	Bid (Real-time)
        //b4	Book Value	b6	Bid Size	c	Change & Percent Change
        //c1	Change	c3	Commission	c6	Change (Real-time)
        //c8	After Hours Change (Real-time)	d	Dividend/Share	d1	Last Trade Date
        //d2	Trade Date	e	Earnings/Share	e1	Error Indication (returned for symbol changed / invalid)
        //e7	EPS Estimate Current Year	e8	EPS Estimate Next Year	e9	EPS Estimate Next Quarter
        //f6	Float Shares	g	Day’s Low	h	Day’s High
        //j	52-week Low	k	52-week High	g1	Holdings Gain Percent
        //g3	Annualized Gain	g4	Holdings Gain	g5	Holdings Gain Percent (Real-time)
        //g6	Holdings Gain (Real-time)	i	More Info	i5	Order Book (Real-time)
        //j1	Market Capitalization	j3	Market Cap (Real-time)	j4	EBITDA
        //j5	Change From 52-week Low	j6	Percent Change From 52-week Low	k1	Last Trade (Real-time) With Time
        //k2	Change Percent (Real-time)	k3	Last Trade Size	k4	Change From 52-week High
        //k5	Percebt Change From 52-week High	l	Last Trade (With Time)	l1	Last Trade (Price Only)
        //l2	High Limit	l3	Low Limit	m	Day’s Range
        //m2	Day’s Range (Real-time)	m3	50-day Moving Average	m4	200-day Moving Average
        //m5	Change From 200-day Moving Average	m6	Percent Change From 200-day Moving Average	m7	Change From 50-day Moving Average
        //m8	Percent Change From 50-day Moving Average	n	Name	n4	Notes
        //o	Open	p	Previous Close	p1	Price Paid
        //p2	Change in Percent	p5	Price/Sales	p6	Price/Book
        //q	Ex-Dividend Date	r	P/E Ratio	r1	Dividend Pay Date
        //r2	P/E Ratio (Real-time)	r5	PEG Ratio	r6	Price/EPS Estimate Current Year
        //r7	Price/EPS Estimate Next Year	s	Symbol	s1	Shares Owned
        //s7	Short Ratio	t1	Last Trade Time	t6	Trade Links
        //t7	Ticker Trend	t8	1 yr Target Price	v	Volume/td>
        //v1	Holdings Value	v7	Holdings Value (Real-time)/td>	w	52-week Range
        //w1	Day’s Value Change	w4	Day’s Value Change (Real-time)	x	Stock Exchange
        //y	Dividend Yield				

        private StreamReader GetStreamFromYahooFinance(string symbols)
        {
            string yahooURL = @"http://download.finance.yahoo.com/d/quotes.csv?s=" + symbols + "&f=sl1d1t1c1hgvbap2";
            HttpWebRequest webreq = (HttpWebRequest)WebRequest.Create(yahooURL);
            HttpWebResponse webresp = (HttpWebResponse)webreq.GetResponse();
            return new StreamReader(webresp.GetResponseStream(), Encoding.ASCII);
        }

        private Double ConvertNumberQuote(string number)
        {
            string temp = number.Replace(".", ",");
            return temp == "N/A" ? 0 : Convert.ToDouble(temp);
        }

        public IList<StockQuote> GetQuote(string symbols)
        {
            IList<StockQuote> stockQuotes = new List<StockQuote>();
            try
            {
                string[] arraySymbol = symbols.Replace(",", " ").Split(' ');
                StreamReader streamReader = GetStreamFromYahooFinance(symbols);
                foreach (string t in arraySymbol)
                {
                    if (t.Trim() == "")
                        continue;

                    string content = streamReader.ReadLine().Replace("\"", "");
                    string[] contents = content.Split(',');
                    StockQuote stockQuote = new StockQuote();
                    if (contents[2] == "N/A")
                    {
                        stockQuote.Symbol = "Symbole inconnu";
                    }
                    else
                    {
                        stockQuote.Symbol = content[0].ToString();
                        stockQuote.Last = ConvertNumberQuote(contents[1]);
                        stockQuote.Date = Convert.ToDateTime(contents[2]);
                        stockQuote.Time = contents[3];

                        switch (contents[4].Trim().Substring(0, 1))
                        {
                            case "-":
                                stockQuote.Change = "&lt;span style='color:red'&gt;" + contents[4] + "(" + contents[10] + ")" + "&lt;span&gt;";
                                break;
                            case "+":
                                stockQuote.Change = "&lt;span style='color:green'&gt;" + contents[4] + "(" + contents[10] + ")" + "&lt;span&gt;";
                                break;
                            default:
                                stockQuote.Change = contents[4] + "(" + contents[10] + ")";
                                break;
                        }

                        stockQuote.High = ConvertNumberQuote(contents[5]);
                        stockQuote.Low = ConvertNumberQuote(contents[6]);
                        stockQuote.Volume = Convert.ToInt32(contents[7]);

                        stockQuote.Bid = ConvertNumberQuote(contents[8]);
                        stockQuote.Ask = ConvertNumberQuote(contents[9]);
                    }
                    stockQuotes.Add(stockQuote);
                }

                streamReader.Close();
                return stockQuotes;
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
