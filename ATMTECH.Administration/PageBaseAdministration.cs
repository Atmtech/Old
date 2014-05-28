using System.Web.UI.WebControls;
using ATMTECH.Entities;
using ATMTECH.Web.Controls.Affichage;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Administration
{
    public class PageBaseAdministration : PageBase
    {

        public void ShowMessage(Message message)
        {
            if (Message.MESSAGE_TYPE_SUCCESS == message.MessageType)
            {
                Panel panel = (Panel)Master.FindControl("pnlSuccess");
                Label literal = (Label)Master.FindControl("lblSuccess");
                literal.Text = string.Format("{0} - {1}", message.InnerId, message.Description);
                panel.Visible = true;
            }
            else
            {
                Panel panel = (Panel)Master.FindControl("pnlError");
                Label literal = (Label)Master.FindControl("lblError");
                literal.Text = string.Format("{0} - {1}", message.InnerId, message.Description);
                panel.Visible = true;
            }
        }

    }


}