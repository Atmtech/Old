using System;
using ATMTECH.BillardLoretteville.Views;
using ATMTECH.BillardLoretteville.Views.Interface;
using ATMTECH.Web.Controls.Base;
using System.Web.UI.WebControls;

namespace ATMTECH.BillardLoretteville.Website
{
    public partial class Default1 : PageBase, IBillardLorettevillePresenter
    {
        public BillardLorettevillePresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ContentDefault.PageName = "Default";
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();

            

            ((Label) Master.FindControl("lblTitre")).Text = "Bienvenue";

        }
    }
}