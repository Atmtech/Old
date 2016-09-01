using System;
using ATMTECH.Expeditn.Views;
using ATMTECH.Expeditn.Views.Interface;

namespace ATMTECH.Expeditn.WebSite
{
    public partial class GererRechercheForfaitExpedi : PageBase<GererRechercheForfaitExpediPresenter, IGererRechercheForfaitExpediPresenter>, IGererRechercheForfaitExpediPresenter
    {
        protected void lnkEnregistrerRechercheForfaitExpediaClick(object sender, EventArgs e)
        {
            Presenter.Enregistrer();
        }

        public string Nom
        {
            get { return txtDescriptifDestination.Text; }
            set
            {
                txtDescriptifDestination.Text = value;
            }
        }
        public string Url { get { return txtUrl.Text; } set { txtUrl.Text = value; } }
        public string Date { get { return txtDate.Text;  } set { txtDate.Text = value; } }
    }


}