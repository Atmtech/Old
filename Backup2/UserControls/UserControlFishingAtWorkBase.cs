using System.Web.UI.WebControls;
using ATMTECH.Entities;
using WebFormsMvp.Web;

namespace ATMTECH.FishingAtWork.WebSite.UserControls
{
    public class UserControlFishingAtWorkBase : MvpUserControl
    {
        public void ShowMessage(Message message)
        {
            Default masterPage = (Default)Page.Master;
            if (masterPage != null)
            {
                Panel pnlError = (Panel)masterPage.FindControl("pnlError");
                Label lblError = (Label)pnlError.FindControl("lblError");
                lblError.Text = message.Description;
                pnlError.Visible = true;
            }
        }


    }
}