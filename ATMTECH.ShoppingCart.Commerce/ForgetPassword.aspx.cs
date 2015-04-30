using System;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class ForgetPassword : PageBase<MotPasseOubliePresenter, IMotPasseOubliePresenter>,
                                          IMotPasseOubliePresenter
    {
        public string Courriel { get { return txtCourriel.Text; } set { txtCourriel.Text = value; } }

        protected void btnEnvoyerCourrielClick(object sender, EventArgs e)
        {
           Presenter.EnvoyerMotPasseOublie();
        }
    }
}