using System.Collections.Generic;
using System.Linq;
using ATMTECH.Common.Context;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOEnterpriseAddress : BaseDao<EnterpriseAddress, int>, IDAOEnterpriseAddress
    {


        public IDAOAddress DAOAddress { get; set; }
        public string CurrentLanguage
        {
            get
            {
                return ContextSessionManager.Session["currentLanguage"] == null ? "fr" : ContextSessionManager.Session["currentLanguage"].ToString();
            }
        }

        public IList<Address> GetBillingAddress(Enterprise enterprise)
        {

            if (enterprise != null)
            {
                IList<Criteria> criterias = new List<Criteria>();
                Criteria criteria1 = new Criteria() { Column = EnterpriseAddress.ENTERPRISE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = enterprise.Id.ToString() };
                Criteria criteria2 = new Criteria() { Column = EnterpriseAddress.ADDRESS_TYPE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = EnterpriseAddress.CODE_ADRESS_TYPE_BILLING };
                criterias.Add(criteria1);
                criterias.Add(criteria2);
                criterias.Add(IsActive());

                IList<Address> addresses = GetByCriteria(criterias).Select(enterpriseAddress => enterpriseAddress.Address).ToList();
                return addresses.Select(address => DAOAddress.GetAddress(address.Id)).ToList();
            }
            return null;
        }

        public IList<Address> GetShippingAddress(Enterprise enterprise)
        {
            if (enterprise != null)
            {
                BaseDao<EnterpriseAddress, int> daoAddress = new BaseDao<EnterpriseAddress, int>();
                IList<Criteria> criterias = new List<Criteria>();
                Criteria criteria1 = new Criteria() { Column = EnterpriseAddress.ENTERPRISE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = enterprise.Id.ToString() };
                Criteria criteria2 = new Criteria() { Column = EnterpriseAddress.ADDRESS_TYPE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = EnterpriseAddress.CODE_ADRESS_TYPE_SHIPPING };
                criterias.Add(criteria1);
                criterias.Add(criteria2);
                criterias.Add(IsActive());

                IList<Address> addresses = daoAddress.GetByCriteria(criterias).Select(enterpriseAddress => enterpriseAddress.Address).ToList();
                return addresses.Select(address => DAOAddress.GetAddress(address.Id)).ToList();
            }
            return null;
        }


    }
}
