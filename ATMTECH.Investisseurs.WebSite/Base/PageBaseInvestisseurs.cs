using System.Web.UI.WebControls;
using ATMTECH.Entities;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Investisseurs.WebSite.Base
{
    public class PageBaseInvestisseurs : PageBase
    {

        public void ShowMessage(Message message)
        {
            Panel pnlError = (Panel)Master.FindControl("pnlError");
            Label lblError = (Label)pnlError.FindControl("lblError");
            lblError.Text = message.Description;
            pnlError.Visible = true;
        }

    }


}