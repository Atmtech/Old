using System.Web.UI.WebControls;
using ATMTECH.Entities;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.FishingAtWork.WebSite.Base
{
    public class PageBaseFishingAtWork : PageBase
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