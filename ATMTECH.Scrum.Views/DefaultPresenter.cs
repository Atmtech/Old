using ATMTECH.Scrum.Entities;
using ATMTECH.Scrum.Services.Interface;
using ATMTECH.Scrum.Views.Base;
using ATMTECH.Scrum.Views.Interface;

namespace ATMTECH.Scrum.Views
{
    public class DefaultPresenter : BaseScrumPresenter<IDefaultPresenter>
    {
        public IProductService ProductService { get; set; }
        public IStoryService StoryService { get; set; }
        public ISprintService SprintService { get; set; }

        public DefaultPresenter(IDefaultPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            LoadData();
        }

        public void LoadData()
        {

            
            View.Products = ProductService.GetAllProduct();
            View.Storys = StoryService.GetUnlinkedStory();
            View.Sprints = SprintService.GetAllSprint();
        }

        public void DeleteSprint(int idSprint)
        {
            Sprint sprint = SprintService.GetSprint(idSprint);
            sprint.IsActive = false;
            SprintService.SaveSprint(sprint);
            LoadData();
        }
    }
}
