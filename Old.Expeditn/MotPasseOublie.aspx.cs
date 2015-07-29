using System;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class MotPasseOublie : PageBase<MotPasseOubliePresenter, IMotPasseOubliePresenter>,
                                          IMotPasseOubliePresenter
    {
        public string Courriel { get { return txtCourriel.Text; } set { txtCourriel.Text = value; } }

        protected void btnEnvoyerCourrielClick(object sender, EventArgs e)
        {
            Presenter.EnvoyerMotPasseOublie();
        }
    }
}