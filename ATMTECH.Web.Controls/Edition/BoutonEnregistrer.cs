using System;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Bouton approuver.
    /// </summary>
    public class BoutonEnregistrer : BoutonBase
    {
        public BoutonEnregistrer()
        {
            CausesValidation = true;
        }

        /// <summary>
        /// Pointeur de l'événement annuler
        /// </summary>
        public event EventHandler Enregistrer;
        /// <summary>
        /// indique si le bouton est un bouton de televersement
        /// </summary>
        public bool EstTeleverser { get; set; }

        /// <summary>
        /// Permet d'obtenir ou définir le message à afficher lorsqu'on appuie sur le bouton Enregistrer.  Si le message est vide, rien ne s'affiche.
        /// </summary>
        /// <value>The message validation enregistrer.</value>
        public string MessageValidationEnregistrer
        {
            get { return MessageConfirmation; }
            set { MessageConfirmation = value; }
        }

        /// <summary>
        /// Définit le comportement pour le click du bouton.
        /// </summary>
        /// <param name="sender">La source de l'évènement.</param>
        /// <param name="e">L'instance de <see cref="System.EventArgs"/> contenant les données de l'évènement.</param>
        protected override void Button_Click(object sender, EventArgs e)
        {
            base.Button_Click(sender, e);
            bool valid = true;
            if (Contexte == ContexteUtilisation.Page && String.IsNullOrEmpty(ValidationGroup))
            {
                Page.Validate();
                valid = Page.IsValid;
            }

            if (valid && Enregistrer != null)
            {
                Enregistrer(this, e);
            }
        }

        /// <summary>
        /// Méthode qui initialise le contrôle de bouton.
        /// </summary>
        protected override void InitialiserControle()
        {
            if (Contexte == ContexteUtilisation.GrilleAjout || Contexte == ContexteUtilisation.GrilleModification)
            {
                InitialiserControleDetail();
            }
            else
            {
                InitialiserControlePage();
            }
        }

        // Version pour un "popin" de grille
        private void InitialiserControleDetail()
        {
            if (string.IsNullOrEmpty(Text))
            {
                Text = Contexte == ContexteUtilisation.GrilleAjout ? "Ajouter" : "Modifier";
            }
            base.InitialiserControle();
            if (!String.IsNullOrEmpty(ValidationGroup))
            {
                _button.ValidationGroup = ValidationGroup;
            }
            _button.CommandName = Contexte == ContexteUtilisation.GrilleAjout ? "Insert" : "Update";
        }

        // Version pour une page
        private void InitialiserControlePage()
        {
            if (!String.IsNullOrEmpty(ValidationGroup))
            {
                _button.ValidationGroup = ValidationGroup;
            }
            if (string.IsNullOrEmpty(Text))
            {
                Text = EstTeleverser ? "Ajouter" : "Enregistrer";
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
