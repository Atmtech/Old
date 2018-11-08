using System;

namespace ATMTECH.StockGame.Site
{
    public partial class Classement : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifierAcces();
            if (!Page.IsPostBack)
            {
                Rafraichir();
            }
        }

        private void Rafraichir()
        {
            repeaterClassement.DataSource = TitreService.ObtenirClassement();
            repeaterClassement.DataBind();
        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Rafraichir();
        }
    }
}