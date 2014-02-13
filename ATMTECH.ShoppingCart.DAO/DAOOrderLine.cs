using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOOrderLine : BaseDao<OrderLine, int>, IDAOOrderLine
    {
        
        public IList<OrderLine> GetOrderLine(int id)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaOrders = new Criteria() { Column = OrderLine.ORDERS, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = id.ToString() };
            criterias.Add(criteriaOrders);
            criterias.Add(IsActive());

            OrderOperation orderOperation = new OrderOperation() { OrderByColumn = BaseEntity.ID, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation() { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };
            return GetByCriteria(criterias, pagingOperation, orderOperation);
        }

        public int Update(OrderLine orderLine)
        {
            return Save(orderLine);
        }



    }
}
