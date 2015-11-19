using System;
using System.Web.UI;
using ATMTECH.Web.Services;

namespace Morpheus
{
    public partial class contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnContactClick(object sender, EventArgs e)
        {
            new MailService().SendEmailWithFrameWork("info@morpheusRenovation.com", Courriel.Text,
                "Une question du site web", string.Format("Nom: {0}<br>Téléphone: {1}<br> Message:{2}", Nom.Text, Telephone.Text, Message.Text));
            Courriel.Text = "";
            Nom.Text = "";
            Telephone.Text = "";
            Message.Text = "";
            pnlMerci.Visible = true;
        }
    }
}