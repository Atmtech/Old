using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Francais
{
    public class DAOInventaire : BaseDao<Stock, int>, IDAOInventaire
    {
        public IList<Stock> ObtenirStock(Product product)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaProduct = new Criteria { Column = Stock.PRODUCT, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = product.Id.ToString() };
            criterias.Add(criteriaProduct);
            criterias.Add(IsActive());
            OrderOperation orderOperation = new OrderOperation { OrderByColumn = BaseEntity.ORDER_ID, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };
            return GetByCriteria(criterias, pagingOperation, orderOperation);
        }
    }
}
