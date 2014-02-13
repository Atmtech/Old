using System;
using ATMTECH.Scrum.Entities;
using ATMTECH.Scrum.Services.Interface;
using ATMTECH.Scrum.Views.Base;
using ATMTECH.Scrum.Views.Interface;

namespace ATMTECH.Scrum.Views
{
    public class ProductPresenter : BaseScrumPresenter<IProductPresenter>
    {
        public IProductService ProductService { get; set; }
        public ISprintService SprintService { get; set; }
        public IStoryService StoryService { get; set; }
        public ITaskService TaskService { get; set; }
        public ProductPresenter(IProductPresenter view)
            : base(view)
        {
        }

        public void LoadData()
        {
            View.ProductView = ProductService.GetProduct(Convert.ToInt32(NavigationService.GetQueryStringValue("Id")));
        }
        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            LoadData();
        }

        public void DeleteSprint(int idSprint)
        {
            Sprint sprint = SprintService.GetSprint(idSprint);
            sprint.IsActive = false;
            SprintService.SaveSprint(sprint);
            LoadData();
        }

        public void DeleteStory(int idStory)
        {
            Story story = StoryService.GetStory(idStory);
            story.IsActive = false;
            StoryService.SaveStory(story);
            LoadData();
        }

        public void DeleteTask(int idTask)
        {
            Task task = TaskService.GetTask(idTask);
            task.IsActive = false;
            TaskService.SaveTask(task);
            LoadData();
        }
    }
}
