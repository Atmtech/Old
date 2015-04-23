using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATMTECH.Administration.Commerce
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSkinOnclick(object sender, EventArgs e)
        {
            txtTest.Text = "2010-09-18";
        }
    }
}