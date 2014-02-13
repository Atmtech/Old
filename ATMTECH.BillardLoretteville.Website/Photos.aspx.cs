using System;
using ATMTECH.BillardLoretteville.Views;
using ATMTECH.BillardLoretteville.Views.Interface;
using ATMTECH.Web.Controls.Base;
using System.Web.UI.WebControls;

namespace ATMTECH.BillardLoretteville.Website
{
    public partial class Photos : PageBase, IBillardLorettevillePresenter
    {
        public BillardLorettevillePresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
                ContentDefault.PageName = "Photo";
            }
            Presenter.OnViewLoaded();

            ((Label)Master.FindControl("lblTitre")).Text = "Photos";
        }
    }
}