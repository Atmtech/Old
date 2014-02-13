using System;
using System.ComponentModel;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BoutonBase : ControleBase
    {
        /// <summary>
        /// Variable contenant l'instance du bouton.
        /// </summary>
        protected readonly Button _button;

        /// <summary>
        /// Le text du bouton.
        /// </summary>
        [Category("Appearance")]
        [Description("Le text du bouton.")]
        public string Text
        {
            get { return (string)(ViewState["Text"] ?? string.Empty); }
            set { ViewState["Text"] = value; }
        }

        /// <summary>
        /// JavaScript lancé lors du click du bouton
        /// </summary>
        [Category("Behavior")]
        [Description("JavaScript lancé lors du click du bouton")]
        [DefaultValue(null)]
        public string OnClientClick
        {
            get { return (string)(ViewState["OnClientClick"] ?? String.Empty); }
            set { ViewState["OnClientClick"] = value; }
        }

        /// <summary>
        /// Message de confirmation Javascript. Ne pas utiliser en même temps que OnClientClick.
        /// </summary>
        public string MessageConfirmation
        {
            get { return ObtenirProprieteViewState("MessageConfirmation", string.Empty); }
            set { AssignerProprieteViewState("MessageConfirmation", value); }
        }

        /// <summary>
        /// Détermine si le click du bouton cause la validation de la page.
        /// </summary>
        [Category("Behavior")]
        [Description("Détermine si le click du bouton cause la validation de la page.")]
        [DefaultValue(true)]
        public bool CausesValidation
        {
            get { return ObtenirProprieteViewState("CausesValidation", false); }
            set { AssignerProprieteViewState("CausesValidation", value); }
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="BoutonBase"/>.
        /// </summary>
        protected BoutonBase()
            : base(false)
        {
            _button = new Button();
            _button.ID = "btn";
            _button.Click += Button_Click;
            CausesValidation = false; // False par défaut dans la classe de base.
        }

        /// <summary>
        /// Gère l'évènement click du bouton..
        /// </summary>
        /// <param name="sender">La source de l'évènement.</param>
        /// <param name="e">L'instance de la classe <see cref="System.EventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void Button_Click(object sender, EventArgs e)
        {
         
        }

        /// <summary>
        /// Méthode qui initialise le contrôle de bouton.
        /// </summary>
        protected virtual void InitialiserControle()
        {
            InitialiserTextEtTooltipBouton();
            _button.CausesValidation = CausesValidation;
            InitialiserTailleBouton();
            AssignerEvenementClient();
        }

        /// <summary>
        /// Initialise la valeur du text et du tooltip.
        /// </summary>
        protected virtual void InitialiserTextEtTooltipBouton()
        {
            _button.Text = Text;
            _button.ToolTip = !string.IsNullOrEmpty(ToolTip) ? ToolTip : Text;
        }

        /// <summary>
        /// Initialise la taille des boutons.
        /// </summary>
        protected virtual void InitialiserTailleBouton()
        {
            if (!Width.IsEmpty)
            {
                _button.Width = Width;
            }
            if (!Height.IsEmpty)
            {
                _button.Height = Height;
            }
        }

        /// <summary>
        /// Lève de l'évènement <see cref="OnPreRender"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.EventArgs"/> contenant les données de l'évènement.</param>
        protected override void OnPreRender(EventArgs e)
        {
            InitialiserControle();
            base.OnPreRender(e);
        }

        /// <summary>
        /// Appelé par l'infrastructure de page ASP.NET pour avertir les contrôles serveur qui utilisent une implémentation basée sur la composition qu'ils doivent créer tous les contrôles enfants qu'ils contiennent en préparation de la publication ou du rendu.
        /// </summary>
        protected override void CreateChildControls()
        {
            Controls.Add(_button);
            base.CreateChildControls();
        }

        private void AssignerEvenementClient()
        {
            if (!string.IsNullOrEmpty(OnClientClick))
            {
                _button.Attributes["onclick"] = OnClientClick;
            }
            else if (!string.IsNullOrEmpty(MessageConfirmation))
            {
                string js = "return confirm('" + MessageConfirmation.Replace("'", @"\'") + "');";
                if (CausesValidation)
                {
                    js = "if(typeof (Page_ClientValidate) != 'function' || Page_ClientValidate('" + ValidationGroup +
                         "')){ " + js + " } else { return true; }";
                }
                _button.Attributes["onclick"] = js;
            }
            else
            {
                _button.Attributes.Remove("onclick");
            }
        }
    }
}
