using ATMTECH.Scrum.DAO;
using ATMTECH.Scrum.DAO.Interface;
using ATMTECH.Scrum.Services.Interface;
using ATMTECH.Shell;

namespace ATMTECH.Scrum.Services.Base
{
    public class ScrumInitializer : BaseModuleInitializer
    {
        public override void InitDependency()
        {
            AddDependency<ISprintService, SprintService>();
            AddDependency<IStoryService, StoryService>();
            AddDependency<IProductService, ProductService>();
            AddDependency<ITaskService, TaskService>();
            AddDependency<IDAOProduct, DAOProduct>();
            AddDependency<IDAOStory, DAOStory>();
            AddDependency<IDAOSprint, DAOSprint>();
            AddDependency<IDAOTask, DAOTask>();
            AddDependency<ITaskService, TaskService>();
        }
    }
}
