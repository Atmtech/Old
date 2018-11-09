using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATMTECH.Pass.WebSite
{
    public partial class Default1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblVersion.Text = Assembly.GetExecutingAssembly()
        .GetName()
        .Version
        .ToString();
        }
    }
}