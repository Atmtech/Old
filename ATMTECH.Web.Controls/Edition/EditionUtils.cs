using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Edition
{
    internal static class EditionUtils
    {
        internal static void CreerIndicateurErreur(Control ctrl, BaseValidator validateur)
        {
            Image imgErr = new Image();
            imgErr.ImageUrl = ctrl.Page.GetEncodedResourceUrl("Edition.indicateurErreur.png");
            imgErr.AlternateText = "X";
            imgErr.CssClass = "indicErreur";
            imgErr.ToolTip = validateur.ToolTip;
            validateur.Controls.Add(imgErr);
        }
    }
}