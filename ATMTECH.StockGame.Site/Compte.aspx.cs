using System;

namespace ATMTECH.StockGame.Site
{
    public partial class Compte : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifierAcces();
        }
    }
}