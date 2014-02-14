using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Scrum.Entities;
using ATMTECH.Scrum.Views;
using ATMTECH.Scrum.Views.Interface;

namespace ATMTECH.Scrum.WebSite
{
    public partial class ProductPage : PageBaseScrum, IProductPresenter
    {
        public ProductPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }


        public Product ProductView
        {
            set
            {
                lblProduct.Text = value.Description;
                repeaterStory.DataSource = value.Storys.OrderByDescending(x => x.Status);
                repeaterStory.DataBind();

                lblTotalPoint.Text = value.TotalPoint.ToString();
                lblTotalHour.Text = value.TotalHourRemaining.ToString();

                repeaterSprint.DataSource = value.Sprints;
                repeaterSprint.DataBind();
            }
        }



        protected void repeaterStory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Story dataItem = (Story)e.Item.DataItem;
                ((Label)e.Item.FindControl("lblDescription")).Text = dataItem.Description;
                ((Label)e.Item.FindControl("lblPoint")).Text = dataItem.Point.ToString();
                ((Label)e.Item.FindControl("lblSprint")).Text = dataItem.Sprint.Description;
                ((Label)e.Item.FindControl("lblStatus")).Text = dataItem.Status;
                ((ImageButton)e.Item.FindControl("btnEdit")).CommandArgument = dataItem.Id.ToString();
                ((ImageButton)e.Item.FindControl("btnDelete")).CommandArgument = dataItem.Id.ToString();
                ((ImageButton)e.Item.FindControl("btnTask")).CommandArgument = dataItem.Id.ToString();

                if (dataItem.Tasks.Count > 0)
                {
                    e.Item.FindControl("pnlTask").Visible = true;
                    ((Repeater)e.Item.FindControl("repeaterTask")).DataSource = dataItem.Tasks;
                    e.Item.FindControl("repeaterTask").DataBind();
                }
            }
        }

        protected void EditStory(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                storyEdit.IdStory = Convert.ToInt32(e.CommandArgument);
                windowEditStory.OuvrirFenetre();
            }
            if (e.CommandName == "Task")
            {
                taskAdd.IdTask = 0;
                taskAdd.IdStory = Convert.ToInt32(e.CommandArgument);
                windowAddTask.OuvrirFenetre();
            }

            if (e.CommandName == "Delete")
            {
                Presenter.DeleteStory(Convert.ToInt32(e.CommandArgument));
            }
        }

        protected void AddStory(object sender, ImageClickEventArgs e)
        {
            storyEdit.IdStory = 0;
            windowAddStory.OuvrirFenetre();
        }

        protected void AddSprint(object sender, ImageClickEventArgs e)
        {
            sprintEdit.IdSprint = 0;
            windowEditSprint.OuvrirFenetre();
        }

        protected void EditSprint(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                sprintEdit.IdSprint = Convert.ToInt32(e.CommandArgument);
                windowEditSprint.OuvrirFenetre();
            }
            if (e.CommandName == "Delete")
            {
                Presenter.DeleteSprint(Convert.ToInt32(e.CommandArgument));
            }
        }

        protected void repeaterSprint_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Sprint sprint = (Sprint)e.Item.DataItem;
                ((Label)e.Item.FindControl("lblTotalHour")).Text = sprint.TotalHourRemaining.ToString();
                ((Label)e.Item.FindControl("lblDescription")).Text = sprint.Description;
                ((Label)e.Item.FindControl("lblStart")).Text = sprint.Start.ToShortDateString();
                ((Label)e.Item.FindControl("lblEnd")).Text = sprint.End.ToShortDateString();
                ((ImageButton)e.Item.FindControl("btnEdit")).CommandArgument = sprint.Id.ToString();
                ((ImageButton)e.Item.FindControl("btnDelete")).CommandArgument = sprint.Id.ToString();
            }
        }


        protected void CloseWindow(object sender, EventArgs e)
        {
            Presenter.LoadData();
            windowAddSprint.FermerFenetre();
            windowEditSprint.FermerFenetre();
            windowEditStory.FermerFenetre();
            windowAddStory.FermerFenetre();
            windowAddTask.FermerFenetre();
            windowEditTask.FermerFenetre();
        }

        protected void EditTask(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                taskEdit.IdTask = Convert.ToInt32(e.CommandArgument);
                windowEditTask.OuvrirFenetre();
            }
            if (e.CommandName == "Delete")
            {
                Presenter.DeleteTask(Convert.ToInt32(e.CommandArgument));
            }
        }

        protected void repeaterTask_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Task task = (Task)e.Item.DataItem;
                ((Label)e.Item.FindControl("lblTaskDescription")).Text = task.Description;
                ((Label)e.Item.FindControl("lblEstimateHour")).Text = task.EstimateTime.ToString();
                ((Label)e.Item.FindControl("lblTimeDoneHour")).Text = task.TimeDone.ToString();
                ((ImageButton)e.Item.FindControl("btnEdit")).CommandArgument = task.Id.ToString();
                ((ImageButton)e.Item.FindControl("btnDelete")).CommandArgument = task.Id.ToString();
            }
        }
    }
}