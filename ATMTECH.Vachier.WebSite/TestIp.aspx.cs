using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATMTECH.Vachier.WebSite
{
    public partial class TestIp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTestOnClick(object sender, EventArgs e)
        {
            new DAOLogger().ObtenirInformationLocalisation(txtIp.Text);
        }
    }
}