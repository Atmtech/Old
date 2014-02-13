using System;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Bouton approuver.
    /// </summary>
    public class Bouton : BoutonBase
    {
        /// <summary>
        /// Pointeur de l'événement annuler
        /// </summary>
        public event EventHandler Click;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Bouton"/>.
        /// </summary>
        public Bouton()
        {
            CausesValidation = true;
        }

        /// <summary>
        /// Définit le comportement pour le click du bouton.
        /// </summary>
        /// <param name="sender">La source de l'évènement.</param>
        /// <param name="e">L'instance de <see cref="System.EventArgs"/> contenant les données de l'évènement.</param>
        protected override void Button_Click(object sender, EventArgs e)
        {
            base.Button_Click(sender, e);
            if (Click != null)
            {
                Click(this, e);
            }
        }

        /// <summary>
        /// Méthode qui initialise le contrôle de bouton.
        /// </summary>
        protected override void InitialiserControle()
        {
            if (!String.IsNullOrEmpty(ValidationGroup))
            {
                _button.ValidationGroup = ValidationGroup;
            }
            base.InitialiserControle();
        }

        /// <summary>
        /// Gère l'évènement <see cref="BoutonBase.OnPreRender"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.EventArgs"/> contenant les données de l'évènement.</param>
        protected override void OnPreRender(EventArgs e)
        {
            Style.Add("padding-right", "5px");
            base.OnPreRender(e);
        }
    }
}
