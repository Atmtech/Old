using System;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Tests.Builder
{
    public static class StockTransactionBuilder
    {
        public static StockTransaction Create()
        {
            return new StockTransaction() { Id = 1 };
        }

        public static StockTransaction WithStock(this StockTransaction stockTransaction, Stock stock)
        {
            stockTransaction.Stock = stock;
            return stockTransaction;
        }

        public static StockTransaction WithTransaction(this StockTransaction stockTransaction, int transaction)
        {
            stockTransaction.Transaction = transaction;
            return stockTransaction;
        }

        public static StockTransaction WithDateCreated(this StockTransaction stockTransaction, DateTime dateTime)
        {
            stockTransaction.DateCreated = dateTime;
            return stockTransaction;
        }
    }
}
