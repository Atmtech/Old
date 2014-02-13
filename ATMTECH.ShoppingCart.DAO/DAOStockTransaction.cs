using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOStockTransaction : BaseDao<StockTransaction, int>, IDAOStockTransaction
    {
        public void StockTransaction(Stock stock, int quantity, Order order)
        {
            StockTransaction stockTransaction = new StockTransaction { Stock = stock, Transaction = quantity, Order = order };
            Save(stockTransaction);
        }
        public int GetCurrentStockStatus(Stock stock)
        {

            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaStock = new Criteria { Column = Entities.StockTransaction.STOCK, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = stock.Id.ToString() };
            criterias.Add(criteriaStock);
            criterias.Add(IsActive());
            OrderOperation orderOperation = new OrderOperation { OrderByColumn = Entities.StockTransaction.STOCK, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };

            IList < StockTransaction > stockTransactions = GetByCriteria(criterias, pagingOperation, orderOperation);
            int total = (from s in stockTransactions
                         select s.Transaction).Sum();

            return stock.InitialState + total;
        }

        public int GetCurrentStockStatus(Stock stock, DateTime dateStart, DateTime dateEnd)
        {
            IList<Criteria> criterias = new List<Criteria>();
         
            Criteria criteriaStock = new Criteria { Column = Entities.StockTransaction.STOCK, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = stock.Id.ToString() };
            
            criterias.Add(criteriaStock);
            criterias.Add(IsActive());

            IList<StockTransaction> stockTransactions = GetByCriteria(criterias);
            stockTransactions = stockTransactions.Where(x => x.DateCreated >= dateStart && x.DateCreated <= dateEnd).ToList();
            int total = (from s in stockTransactions
                         select s.Transaction).Sum();

            return stock.InitialState + total;
        }


        public IList<StockTransaction> GetStockTransactions()
        {
            return GetAllActive();
        }
    }
}
