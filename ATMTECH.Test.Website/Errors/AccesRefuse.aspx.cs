using System;
using System.Web;

namespace ATMTECH.Errors
{
    public partial class AccesRefuse : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lblRaisonAccesRefuse.Text = HttpUtility.HtmlDecode(Request.QueryString["msgid"]).Replace(Environment.NewLine, "<br />");

            
        }
    }
}
