using System;
using System.Collections.Generic;
using ATMTECH.Common.Context;
using ATMTECH.Entities;
using ATMTECH.Scrum.Entities;
using ATMTECH.Scrum.Views;
using ATMTECH.Scrum.Views.Interface;

namespace ATMTECH.Scrum.WebSite.UserControls
{
    public partial class SprintPage : UserControlScrumBase, ISprintPresenter
    {
        public SprintPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }
        
        public Sprint Sprint
        {
            set
            {
                txtDescription.Text = value.Description;
                txtDateStart.Text = value.Start.ToString();
                txtDateEnd.Text = value.End.ToString();
                cboProduct.SelectedValue = value.Product.Id.ToString();
            }
        }
        public int IdSprint
        {
            get { return (int)ContextSessionManager.Session["Sprint"]; }
            set
            {
                ContextSessionManager.Session["Sprint"] = value;
                Presenter.LoadData();
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
        public int IdProduct
        {
            get { return Convert.ToInt32(cboProduct.SelectedValue); }
        }
        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }
        public string DateEnd
        {
            get { return txtDateEnd.Text; }
            set { txtDateEnd.Text = value; }
        }
        public string DateStart
        {
            get { return txtDateStart.Text; }
            set { txtDateStart.Text = value; }
        }
        public event EventHandler Save;
        public void OnSave(EventArgs e)
        {
            EventHandler handler = Save;
            if (handler != null) handler(this, e);
        }
        protected void SaveSprint(object sender, EventArgs e)
        {
            Presenter.SaveSprint();
            OnSave(new EventArgs());
        }


    }
}