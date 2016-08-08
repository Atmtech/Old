using System;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class Action : PageBase<ActionPresenter, IActionPresenter>, IActionPresenter
    {
 
        protected void lnkAjouterUneExpeditionClick(object sender, EventArgs e)
        {
            Presenter.NouvelleExpedition();
        }

        protected void lnkModifierUneExpeditionClick(object sender, EventArgs e)
        {
            Presenter.ModifierExpedition();
        }


    }
}