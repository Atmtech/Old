using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Francais
{
    public class DAOClient : BaseDao<Customer, int>, IDAOClient
    {
        public IDAOUser DAOUser { get; set; }
        public IDAOAddress DAOAddress { get; set; }
        public IDAOCity DAOCity { get; set; }

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
                if (rtn[0].ShippingAddress != null && rtn[0].ShippingAddress.Id != 0)
                {
                    rtn[0].ShippingAddress = DAOAddress.GetAddress(rtn[0].ShippingAddress.Id);
                    if (rtn[0].ShippingAddress != null)
                        rtn[0].ShippingAddress.City = DAOCity.GetCity(rtn[0].ShippingAddress.City.Id);
                }
                if (rtn[0].BillingAddress != null && rtn[0].BillingAddress.Id != 0)
                {

                    rtn[0].BillingAddress = DAOAddress.GetAddress(rtn[0].BillingAddress.Id);
                    if (rtn[0].BillingAddress != null)
                        rtn[0].BillingAddress.City = DAOCity.GetCity(rtn[0].BillingAddress.City.Id);
                }


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
