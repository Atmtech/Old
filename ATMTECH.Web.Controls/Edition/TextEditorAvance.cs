using System;
using System.Collections;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using ATMTECH.Web.Controls.Affichage;
using ATMTECH.Web.Controls.Base;
using CKEditor.NET;

namespace ATMTECH.Web.Controls.Edition
{
   
    public class TextEditorAvance : ControleBase
    {

        private readonly CKEditorControl _ckEditorControl;
        private readonly TitreLabelAvance _label;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="RadioButtonAvance"/>.
        /// </summary>
        public TextEditorAvance()
            : base(false)
        {
            _ckEditorControl = new CKEditorControl();
            _label = new TitreLabelAvance();
        }

        public string Text
        {
            get { return _ckEditorControl.Text; }
            set { _ckEditorControl.Text = value; }
        }
        public string Toolbar
        {
            get { return _ckEditorControl.Toolbar; }
            set { _ckEditorControl.Toolbar = value; }
        }
        
        /// <summary>
        /// Le groupe de RadioButton auquel fait parti le RadioButton.
        /// </summary>
        [CategoryAttribute("Comportement")]
        [Description("Coché ou non.")]
        public string GroupName
        {
            get; set; }
        
      
        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.Init"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnInit(EventArgs e)
        {
            _ckEditorControl.ID = "textEditor";
            

            base.OnInit(e);
        }

        /// <summary>
        /// Appelé par l'infrastructure de page ASP.NET pour avertir les contrôles serveur qui utilisent une implémentation basée sur la composition qu'ils doivent créer tous les contrôles enfants qu'ils contiennent en préparation de la publication ou du rendu.
        /// </summary>
        protected override void CreateChildControls()
        {
            Controls.Add(_ckEditorControl);
            Controls.Add(_label);
            base.CreateChildControls();
        }

        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.PreRender"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnPreRender(EventArgs e)
        {
            //Page.InclureRessourceJavascript("Edition.RadioButtonAvance.js");
            _ckEditorControl.Enabled = Enabled;
            _ckEditorControl.Width = Width;
            _ckEditorControl.Height = Height;
            _ckEditorControl.CssClass = "radioButtonAvance";
            //if(!string.IsNullOrEmpty(Text))
            //    _label.CssClass = "libelleradioButtonAvance";

            //Ce bout de code est utilisé ici plutôt que dans le Render puisqu'on perdait la valeur du Checked.);
            if (ObtenirModeAffichage() != ModeAffichage.Modification)
            {
                _ckEditorControl.Enabled = false;
            }
            base.OnPreRender(e);
        }

        /// <summary>
        /// Génère le rendu de la balise d'ouverture HTML du contrôle via le writer spécifié. Cette méthode est principalement utilisée par des développeurs de contrôles.
        /// </summary>
        /// <param name="writer"><see cref="T:System.Web.UI.HtmlTextWriter"/> qui représente le flux de sortie utilisé pour rendre le contenu HTML sur le client.</param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            // Rien
        }

        /// <summary>
        /// Génère le rendu de la balise de fermeture HTML du contrôle via le writer spécifié. Cette méthode est principalement utilisée par des développeurs de contrôles.
        /// </summary>
        /// <param name="writer"><see cref="T:System.Web.UI.HtmlTextWriter"/> qui représente le flux de sortie utilisé pour rendre le contenu HTML sur le client.</param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            // Rien
        }

        /// <summary>
        /// Load le viewState du radioButton.
        /// </summary>
        /// <param name="savedState">Le state.</param>
        protected override void LoadViewState(object savedState)
        {
            if (savedState.GetType() == typeof(ArrayList))
            {
                ArrayList arrayList = (ArrayList)savedState;
                base.LoadViewState(arrayList[0]);
                if (arrayList[1] != null)
                    Text = (string)arrayList[1];
                //if (!string.IsNullOrEmpty((string)arrayList[2]))
                //    GroupName = (string)arrayList[2];
            }
            else
            {
                base.LoadViewState(savedState);
            }
        }

        /// <summary>
        /// Enregistre les états modifiés après l'appel de la méthode <see cref="M:System.Web.UI.WebControls.Style.TrackViewState"/>.
        /// </summary>
        /// <returns>
        /// Objet qui contient l'état d'affichage actuel du contrôle ; sinon, null si aucun état d'affichage n'est associé au contrôle.
        /// </returns>
        protected override object SaveViewState()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(base.SaveViewState());
            arrayList.Add(Text);
           // arrayList.Add(GroupName);            

            return arrayList;
        }
    }
}
