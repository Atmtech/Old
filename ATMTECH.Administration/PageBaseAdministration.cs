using ATMTECH.Entities;
using ATMTECH.Web.Controls.Affichage;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Administration
{
    public class PageBaseAdministration : PageBase
    {

        public void ShowMessage(Message message)
        {
            TitreLabelAvance titreLabelAvance = (TitreLabelAvance)Master.FindControl("lblMessage");
            titreLabelAvance.Text = message.Description;
        }

    }


}