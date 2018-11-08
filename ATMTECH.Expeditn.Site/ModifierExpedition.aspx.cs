using System;

namespace ATMTECH.Expeditn.Site
{
    public partial class ModifierExpedition : PageBase
    {
        public Entites.Expedition Expedition => ExpeditionService.Obtenir(IdExpedition);

        protected void Page_Load(object sender, EventArgs e)
        {
            VerifierAcces();
            if (!Page.IsPostBack)
            {
                lblTest.Text = IdExpedition;
                activites.Affichage();
                
            }
        }

        protected void activites_OnSurAction(object sender, EventArgs e)
        {
            activites.Affichage();
            coutActivite.Affichage();
        }
    }
}