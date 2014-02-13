using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.Scrum.DAO.Interface;
using ATMTECH.Scrum.Entities;

namespace ATMTECH.Scrum.DAO
{
    public class DAOSprint : BaseDao<Sprint, int>, IDAOSprint
    {
        public IDAOStory DAOStory { get; set; }

        public IList<Sprint> GetByProduct(int idProduct)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteria1 = new Criteria() { Column = Sprint.PRODUCT, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idProduct.ToString() };
            Criteria criteria2 = new Criteria() { Column = BaseEntity.IS_ACTIVE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = "1" };

            PagingOperation pagingOperation = new PagingOperation() { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };
            OrderOperation orderOperation = new OrderOperation() { OrderByColumn = Sprint.START, OrderByType = OrderBy.Type.Ascending };

            criterias.Add(criteria1);
            criterias.Add(criteria2);
            IList<Sprint> sprints = GetByCriteria(criterias, pagingOperation, orderOperation);
            foreach (Sprint sprint in sprints)
            {
                sprint.Storys = DAOStory.GetBySprint(sprint.Id);
            }
            return sprints;

        }

        public IList<Sprint> GetAllSprint()
        {
            return  GetAllActive();
        }

        public int SaveSprint(Sprint sprint)
        {
            return Save(sprint);
        }

        public Sprint GetSprint(int idSprint)
        {
            return GetById(idSprint);
        }
    }
}
