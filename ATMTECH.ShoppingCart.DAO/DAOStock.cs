using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOStock : BaseDao<Stock, int>, IDAOStock
    {
        public IList<Stock> GetStockByEnterprise(int idEnterprise)
        {
            return
                GetBySql(
                    "SELECT STOCK.Id as Id, STOCK.[Description], STOCK.[IsActive], STOCK.[DateCreated], STOCK.[DateModified],STOCK.[Language],STOCK.[OrderId],STOCK.[Search],STOCK.[ComboboxDescription],[Product],[InitialState],[MinimumAccept],[IsWarningOnLow],[FeatureFrench],[FeatureEnglish],[AdjustPrice],[IsWithoutStock], STOCK.[UserLoginModified] FROM STOCK INNER JOIN PRODUCT ON STOCK.Product = Product.Id and Product.Enterprise = " + idEnterprise + "  INNER JOIN ENTERPRISE ON Product.[Enterprise] = ENTERPRISE.ID");
        }



        public IList<Stock> GetProductStock(int idProduct)
        {
            IList<Stock> listStock = GetAllOneCriteria(Stock.PRODUCT, idProduct.ToString());
            return listStock.Where(x => x.IsActive).OrderBy(x => x.OrderId).ToList();
        }

        public Stock GetStock(int idStock)
        {
            return GetById(idStock);
        }

        public void UpdateStock(Stock stock)
        {
            Save(stock);
        }




        public IList<Stock> GetAllStock(int pageSize, int pageIndex)
        {
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(IsActive());
            PagingOperation pagingOperation = new PagingOperation { PageIndex = pageIndex, PageSize = pageSize };
            OrderOperation orderOperation = new OrderOperation { OrderByColumn = BaseEntity.ID, OrderByType = OrderBy.Type.Ascending };
            return GetByCriteria(criterias, pagingOperation, orderOperation);
        }

        public int CreateStock(Stock stock)
        {
            return Save(stock);
        }

        public IList<Stock> GetAllStock()
        {
            return GetAllActive();
        }
    }
}
