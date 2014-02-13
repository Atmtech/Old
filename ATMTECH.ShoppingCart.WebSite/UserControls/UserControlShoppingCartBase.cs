using ATMTECH.Entities;
using ATMTECH.Web.Controls.Affichage;
using WebFormsMvp.Web;

namespace ATMTECH.ShoppingCart.WebSite.UserControls
{
    public class UserControlShoppingCartBase : MvpUserControl
    {
        public void ShowMessage(Message message)
        {
            Default masterPage = (Default)Page.Master;
            if (masterPage != null)
            {
                FenetreDialogue window = (FenetreDialogue)masterPage.FindControl("windowMessage");
                TitreLabelAvance titreLabelAvance = (TitreLabelAvance)window.FindControl("lblMessage");

                window.Titre = message.Title;
                titreLabelAvance.Text = message.Description;
                window.OuvrirFenetre();
            }
        }
    }
}