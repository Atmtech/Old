using System;
using System.Web.UI.WebControls;
using ATMTECH.Common;
using ATMTECH.FishingAtWork.Views;
using ATMTECH.FishingAtWork.Views.Interface;
using ATMTECH.FishingAtWork.WebSite.Base;

namespace ATMTECH.FishingAtWork.WebSite
{
    public partial class AdminLure : PageBaseFishingAtWork, IAdminLurePresenter
    {
        public AdminLurePresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();

        }


        protected void RowCommandClick(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "OpenLure")
            {
                Presenter.OpenLure(Convert.ToInt32(e.CommandArgument));
            }
        }

        protected void AddClick(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPrice.ValeurDecimale = 0;
        }

        public int Id
        {
            get { return Convert.ToInt32(txtId.Text); }
            set { txtId.Text = value.ToString(); }
        }

        public string Name
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        public double Price
        {
            get { return Convert.ToDouble(txtPrice.ValeurDecimale); }
            set { txtPrice.ValeurMonnaie = value; }
        }

        public bool IsInEditMode
        {
            set { pnlEdit.Visible = value; }
        }

        protected void SaveClick(object sender, EventArgs e)
        {
            Presenter.Save();
        }
    }
}