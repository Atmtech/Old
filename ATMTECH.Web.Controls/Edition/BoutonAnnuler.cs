using System;
using ATMTECH.Web.Controls.Affichage;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Bouton approuver.
    /// </summary>
    public class BoutonAnnuler : BoutonBase
    {
        /// <summary>
        /// CommandName de ce bouton
        /// </summary>
        public const string NOM_COMMANDE = "Annuler";

        /// <summary>
        /// Pointeur de l'événement annuler
        /// </summary>
        public event EventHandler Annuler;

        /// <summary>
        /// Définit le comportement pour le click du bouton.
        /// </summary>
        /// <param name="sender">La source de l'évènement.</param>
        /// <param name="e">L'instance de <see cref="System.EventArgs"/> contenant les données de l'évènement.</param>
        protected override void Button_Click(object sender, EventArgs e)
        {
            base.Button_Click(sender, e);
            if (Annuler != null)
            {
                Annuler(this, e);
            }
            if (Contexte == ContexteUtilisation.FenetreDialogue)
            {
                FenetreDialogue.FermerDialogueParent(this);
            }
        }

        /// <summary>
        /// Méthode qui initialise le contrôle de bouton.
        /// </summary>
        protected override void InitialiserControle()
        {
            _button.CommandName = NOM_COMMANDE ;
            if (string.IsNullOrEmpty(Text))
            {
                Text = "Annuler";
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
            Style.Add("padding-right", "5px");
            base.OnPreRender(e);
        }
    }
}
