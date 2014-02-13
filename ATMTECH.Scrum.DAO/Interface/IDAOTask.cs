using System.Collections.Generic;
using ATMTECH.Scrum.Entities;

namespace ATMTECH.Scrum.DAO.Interface
{
    public interface IDAOTask
    {
        IList<Task> GetTaskByStory(int idStory);
        Task GetTask(int idTask);
        int SaveTask(Task task);
    }
}
