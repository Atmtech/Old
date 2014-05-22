using System.Collections.Generic;
using System.Linq;
using ATMTECH.Common.Context;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOAddress : BaseDao<Address, int>, IDAOAddress
    {
        public IList<Address> Addresses
        {
            get
            {
                if (ContextSessionManager.Context.Session["Addresses"] == null)
                {
                    ContextSessionManager.Context.Session["Addresses"] = GetAll();
                }
                return (IList<Address>)ContextSessionManager.Context.Session["Addresses"];
            }
            set
            {
                if (ContextSessionManager.Context.Session["Addresses"] == null)
                    ContextSessionManager.Context.Session["Addresses"] = value;
            }
        }

        public Address GetAddress(int id)
        {
            return Addresses.FirstOrDefault(x => x.Id == id);
        }

        public int SaveAdress(Address address)
        {
            ContextSessionManager.Context.Session["Addresses"] = null;
            return Save(address);
        }

        public Address FindAddress(Address address)
        {
            IList<Address> addresses = Addresses.Where(x => x.Way == address.Way || x.PostalCode == address.PostalCode || x.Country == address.Country || x.City == address.City).ToList();
            return addresses.Count > 0 ? addresses[0] : null;


            //IList<Criteria> criterias = new List<Criteria>();
            //Criteria criteria1 = new Criteria() { Column = Address.WAY, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = address.Way };
            //Criteria criteria2 = new Criteria() { Column = Address.POSTAL_CODE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = address.PostalCode };
            //Criteria criteria3 = new Criteria() { Column = Address.COUNTRY, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = address.Country.Id.ToString() };
            //Criteria criteria4 = new Criteria() { Column = Address.CITY, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = address.City.Id.ToString() };
            //criterias.Add(criteria1);
            //criterias.Add(criteria2);
            //criterias.Add(criteria3);
            //criterias.Add(criteria4);
            //criterias.Add(IsActive());

            //IList<Address> addresses = GetByCriteria(criterias);
            //if (addresses.Count > 0)
            //{
            //    return addresses[0];
            //}
            //return null;
        }
    }
}
