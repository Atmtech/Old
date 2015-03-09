using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Francais
{
    public class DAOCommande : BaseDao<Order, int>, IDAOCommande
    {
        public Order ObtenirCommandeSouhaite(Customer customer)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaUser = new Criteria { Column = Order.CUSTOMER, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = customer.Id.ToString() };
            Criteria criteriaCommandeStatus = new Criteria { Column = Order.ORDER_STATUS, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = OrderStatus.IsWishList.ToString() };
            criterias.Add(criteriaUser);
            criterias.Add(criteriaCommandeStatus);
            criterias.Add(IsActive());
            IList<Order> commandes = GetByCriteria(criterias);
            return commandes.Count > 0 ? commandes[0] : null;
        }
    }
}
