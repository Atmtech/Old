using System;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Views;

namespace ATMTECH.Expeditn.WebSite.UserControls
{
    public partial class UtilisateurControl : System.Web.UI.UserControl
    {
        public bool EstUtilisateurAuthentifie
        {
            set
            {
                btnAfficherMesExpeditions.Visible = value;
            }
        }
        public User Utilisateur
        {
            set
            {
                lblIdUtilisateur.Text = value.Id.ToString();
                lblNomPrenomUtilisateur.Text = value.FirstNameLastName;
                lblCourrielUtilisateur.Text = value.Login;
            }
        }

        protected void btnAfficherMesExpeditionsClick(object sender, EventArgs e)
        {
            Response.Redirect(Pages.DEFAULT + "?" + PagesId.UTILISATEUR + "=" + lblIdUtilisateur.Text);
        }
    }
}