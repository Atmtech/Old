using System;
using ATMTECH.Common.Context;
using ATMTECH.Scrum.Entities;
using ATMTECH.Scrum.Views;
using ATMTECH.Scrum.Views.Interface;

namespace ATMTECH.Scrum.WebSite.UserControls
{
    public partial class TaskPage : UserControlScrumBase, ITaskPresenter
    {
        public TaskPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        public Task Task
        {
            set
            {
                txtDescription.Text = value.Description;
                txtStory.Text = value.Story.Id.ToString();
                txtStoryDescription.Text = value.Story.Description;
                txtEstimatedPoint.Text = value.EstimateTime.ToString();
            }
        }

        public int IdTask
        {
            get { return (int)ContextSessionManager.Session["Task"]; }
            set
            {
                ContextSessionManager.Session["Task"] = value;
                Presenter.LoadData();
            }
        }

        public int IdStory
        {
            get { return Convert.ToInt32(txtStory.Text); }
            set
            {
                txtStory.Text = value.ToString();
                Presenter.LoadStoryDescription();
            }
        }

        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        public string EstimatedTime
        {
            get { return txtEstimatedPoint.Text; }
            set { txtEstimatedPoint.Text = value; }
        }

        public string StoryDescription
        {
            get { return txtStoryDescription.Text; }
            set { txtStoryDescription.Text = value; }
        }

        public event EventHandler Save;
        public void OnSave(EventArgs e)
        {
            EventHandler handler = Save;
            if (handler != null) handler(this, e);
        }


        protected void SaveTask(object sender, EventArgs e)
        {
            Presenter.SaveTask();
            OnSave(new EventArgs());
        }
    }
}