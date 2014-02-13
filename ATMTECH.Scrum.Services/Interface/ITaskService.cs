using System.Collections.Generic;
using ATMTECH.Scrum.Entities;

namespace ATMTECH.Scrum.Services.Interface
{
    public interface ITaskService
    {
        IList<Task> GetAllTaskByStory(int idStory);
        Task GetTask(int idTask);
        int SaveTask(Task task);
    }
}
