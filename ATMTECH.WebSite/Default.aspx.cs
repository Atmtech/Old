using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ATMTECH.WebSite
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IList<ListItem> test = new List<ListItem>();

            
            test.Add(new ListItem("xxx", "1"));
            test.Add(new ListItem("yyy", "2"));
            ddlTest.DataSource = test;
            ddlTest.DataBind();
        }
    }
}
