using System;
using ATMTECH.Investisseurs.DAO.Interface;
using ATMTECH.Investisseurs.Entities;
using ATMTECH.Investisseurs.Services.Base;
using ATMTECH.Investisseurs.Services.Interface;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Investisseurs.Services
{
    public class TransactionService : BaseService, ITransactionService
    {
        public IAuthenticationService AuthenticationService { get; set; }
        public IParameterService ParameterService { get; set; }
        
        public IDAOTransaction DAOTransaction { get; set; }
        public IMessageService MessageService { get; set; }
        public IStockQuoteService StockQuoteService { get; set; }
        public IDAOPlayerStockQuote DAOPlayerStockQuote { get; set; }
        public IPlayerService PlayerService { get; set; }


        public void BuyAction(int quantity, string symbol)
        {
            double transactionFee = GetTransactionFee();
            double currentValue = StockQuoteService.GetQuote(symbol)[0].Ask;
            double calculateValue = quantity * currentValue + transactionFee;

            if (GetCurrentAccountBalance() < calculateValue)
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.IN_ACCOUNT_BALANCE_TO_LOW);
            }
            else
            {
                Transaction transaction = new Transaction
                                              {
                                                  Amount = calculateValue * -1,
                                                  Player = PlayerService.AuthenticatePlayer,
                                                  Quantity = quantity,
                                                  StockQuoteSymbol = symbol,
                                                  TransactionFee = transactionFee
                                              };
                PlayerStockQuote playerStockQuote = new PlayerStockQuote
                                                        {
                                                            Player = PlayerService.AuthenticatePlayer,
                                                            Quantity = quantity,
                                                            Symbol = symbol
                                                        };
                DAOPlayerStockQuote.AddPlayerStockQuote(playerStockQuote);
                AddTransaction(transaction);
            }

        }
        public void SellAction(int quantity, double currentValue, string symbol)
        {
            double transactionFee = GetTransactionFee();
            double calculateValue = (quantity * currentValue) - transactionFee;
            Transaction transaction = new Transaction
                                          {
                                              Amount = calculateValue,
                                              Player = PlayerService.AuthenticatePlayer,
                                              Quantity = quantity,
                                              StockQuoteSymbol = symbol,
                                              TransactionFee = transactionFee
                                          };
            AddTransaction(transaction);
        }



        private void AddTransaction(Transaction transaction)
        {
            DAOTransaction.AddTransaction(transaction);
        }
        private double GetTransactionFee()
        {
            return Convert.ToDouble(ParameterService.GetValue(Constant.TRANSACTION_FEE).Replace(".", ","));
        }
        private double GetCurrentAccountBalance()
        {
            return DAOTransaction.GetCurrentAccountBalance(PlayerService.AuthenticatePlayer);
        }

    }
}
