using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Francais
{
    public class DAOClient : BaseDao<Customer, int>, IDAOClient
    {
        public IDAOUser DAOUser { get; set; }
        public Customer ObtenirClient(User user)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaUser = new Criteria { Column = Customer.USER, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = user.Id.ToString() };
            criterias.Add(criteriaUser);
            criterias.Add(IsActive());
            IList<Customer> rtn = GetByCriteria(criterias);
            if (rtn.Count > 0)
            {
                rtn[0].User = user;
                return rtn[0];
            }
            return null;
        }

        public Customer ObtenirClient(int id)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaUser = new Criteria { Column = BaseEntity.ID, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = id.ToString() };
            criterias.Add(criteriaUser);
            criterias.Add(IsActive());
            IList<Customer> rtn = GetByCriteria(criterias);
            if (rtn.Count > 0)
            {
                rtn[0].User = DAOUser.GetUser(rtn[0].User.Id);
                return rtn[0];
            }
            return null;
        }

        public int Creer(Customer client)
        {
            return Save(client);
        }
    }
}
