using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Francais
{
    public class DAOLigneCommande : BaseDao<OrderLine, int>, IDAOLigneCommande
    {
        public IList<OrderLine> ObtenirLigneCommande(Order commande)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaOrders = new Criteria() { Column = OrderLine.ORDERS, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = commande.Id.ToString() };
            criterias.Add(criteriaOrders);
            criterias.Add(IsActive());

            OrderOperation orderOperation = new OrderOperation() { OrderByColumn = BaseEntity.ID, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation() { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };
            return GetByCriteria(criterias, pagingOperation, orderOperation);
        }
    }
}
