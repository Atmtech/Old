using System;

namespace ATMTECH.Expeditn.Site
{
    public partial class AjouterExpedition : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                VerifierAcces();
            }
        }

    }
}