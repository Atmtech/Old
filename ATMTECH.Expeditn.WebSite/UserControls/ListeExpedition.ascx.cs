using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Views;

namespace ATMTECH.Expeditn.WebSite.UserControls
{
    public partial class ListeExpedition : UserControl
    {
        public IList<Expedition> Expeditions
        {
            set
            {
                dataListExpedition.DataSource = value;
                dataListExpedition.DataBind();
            }
        }

        protected void dataListExpeditionItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Voir")
            {
                Response.Redirect(Pages.EXPEDITION + "?" + PagesId.EXPEDITION + "=" + e.CommandArgument);
            }
        }

    }
}