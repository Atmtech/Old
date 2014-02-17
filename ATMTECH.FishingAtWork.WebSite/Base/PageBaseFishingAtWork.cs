using System.Web.UI;
using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.WebSite.Base
{
    public class PageBaseFishingAtWork : Page
    {

        public void ShowMessage(Message message)
        {
            //Panel pnlError = (Panel)Master.FindControl("pnlError");
            //Label lblError = (Label)pnlError.FindControl("lblError");
            //lblError.Text = message.Description;
            //pnlError.Visible = true;
        }

    }


}