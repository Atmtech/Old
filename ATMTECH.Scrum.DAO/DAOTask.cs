using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Scrum.DAO.Interface;
using ATMTECH.Scrum.Entities;

namespace ATMTECH.Scrum.DAO
{
    public class DAOTask : BaseDao<Task, int>, IDAOTask
    {
        public IDAOUser DAOUser { get; set; }
        //public IDAOStory DAOStory { get; set; }
        public IList<Task> GetTaskByStory(int idStory)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteria1 = new Criteria() { Column = Task.STORY, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idStory.ToString() };
            Criteria criteria2 = new Criteria() { Column = BaseEntity.IS_ACTIVE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = "1" };
            criterias.Add(criteria1);
            criterias.Add(criteria2);

            IList<Task> tasks = GetByCriteria(criterias);
            foreach (Task task in tasks)
            {
                task.User = DAOUser.GetUser(task.User.Id);
            }
            return tasks;
        }

        public Task GetTask(int idTask)
        {
            Task task =  GetById(idTask);
           

            return task;
        }

        public int SaveTask(Task task)
        {
            return Save(task);
        }
    }
}
