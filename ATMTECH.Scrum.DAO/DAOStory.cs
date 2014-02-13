using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.Scrum.DAO.Interface;
using ATMTECH.Scrum.Entities;

namespace ATMTECH.Scrum.DAO
{
    public class DAOStory : BaseDao<Story, int>, IDAOStory
    {
        public IDAOTask DaoTask { get; set; }
        //public IDAOSprint DaoSprint { get; set; }

        public IList<Story> GetByProduct(int idProduct)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteria1 = new Criteria() { Column = Story.PRODUCT, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idProduct.ToString() };
            Criteria criteria2 = new Criteria() { Column = BaseEntity.IS_ACTIVE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = "1" };
            criterias.Add(criteria1);
            criterias.Add(criteria2);

            PagingOperation pagingOperation = new PagingOperation() { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };
            OrderOperation orderOperation = new OrderOperation() { OrderByColumn = Story.SPRINT, OrderByType = OrderBy.Type.Ascending };

            IList<Story> stories = GetByCriteria(criterias, pagingOperation, orderOperation);
            foreach (Story storey in stories)
            {
                storey.Tasks = DaoTask.GetTaskByStory(storey.Id);
                //storey.Sprint = DaoSprint.GetSprint(storey.Sprint.Id);

                if (storey.Status != "DONE")
                {
                    storey.TotalHourRemaining = (from s in storey.Tasks
                                                 select s.EstimateTime).Sum();
                }
                else
                {
                    storey.TotalHourRemaining = 0;
                }
            }


            return stories;
        }

        public IList<Story> GetBySprint(int idSprint)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteria1 = new Criteria() { Column = Story.SPRINT, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idSprint.ToString() };
            Criteria criteria2 = new Criteria() { Column = BaseEntity.IS_ACTIVE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = "1" };
            criterias.Add(criteria1);
            criterias.Add(criteria2);
            return GetByCriteria(criterias);
        }

        public int SaveStory(Story story)
        {
            return Save(story);
        }
        public Story GetStory(int idStory)
        {
            return GetById(idStory);
        }


        public IList<Story> GetUnlinkedStory()
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteria1 = new Criteria() { Column = Story.PRODUCT, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = "0" };
            Criteria criteria2 = new Criteria() { Column = BaseEntity.IS_ACTIVE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = "1" };
            criterias.Add(criteria1);
            criterias.Add(criteria2);
            IList<Story> unlink = GetByCriteria(criterias);
            return unlink;
        }
    }
}
