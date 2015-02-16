using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO;


namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

               DAOCountry test = new DAOCountry(); 

                
                ddlTest.DataSource = test.GetAllCountries();
                ddlTest.DataTextField = BaseEntity.DESCRIPTION;
                ddlTest.DataValueField = BaseEntity.ID;
                ddlTest.DataBind();
            }
        }
    }
}