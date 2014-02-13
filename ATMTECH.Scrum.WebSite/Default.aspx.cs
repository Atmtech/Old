using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Scrum.Entities;
using ATMTECH.Scrum.Views;
using ATMTECH.Scrum.Views.Interface;
using ATMTECH.Scrum.Views.Pages;

namespace ATMTECH.Scrum.WebSite
{
    public partial class Default1 : PageBaseScrum, IDefaultPresenter
    {
        public DefaultPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        public IList<Sprint> Sprints
        {
            set
            {
                //repeaterSprint.DataSource = value;
                //repeaterSprint.DataBind();
            }
        }
        public IList<Product> Products
        {
            set
            {
                repeaterProduct.DataSource = value;
                repeaterProduct.DataBind();
            }
        }

        public IList<Story> Storys
        {
            set
            {
                //repeaterStory.DataSource = value;
                //repeaterStory.DataBind();
            }
        }

        protected void repeaterProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Product product = (Product)e.Item.DataItem;
                ((HyperLink)e.Item.FindControl("lnkProduct")).Text = product.Description;
                ((HyperLink)e.Item.FindControl("lnkProduct")).NavigateUrl = Pages.PRODUCT + "?ID=" + product.Id;
                ((Label)e.Item.FindControl("lblDateCreated")).Text = product.DateCreated.ToString();
                ((Label)e.Item.FindControl("lblProductOwner")).Text = product.ProductOwner.FirstNameLastName;
                ((Label)e.Item.FindControl("lblTotalPoint")).Text = product.TotalPoint.ToString();
                ((Label)e.Item.FindControl("lblHeureRestante")).Text = product.TotalHourRemaining.ToString();
            }
        }

        protected void repeaterStory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Story story = (Story)e.Item.DataItem;
                ((Label)e.Item.FindControl("lblDescription")).Text = story.Description;
                ((Label)e.Item.FindControl("lblPoint")).Text = story.Point.ToString();
                ((Label)e.Item.FindControl("lblSprint")).Text = story.Sprint.Description;
            }
        }

        protected void repeaterSprint_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Sprint sprint = (Sprint)e.Item.DataItem;
                ((Label)e.Item.FindControl("lblDescription")).Text = sprint.Description;
                ((Label)e.Item.FindControl("lblStart")).Text = sprint.Start.ToShortDateString();
                ((Label)e.Item.FindControl("lblEnd")).Text = sprint.End.ToShortDateString();
                ((ImageButton)e.Item.FindControl("btnEdit")).CommandArgument = sprint.Id.ToString();
                ((ImageButton)e.Item.FindControl("btnDelete")).CommandArgument = sprint.Id.ToString();
            }
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

        protected void AddProduct(object sender, ImageClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void AddSprint(object sender, ImageClickEventArgs e)
        {
            sprintEdit.IdSprint = 0;
            windowAddSprint.OuvrirFenetre();
        }

        protected void AddStory(object sender, ImageClickEventArgs e)
        {
            storyAdd.IdStory = 0;
            windowAddStory.OuvrirFenetre();
        }

        protected void CloseWindow(object sender, EventArgs e)
        {
            Presenter.LoadData();
            windowAddSprint.FermerFenetre();
            windowEditSprint.FermerFenetre();
            windowAddStory.FermerFenetre();
            windowEditStory.FermerFenetre();
        }

      
    }
}