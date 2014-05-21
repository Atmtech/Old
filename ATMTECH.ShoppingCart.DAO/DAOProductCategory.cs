using System.Collections.Generic;
using ATMTECH.Common.Context;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOProductCategory : BaseDao<ProductCategory, int>, IDAOProductCategory
    {
        public string CurrentLanguage
        {
            get { return ContextSessionManager.Session["currentLanguage"].ToString(); }
        }

        public ProductCategory GetProductCategory(int id)
        {
            return GetById(id);
        }

        public IList<ProductCategory> GetProductCategoryFromEnterprise(int idEnterprise)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaEnterprise = new Criteria { Column = ProductCategory.ENTERPRISE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idEnterprise.ToString() };
            
            criterias.Add(criteriaEnterprise);
            criterias.Add(IsActive());

            OrderOperation orderOperation = new OrderOperation { OrderByColumn = BaseEntity.ORDER_ID, OrderByType = OrderBy.Type.Ascending };
            PagingOperation pagingOperation = new PagingOperation { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };
            SetLanguage(criterias, CurrentLanguage);
             IList<ProductCategory> rtn = GetByCriteria(criterias, pagingOperation, orderOperation);
            return rtn;

        }

        public IList<ProductCategory> GetProductCategoryFromEnterpriseWithoutLanguage(int idEnterprise)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaEnterprise = new Criteria { Column = ProductCategory.ENTERPRISE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idEnterprise.ToString() };
            
            criterias.Add(criteriaEnterprise);
            criterias.Add(IsActive());

            OrderOperation orderOperation = new OrderOperation { OrderByColumn = BaseEnumeration.CODE, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };
            return GetByCriteria(criterias, pagingOperation, orderOperation);
        }

    }
}
