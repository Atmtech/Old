using System;
using ATMTECH.Scrum.Entities;
using ATMTECH.Scrum.Services.Interface;
using ATMTECH.Scrum.Views.Base;
using ATMTECH.Scrum.Views.Interface;

namespace ATMTECH.Scrum.Views
{
    public class StoryPresenter : BaseScrumPresenter<IStoryPresenter>
    {
        public IStoryService StoryService { get; set; }
        public IProductService ProductService { get; set; }

        public StoryPresenter(IStoryPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.Products = ProductService.GetAllProduct();
            View.Status = StoryService.GetListStatus();
            View.Points = StoryService.GetListPoints();
        }

        public void LoadData()
        {
            if (View.IdStory != 0)
            {
                View.Story = StoryService.GetStory(View.IdStory);
            }
        }

        public void SaveStory()
        {
            Story story = StoryService.GetStory(View.IdStory);
            if (story == null)
            {
                story = new Story();
            }

            story.Description = View.Description;
            story.Point = View.IdPoints;
            story.Product = new Product() { Id = View.IdProduct };
            story.Status = View.IdStatus;

           
            story.Priority = View.Priority;


            if (View.IdSprint != 0)
            {
                story.Sprint.Id = View.IdSprint;
            }

            if (!string.IsNullOrEmpty(View.Batch))
            {
                string[] lines = View.Batch.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                foreach (string line in lines)
                {
                    Story storyBatch = story;
                    storyBatch.Description = line;
                    storyBatch.Priority = 999999;
                    storyBatch.Status = "Undone";
                    StoryService.SaveStory(storyBatch);
                }
            }
            else
            {
                StoryService.SaveStory(story);
            }


        }
    }
}
