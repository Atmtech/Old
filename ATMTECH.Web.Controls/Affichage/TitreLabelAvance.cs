using System;
using System.Web.UI.WebControls;

namespace ATMTECH.Web.Controls.Affichage
{
    /// <summary>
    /// Contrôle à utiliser pour afficher un libellé
    /// de "titre" au lieu du asp:Label standard.
    /// </summary>
    public class TitreLabelAvance : Label
    {
        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.PreRender"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (String.IsNullOrEmpty(CssClass))
            {
                CssClass = "titreLabelAvance";
            }
        }
    }
}