using System;
using ATMTECH.Scrum.Entities;
using ATMTECH.Scrum.Services.Interface;
using ATMTECH.Scrum.Views.Base;
using ATMTECH.Scrum.Views.Interface;

namespace ATMTECH.Scrum.Views
{
    public class SprintPresenter : BaseScrumPresenter<ISprintPresenter>
    {
        public ISprintService SprintService { get; set; }
        public IProductService ProductService { get; set; }

        public SprintPresenter(ISprintPresenter view)
            : base(view)
        {
        }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            View.Products = ProductService.GetAllProduct();
        }


        public void LoadData()
        {
            if (View.IdSprint != 0)
            {
                View.Sprint = SprintService.GetSprint(View.IdSprint);
            }
        }

        public void SaveSprint()
        {
            Sprint sprint = SprintService.GetSprint(View.IdSprint);
            if (sprint == null)
            {
                sprint = new Sprint();
            }
            sprint.Description = View.Description;
            sprint.Product = new Product() {Id = View.IdProduct};
            sprint.End = Convert.ToDateTime(View.DateEnd);
            sprint.Start = Convert.ToDateTime(View.DateStart);
            SprintService.SaveSprint(sprint);
        }
    }
}
