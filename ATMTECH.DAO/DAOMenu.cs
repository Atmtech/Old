using System.Collections.Generic;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;

namespace ATMTECH.DAO
{
    public class DAOMenu : BaseDao<Menu, int>, IDAOMenu
    {
        public IList<Menu> GetMenu(string menuId)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaMenu = new Criteria() { Column = Menu.MENU_ID, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = menuId };
            Criteria criteriaActive = new Criteria() { Column = BaseEntity.IS_ACTIVE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = "1" };
            criterias.Add(criteriaMenu);
            criterias.Add(criteriaActive);

            OrderOperation orderOperation = new OrderOperation() { OrderByColumn = BaseEntity.ID, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation() { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };

            IList<Menu> menus = GetByCriteria(criterias, pagingOperation, orderOperation);
            foreach (Menu menu in menus)
            {
                menu.SubMenu = GetAllOneCriteria(Menu.PARENT_ID, menu.Id.ToString());
            }

            return menus;
           
        }
    }
}
