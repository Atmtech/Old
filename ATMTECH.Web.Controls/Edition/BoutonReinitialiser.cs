using System;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Bouton approuver.
    /// </summary>
    public class BoutonReinitialiser : BoutonBase
    {
        /// <summary>
        /// CommandName de ce bouton
        /// </summary>
        public const string NOM_COMMANDE = "Reinitialiser";

        /// <summary>
        /// Pointeur de l'événement annuler
        /// </summary>
        public event EventHandler Reinitialiser;

        /// <summary>
        /// Définit le comportement pour le click du bouton.
        /// </summary>
        /// <param name="sender">La source de l'évènement.</param>
        /// <param name="e">L'instance de <see cref="System.EventArgs"/> contenant les données de l'évènement.</param>
        protected override void Button_Click(object sender, EventArgs e)
        {
            base.Button_Click(sender, e);
            if (Reinitialiser != null)
            {
                Reinitialiser(this, e);
            }
        }

        /// <summary>
        /// Méthode qui initialise le contrôle de bouton.
        /// </summary>
        protected override void InitialiserControle()
        {
            _button.CommandName = NOM_COMMANDE;
            if (string.IsNullOrEmpty(Text))
            {
                Text = "Réinitialiser";
            }
            base.InitialiserControle();
        }
        /// <summary>
        /// OnLoad
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Visible = true;
        }
        /// <summary>
        /// Gère l'évènement <see cref="BoutonBase.OnPreRender"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.EventArgs"/> contenant les données de l'évènement.</param>
        protected override void OnPreRender(EventArgs e)
        {
            //_button.Visible = ObtenirModeAffichage() == ModeAffichage.Modification;
            Visible = ObtenirModeAffichage() == ModeAffichage.Modification;
            if (Visible)
            {
                Style.Add("padding-right", "5px");
            }
            base.OnPreRender(e);
        }
    }
}
