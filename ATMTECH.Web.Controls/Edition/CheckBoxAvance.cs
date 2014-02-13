using System;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Base;
using ATMTECH.Web.Controls.Interfaces;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Contrôle à toujours utiliser au lieu du asp:CheckBox standard.
    /// <code><![CDATA[
    /// Exemples d'utilisation:
    /// 
    /// <table>
    /// <tr>
    ///    <ATMTECH:CheckBoxAvance runat="server" Libelle="Regulier:" />
    /// </tr>
    /// </table>
    /// ]]></code>
    /// </summary>
    public class CheckBoxAvance : ControleBase, IControleAvecLibelle
    {
        #region Constructeur et propriétés.

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="CheckBoxAvance"/>.
        /// </summary>
        public CheckBoxAvance() : base(false)
        {
            _checkBox = new CheckBox();
        }

        private readonly CheckBox _checkBox;

        #region IControleAvecLibelle ------------------------------------------

        /// <summary>
        /// Le contenu du libellé associé au contrôle
        /// </summary>
        [Category("Appearance")]
        [Description("Le contenu du libellé associé au textbox.")]
        public string Libelle
        {
            get { return ObtenirProprieteViewState("Libelle", string.Empty); }
            set { AssignerProprieteViewState("Libelle", value); }
        }

        /// <summary>
        /// La largeur du libellé.
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("La largeur du libellé.")]
        public Unit LibelleLargeur
        {
            get { return ObtenirProprieteViewState("LibelleLargeur", Unit.Empty); }
            set { AssignerProprieteViewState("LibelleLargeur", value); }
        }

        /// <summary>
        /// Le style de la cellule du libelle
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("Le style de la cellule de libelle.")]
        public string StyleCelluleLibelle
        {
            get { return ObtenirProprieteViewState("StyleCelluleLibelle", string.Empty); }
            set { AssignerProprieteViewState("StyleCelluleLibelle", value); }
        }

        /// <summary>
        /// Le style de la cellule de contenu
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("Le style de la cellule de contenu.")]
        public string StyleCelluleContenu
        {
            get { return ObtenirProprieteViewState("StyleCelluleContenu", string.Empty); }
            set { AssignerProprieteViewState("StyleCelluleContenu", value); }
        }

        /// <summary>
        /// Le nombre de colonnes que va occuper le contrôle (cellule de contenu)
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("Le nombre de colonnes que va occuper le contrôle.")]
        public int ColumnSpan
        {
            get { return ObtenirProprieteViewState("ColumnSpan", 0); }
            set { AssignerProprieteViewState("ColumnSpan", value); }
        }

        #endregion ------------------------------------------------------------

        /// <summary>
        /// Publication automatique sur le serveur après changement de la sélection.
        /// </summary>
        [Category("Comportement")]
        [Description("Publication automatique sur le serveur après changement de la sélection.")]
        public bool AutoPostBack
        {
            get { return _checkBox.AutoPostBack; }
            set
            {
                if (_checkBox != null)
                {
                    _checkBox.AutoPostBack = value;
                }
            } 
        }

        /// <summary>
        /// Coché ou non.
        /// </summary>
        [CategoryAttribute("Comportement")]
        [Description("Coché ou non (version Byte, utile pour le binding).")]
        public byte Value
        {
            get { return Checked ? (byte)1 : (byte)0; }
            set { Checked = (value == 1); }
        }

        /// <summary>
        /// Coché ou non.
        /// </summary>
        [CategoryAttribute("Comportement")]
        [Description("Coché ou non.")]
        public bool Checked { get; set; }

        /// <summary>
        /// Indique ce que la case cochée représente
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("Indique ce que la case cochée représente")]
        public string ContexteCoche { get; set; }

        /// <summary>
        /// Indique ce que la case vide représente
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("Indique ce que la case vide représente")]
        public string ContexteVide { get; set; }

        private bool _valeurParDefaut;
        
        /// <summary>
        /// Valeur par défaut (coché ou non) en mode ajout d'une grille. Utiliser
        /// cette propriété pour préciser que le champ doit être coché initialement
        /// lors de l'ajout.
        /// </summary>
        [CategoryAttribute("Behavior")]
        [Description("Mettre à true pour cocher par défaut en mode ajout d'une grille")]
        public virtual bool ValeurParDefaut
        {
            get { return _valeurParDefaut; }
            set
            {
                _valeurParDefaut = value;
                DataBinding -= OnDataBindingValeurParDefaut;
                DataBinding += OnDataBindingValeurParDefaut;
            }
        }

        #endregion

        #region Event Handlers

        // Assignation de la valeur par défaut en mode ajout.
        private void OnDataBindingValeurParDefaut(object sender, EventArgs args)
        {
            if (Contexte == ContexteUtilisation.GrilleAjout || Contexte == ContexteUtilisation.FenetreDialogue)
            {
                Checked = _valeurParDefaut;
            }
        }

        #endregion

        #region Évènements

        /// <summary>
        /// Se déclenche lorsque l'état du checkbox a changé.
        /// </summary>
        [Category("Action")]
        [Description("Se déclenche lorsque l'état du checkbox a changé.")]
        public event EventHandler CheckedChanged;

        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.Init"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnInit(EventArgs e)
        {
            _checkBox.ID = "chkBox";
            _checkBox.CheckedChanged += _ChkBox_CheckedChanged;

            AjouterClasseCss(_checkBox, "checkBoxAvance");
            base.OnInit(e);
        }

        #endregion

        #region Méthodes protected

        /// <summary>
        /// Appelé par l'infrastructure de page ASP.NET pour avertir les contrôles serveur qui utilisent une implémentation basée sur la composition qu'ils doivent créer tous les contrôles enfants qu'ils contiennent en préparation de la publication ou du rendu.
        /// </summary>
        protected override void CreateChildControls()
        {
            Controls.Add(_checkBox);
            base.CreateChildControls();
        }

        /// <summary>
        /// Génère le rendu de la balise d'ouverture HTML du contrôle via le writer spécifié. Cette méthode est principalement utilisée par des développeurs de contrôles.
        /// </summary>
        /// <param name="writer"><see cref="T:System.Web.UI.HtmlTextWriter"/> qui représente le flux de sortie utilisé pour rendre le contenu HTML sur le client.</param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
        }

        /// <summary>
        /// Génère le rendu de la balise de fermeture HTML du contrôle via le writer spécifié. Cette méthode est principalement utilisée par des développeurs de contrôles.
        /// </summary>
        /// <param name="writer"><see cref="T:System.Web.UI.HtmlTextWriter"/> qui représente le flux de sortie utilisé pour rendre le contenu HTML sur le client.</param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
        }

        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.PreRender"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnPreRender(EventArgs e)
        {
            if (String.IsNullOrEmpty(ContexteCoche))
            {
                ContexteCoche = "Oui";
            }

            if (String.IsNullOrEmpty(ContexteVide))
            {
                ContexteVide = "Non";
            }
            _checkBox.Checked = Checked;
            if (ObtenirModeAffichage() != ModeAffichage.Modification || !Enabled)
            {
                _checkBox.Visible = false;
            }
            else
            {
                _checkBox.Visible = true;
            }
            base.OnPreRender(e);
        }

        /// <summary>
        /// Écrit le contenu <see cref="T:System.Web.UI.WebControls.CompositeControl"/> dans l'objet <see cref="T:System.Web.UI.HtmlTextWriter"/> spécifié pour qu'il s'affiche sur le client.
        /// </summary>
        /// <param name="writer"><see cref="T:System.Web.UI.HtmlTextWriter"/> qui représente le flux de sortie utilisé pour rendre le contenu HTML sur le client.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            this.CreerCelluleLibelle(writer);
            this.OuvrirCelluleContenu(writer);

            if (ObtenirModeAffichage() == ModeAffichage.Modification && Enabled)
            {
                base.Render(writer);
            }
            else
            {
                this.EcrireControleLectureSeule(writer, Checked ? ContexteCoche : ContexteVide);
                _checkBox.RenderControl(writer);
            }
            
            this.FermerCelluleContenu(writer);
        }

        /// <summary>
        /// Ajoutes une classe CSS à un contrôle.
        /// </summary>
        /// <param name="ctl">Le contrôle sur lequel on applique le style.</param>
        /// <param name="cssClass">La classe CSS.</param>
        protected static void AjouterClasseCss(WebControl ctl, string cssClass)
        {
            StringBuilder sb = new StringBuilder();
            if (!String.IsNullOrEmpty(ctl.CssClass))
            {
                sb.Append(ctl.CssClass);
                sb.Append(" ");
            }
            sb.Append(cssClass);

            ctl.CssClass = sb.ToString();
        }

        #endregion

        #region Méthodes privates

        // Event Listeners ----------------------------------------------------

        private void _ChkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox controle = sender as CheckBox;
            if(controle != null)
            {
                if (controle.Checked != Checked)
                {
                    Checked = controle.Checked;
                }
            }

            if (CheckedChanged != null)
            {
                CheckedChanged(sender, e);
            }
        }

        #endregion

        /// <summary>
        /// Load le viewState de la CheckBox.
        /// </summary>
        /// <param name="savedState">Le state.</param>
        protected override void LoadViewState(object savedState)
        {
            if (savedState.GetType() == typeof(ArrayList))
            {
                int i = 0;
                ArrayList arrayList = (ArrayList)savedState;
                base.LoadViewState(arrayList[i]);
                if (arrayList[++i] != null)
                    Checked = (bool)arrayList[i];
                if (!string.IsNullOrEmpty((string)arrayList[++i]))
                    ContexteCoche = (string) arrayList[i];
                if (!string.IsNullOrEmpty((string)arrayList[++i]))
                    ContexteVide = (string)arrayList[i];
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
            arrayList.Add(Checked);
            arrayList.Add(ContexteCoche);
            arrayList.Add(ContexteVide);

            return arrayList;
        }
    }
}