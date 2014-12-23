using System;
using System.Collections.Generic;
using ATMTECH.Administration.Views;
using ATMTECH.Administration.Views.Interface;
using ATMTECH.DAO;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Web.Services;

namespace ATMTECH.Administration
{
   
        public partial class test : PageBaseAdministration, IDefaultPresenter
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
            protected void testClick(object sender, EventArgs e)
            {
                Response.Write("GRRR");
                Response.Write(Presenter.Test());
            }

            protected void test2Click(object sender, EventArgs e)
            {
                BaseDao<Product, int> test = new BaseDao<Product, int>();
                IList<Product> users = test.GetAll();
                Response.Write(users.Count);
            }

            public new void ShowMessage(Message message)
            {
                Response.Write(message.Description);
            }

        }
   
}