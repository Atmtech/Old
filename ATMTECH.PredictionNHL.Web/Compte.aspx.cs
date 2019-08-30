using ATMTECH.PredictionNHL.Web;
using System;

namespace ATMTECH.Expeditn.Site
{
    public partial class Compte : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifierAcces();
        }
    }
}