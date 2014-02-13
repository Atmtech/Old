using System;
using System.Collections.Generic;
using ATMTECH.Common.Context;
using ATMTECH.Entities;
using ATMTECH.Scrum.Entities;
using ATMTECH.Scrum.Views;
using ATMTECH.Scrum.Views.Interface;

namespace ATMTECH.Scrum.WebSite.UserControls
{
    public partial class StoryPage : UserControlScrumBase, IStoryPresenter
    {
        public StoryPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }
        public Story Story
        {
            set
            {
                txtDescription.Text = value.Description;
                cboPoint.SelectedValue = value.Point.ToString();
                cboProduct.SelectedValue = value.Product.Id.ToString();
                txtPriority.Text = value.Priority.ToString();
            }
        }
        public IList<int> Points
        {
            set
            {
                cboPoint.DataSource = value;
                cboPoint.DataBind();
            }
        }
        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }
        public string IdStatus
        {
            get { return cboStatus.SelectedValue; }
        }
        public int IdPoints
        {
            get { return Convert.ToInt32(cboPoint.SelectedValue); }
        }
        public int IdProduct
        {
            get { return Convert.ToInt32(cboProduct.SelectedValue); }
        }
        public int IdSprint
        {
            get
            {
                if (!string.IsNullOrEmpty(cboSprint.SelectedValue))
                {
                    return Convert.ToInt32(cboSprint.SelectedValue);
                }
                return 0;
            }
        }

        public string Batch
        {
            get { return txtBatch.Text; }
            set { txtBatch.Text = value; }
        }

        public int? Priority
        {
            get
            {
                if (String.IsNullOrEmpty(txtPriority.Text))
                {
                    return 999999;
                }
                return Convert.ToInt32(txtPriority.Text);
            }
            set { txtPriority.Text = value.ToString(); }
        }

        public Dictionary<string, string> Status
        {
            set
            {
                cboStatus.DataSource = value;

                cboStatus.DataBind();
            }
        }
        public IList<Product> Products
        {
            set
            {
                cboProduct.DataValueField = BaseEntity.ID;
                cboProduct.DataTextField = BaseEntity.DESCRIPTION;
                cboProduct.DataSource = value;
                cboProduct.DataBind();
            }
        }
        public int IdStory
        {
            get { return (int)ContextSessionManager.Session["Story"]; }
            set
            {
                ContextSessionManager.Session["Story"] = value;
                Presenter.LoadData();
            }
        }
        public event EventHandler Save;
        public void OnSave(EventArgs e)
        {
            EventHandler handler = Save;
            if (handler != null) handler(this, e);
        }
        protected void SaveStory(object sender, EventArgs e)
        {
            Presenter.SaveStory();
            OnSave(new EventArgs());
        }
    }
}