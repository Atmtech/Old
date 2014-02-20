using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATMTECH.Atorp.WebSite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTestClick(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000000000; i++)
            {

            }
            lblCrevette.Text = "Crevette Tigré";
        }
    }
}