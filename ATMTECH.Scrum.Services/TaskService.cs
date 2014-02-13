using System.Collections.Generic;
using ATMTECH.Scrum.DAO.Interface;
using ATMTECH.Scrum.Entities;
using ATMTECH.Scrum.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.Scrum.Services
{
    public class TaskService : BaseService, ITaskService
    {
        public IDAOTask DaoTask { get; set; }
        //public IDAOStory DaoStory { get; set; }

        public IList<Task> GetAllTaskByStory(int idStory)
        {
            return DaoTask.GetTaskByStory(idStory);
        }

        public Task GetTask(int idTask)
        {
            Task task = DaoTask.GetTask(idTask);
//            task.Story = DaoStory.GetStory(task.Story.Id);
            return task;
        }

        public int SaveTask(Task task)
        {
            return DaoTask.SaveTask(task);
        }
    }
}
