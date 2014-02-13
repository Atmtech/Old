using System;
using ATMTECH.Scrum.Entities;
using ATMTECH.Scrum.Services.Interface;
using ATMTECH.Scrum.Views.Base;
using ATMTECH.Scrum.Views.Interface;

namespace ATMTECH.Scrum.Views
{
    public class TaskPresenter : BaseScrumPresenter<ITaskPresenter>
    {
        public ITaskService TaskService { get; set; }
        public IStoryService StoryService { get; set; }

        public TaskPresenter(ITaskPresenter view)
            : base(view)
        {
        }

        public void LoadData()
        {
            if (View.IdTask != 0)
            {
                View.Task = TaskService.GetTask(View.IdTask);
            }

          
        }

        public void LoadStoryDescription()
        {
            View.StoryDescription = StoryService.GetStory(View.IdStory).Description;
        }

        public int SaveTask()
        {
            Task task = TaskService.GetTask(View.IdTask);
            if (task == null)
            {
                task = new Task { Story = new Story() { Id = View.IdStory } };

            }

            task.Description = View.Description;
            task.EstimateTime = Convert.ToDecimal(View.EstimatedTime);
            return TaskService.SaveTask(task);
        }
    }
}
