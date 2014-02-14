using System;
using ATMTECH.BillardLoretteville.Views;
using ATMTECH.BillardLoretteville.Views.Interface;
using ATMTECH.Entities;
using ATMTECH.Web.Controls.Base;
using System.Web.UI.WebControls;

namespace ATMTECH.BillardLoretteville.Website
{
    public partial class Tournois : PageBase, IBillardLorettevillePresenter
    {
        public BillardLorettevillePresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
                ContentDefault.PageName = "Tournoi";
            }
            Presenter.OnViewLoaded();

            

            ((Label)Master.FindControl("lblTitre")).Text = "Tournois";
        }

        public void ShowMessage(Message message)
        {
            throw new NotImplementedException();
        }
    }
}