using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Base;
using ATMTECH.Web.Controls.Interfaces;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Contrôle SIQ à utiliser obligatoirement au lieu du asp:TextBox normal.
    /// 
    /// NOTEs: Le contrôle doit être utilisé à l'intérieur
    /// d'une table HTML puisqu'il sépare le libellé du texte
    /// via des td (colonnes).
    /// </summary>
    /// <code><![CDATA[
    /// Exemples d'utilisation:
    /// 
    ///<table>
    ///<tr>
    ///    <ATMTECH:TextBoxAvance runat="server" Libelle="Standard" />
    ///</tr>
    ///<tr>
    ///    <ATMTECH:TextBoxAvance runat="server" Libelle="Obligatoire" EstObligatoire="true"  />
    ///</tr>
    ///<tr>
    ///    <ATMTECH:TextBoxAvance runat="server" Libelle="Disabled" Enabled="false" />
    ///</tr>
    ///<tr>
    ///    <ATMTECH:TextBoxAvance runat="server" Libelle="Max Length 10" MaxLength="10" />
    ///</tr>
    ///<tr>
    ///    <ATMTECH:TextBoxAvance runat="server" Libelle="Width 200" Width="200" />
    ///</tr>
    ///<tr>
    ///    <ATMTECH:TextBoxAvance runat="server" Libelle="RegExp \d{4}"
    ///       ValidationRegExp="^\d{4}$" ValidationRegExpMessage="Validation RegExp non valide!" />
    ///</tr>
    ///</table>
    /// ]]></code>
    //[ValidationProperty("Text")]
    public class TextBoxAvance : ControleBase, IControleAvecLibelle
    {
        #region Membres privés
        /// <summary>
        /// 
        /// </summary>
        protected readonly TextBox _textBox; //Le textbox cible.
        private readonly RegularExpressionValidator _expressionValidator;
        private readonly LiteralControl _suffixeControle;
        #endregion

        #region Ctor
        /// <summary>
        /// Preuve de concept qu'on peut faire mieux !!! 
        /// </summary>
        public TextBoxAvance()
        {
            _textBox = new TextBox();
            _suffixeControle = new LiteralControl();
            Enabled = true;
            _expressionValidator = new RegularExpressionValidator();
            AlignementParDefaut = TextAlign.Left;
        }

        #endregion

        #region Propriétés de configuration

        /// <summary>
        /// Longueur maximale du texte
        /// </summary>
        [Category("Behavior")]
        [Description("Nombre maximal de caractères autorisé.")]
        public virtual int MaxLength
        {
            get { return _textBox.MaxLength; }
            set { _textBox.MaxLength = value; }
        }

        /// <summary>
        /// AutoPostBack
        /// </summary>
        [Category("Behavior")]
        [Description("Propriété autoPostBack")]
        public virtual bool AutoPostBack
        {
            get { return _textBox.AutoPostBack; }
            set { _textBox.AutoPostBack = value; }
        }

        /// <summary>
        /// Est un textbox avec des XXXX
        /// </summary>
        [Category("Behavior")]
        [Description("Est une case pour mot de passe")]
        public virtual bool EstPassword
        {
            get
            {
                return _textBox.TextMode == TextBoxMode.Password;
            }
            set
            {
                if (value)
                {
                    _textBox.TextMode = TextBoxMode.Password;
                }
            }
        }



        private int? _nombreEntiers;

        /// <summary>
        /// Longueur maximale du texte avant la virgule
        /// </summary>
        [Category("Behavior")]
        [Description("Nombre maximal de caractères autorisé avant la virgule (max. 80).")]
        public virtual int? NombreEntiers
        {
            get { return _nombreEntiers.GetValueOrDefault(); }
            set
            {
                if (value < 0 || value > 80)
                {
                    throw new ArgumentOutOfRangeException("value", "Le nombre d'entiers doit être entre 0 et 80.");
                }
                _nombreEntiers = value;
            }
        }

        private int? _nombreDecimaux;

        /// <summary>
        /// Longueur maximale du texte apres la virgule
        /// </summary>
        [Category("Behavior")]
        [Description("Nombre maximal de caractères autorisé après la virgule (max. 19).")]
        public virtual int? NombreDecimaux
        {
            get { return _nombreDecimaux.GetValueOrDefault(); }
            set
            {
                if (value < 0 || value > 19)
                {
                    throw new ArgumentOutOfRangeException("value", "Le nombre de décimales doit être entre 0 et 19.");
                }
                _nombreDecimaux = value;
            }
        }

        /// <summary>
        /// La regular expression à utiliser pour valider
        /// </summary>
        [CategoryAttribute("Behavior")]
        [Description("La regular expression à utiliser pour valider")]
        public string ValidationRegExp
        {
            get { return _expressionValidator.ValidationExpression; }
            set { _expressionValidator.ValidationExpression = value; }
        }

        /// <summary>
        /// Le message de validation si la validation de la
        /// regular expression échoue
        /// </summary>
        [CategoryAttribute("Behavior")]
        [Description("Le message de validation si la validation de la regular expression échoue.")]
        public string ValidationRegExpMessage
        {
            get { return _expressionValidator.ErrorMessage; }
            set { _expressionValidator.ErrorMessage = value; }
        }

        /// <summary>
        /// Alignement par défaut si la propriété Alignement n'est pas renseignée
        /// </summary>
        protected TextAlign AlignementParDefaut { get; set; }

        private TextAlign? _alignement;

        /// <summary>
        /// La largeur du libellé.
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("L'alignement du texte dans le TextBox")]
        public TextAlign Alignement
        {
            get { return _alignement.GetValueOrDefault(AlignementParDefaut); }
            set { _alignement = value; }
        }

        /// <summary>
        /// Texte a placer en suffix du champ
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("Texte a placer en suffix du champ.")]
        public string Suffixe { get; set; }

        #region IControleAvecLibelle ------------------------------------------

        /// <summary>
        /// Le contenu du libellé associé au contrôle
        /// </summary>
        [CategoryAttribute("Appearance")]
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
        /// Le style de la cellule du TextBox
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("Le style du TextBox")]
        public string StyleTextBox { get; set; }


        /// <summary>
        /// Est un champs de Type Comme //Like Recherche
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("Un champs de type Like/Comme dans les recherches")]
        public bool EstChampsCommeDansRecherche { get; set; }


        #endregion

        #region Propriétés d'utilisation


        public TextBoxMode TextMode { get { return _textBox.TextMode; } set { _textBox.TextMode = value; } }

        /// <summary>
        /// Gère le texte affiché dans le champ
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("Valeur du texte.")]
        public virtual string Text
        {
            get
            {
                string texte = _textBox.Text.Trim();
                if (_textBox.MaxLength > 0 && texte.Length > _textBox.MaxLength)
                {
                    return texte.Substring(0, _textBox.MaxLength);
                }
                return texte;
            }
            set
            {
                if (value != null)
                {
                    if (_textBox.MaxLength > 0 && value.Length > _textBox.MaxLength)
                    {
                        _textBox.Text = value.Substring(0, _textBox.MaxLength);
                    }
                    else
                    {
                        _textBox.Text = value;
                    }
                }
                else
                {
                    _textBox.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Gère le texte affiché dans le champ
        /// Retourne null si vide
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("Valeur du texte.")]
        public virtual string TextNullable
        {
            get
            {
                return string.IsNullOrWhiteSpace(Text) ? null : Text;
            }
        }

        /// <summary>
        /// Obtient ou définit une valeur indiquant si le contrôle serveur Web est activé.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// true si le contrôle est activé ; sinon, false. La valeur par défaut est true.
        /// </returns>
        public override sealed bool Enabled { get; set; }

        private string _valeurParDefaut;

        /// <summary>
        /// Valeur par défaut en mode ajout d'une grille. Utiliser cette propriété
        /// pour préciser que le champ doit contenir une valeur initiale lors de
        /// l'ajout.
        /// </summary>
        [CategoryAttribute("Behavior")]
        [Description("Permet de préciser une valeur par défaut en mode ajout d'une grille")]
        public virtual string ValeurParDefaut
        {
            get { return _valeurParDefaut; }
            set
            {
                _valeurParDefaut = value;
                DataBinding -= OnDataBindingValeurParDefaut;
                if (!String.IsNullOrEmpty(_valeurParDefaut))
                {
                    DataBinding += OnDataBindingValeurParDefaut;
                }
            }
        }

        #endregion

        #region Event Handlers

        // Assignation de la valeur par défaut en mode ajout.
        private void OnDataBindingValeurParDefaut(object sender, EventArgs args)
        {
            if (Contexte == ContexteUtilisation.GrilleAjout)
            {
                Text = _valeurParDefaut;
            }
        }

        #endregion

        #region Implémentation

        /// <summary>
        /// Appelé par l'infrastructure de page ASP.NET pour avertir les contrôles serveur qui utilisent une implémentation basée sur la composition qu'ils doivent créer tous les contrôles enfants qu'ils contiennent en préparation de la publication ou du rendu.
        /// </summary>
        protected override void CreateChildControls()
        {
            //Ajout du TextBox et création de son id.
            _textBox.ID = "txt";

            Controls.Add(_textBox);
            Controls.Add(_suffixeControle);

            ValidateurChampRequis.ControlToValidate = _textBox.ID;

            //Ajout du validateur d'expression régulière et création de son id.
            _expressionValidator.Enabled = false;
            _expressionValidator.ID = "expVal";
            _expressionValidator.ControlToValidate = _textBox.ID;
            Controls.Add(_expressionValidator);

            base.CreateChildControls();
        }


        /// <summary>
        /// Méthode permettant d'ajouter une classe CSS au contrôle de texte.
        /// </summary>
        /// <param name="cssClass">La classe CSS..</param>
        protected void AjouterClasseCss(string cssClass)
        {
            StringBuilder sb = new StringBuilder();
            if (!String.IsNullOrEmpty(_textBox.CssClass))
            {
                sb.Append(_textBox.CssClass);
                sb.Append(" ");
            }
            sb.Append(cssClass);

            _textBox.CssClass = sb.ToString();
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
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.Load"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Sinon on aura des classes CSS en double, triple...
            _textBox.CssClass = "textBoxAvance";
        }

        public override bool EnableViewState
        {
            get
            {
                return _textBox.EnableViewState;
            }
            set
            {
                _textBox.EnableViewState = value;
            }
        }

        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.PreRender"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnPreRender(EventArgs e)
        {
            if (Alignement == TextAlign.Right)
            {
                AjouterClasseCss("alignementDroite");
            }
            ValiderAttributs();
            AjusterStyleTextBox();
            AjusterSuffixe();

            if (ObtenirModeAffichage() != ModeAffichage.Modification || !Enabled)
            {
                Controls.Clear();
            }
            else
            {
                AjusterProprietesTextBox();
                Page.InclureRessourceJavascript("Edition.TextBoxAvance.js");
            }
            if (!EstLectureSeule())
            {
                AjusterValidateurReguliereExpressionAvantRendu();
            }
            base.OnPreRender(e);
        }

        /// <summary>
        /// Ajusters the validateur reguliere expression avant rendu.
        /// </summary>
        protected virtual void AjusterValidateurReguliereExpressionAvantRendu()
        {
            _expressionValidator.Visible = !string.IsNullOrEmpty(ValidationRegExp);
            _expressionValidator.Enabled = _expressionValidator.Visible;
            _expressionValidator.Display = ValidatorDisplay.Dynamic;
            _expressionValidator.ValidationGroup = ValidationGroup;
            _expressionValidator.ToolTip = ValidationRegExpMessage;
            EditionUtils.CreerIndicateurErreur(this, _expressionValidator);
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
                ConstruireTextBoxActif(writer);
            }
            else
            {
                ConstruireTextBoxLectureSeule(writer);
            }

            this.FermerCelluleContenu(writer);
        }

        /// <summary>
        /// Ajoute l'indicateur "LIKE" durant le rendu du contrôle.
        /// </summary>
        protected virtual void EcrireIndicateurRechercheLike(TextWriter writer)
        {
            const string titre = "Toutes les lettres de ce champ seront utilisées pour la recherche.";
            string img = Page.GetEncodedResourceUrl("Edition.ChampsLike.png");
            writer.Write("<img title='{0}' src='{1}' />", titre, img);
        }

        /// <summary>
        /// Surclasser cette propriété pour indiquer qu'un champ est décimal (###,##).
        /// </summary>
        protected virtual bool EstUnChampDecimal
        {
            get { return false; }
        }

        /// <summary>
        /// Valide certaines combinaisons d'attribut et lance une exception au besoin.
        /// </summary>
        protected virtual void ValiderAttributs()
        {
            if ((_nombreEntiers.HasValue || _nombreDecimaux.HasValue) && !EstUnChampDecimal)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("NombreEntiers et NombreDecimaux ne doivent pas être spécifiés pour le contrôle '");
                sb.Append(UniqueID);
                sb.Append("' car ce n'est pas un champ décimal (monnaie, TypeSaisie='Decimal'...). ");
                sb.Append("Veuillez utiliser MaxLength pour préciser une longueur maximale.");
                throw new ArgumentException(sb.ToString());
            }
            if (EstUnChampDecimal && !_nombreEntiers.HasValue)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Vous devez préciser au moins NombreEntiers pour le contrôle '");
                sb.Append(UniqueID);
                sb.Append("' car c'est un champ décimal (monnaie, TypeSaisie='Decimal'...).");
                if (MaxLength > 0)
                {
                    sb.Append(" De plus, MaxLength est sans effet pour ce type de champ.");
                }
                throw new ArgumentException(sb.ToString());
            }
        }


        #endregion

        /// <summary>
        /// Restaure les informations d'état d'affichage à partir d'une précédente requête enregistrées avec la méthode <see cref="M:System.Web.UI.WebControls.WebControl.SaveViewState"/>.
        /// </summary>
        /// <param name="savedState">Objet qui représente l'état du contrôle à restaurer.</param>
        protected override void LoadViewState(object savedState)
        {
            if (savedState.GetType() == typeof(ArrayList))
            {
                ArrayList tblValeurs = (ArrayList)savedState;
                int i = 0;
                base.LoadViewState(tblValeurs[i]);
                if (tblValeurs[++i] != null)
                    _textBox.Text = tblValeurs[i].ToString();
                if (tblValeurs[++i] != null)
                    _nombreEntiers = int.Parse(tblValeurs[i].ToString());
                if (tblValeurs[++i] != null)
                    _nombreDecimaux = int.Parse(tblValeurs[i].ToString());
                if (tblValeurs[++i] != null)
                    Suffixe = tblValeurs[i].ToString();
                if (tblValeurs[++i] != null)
                    StyleTextBox = tblValeurs[i].ToString();
                if (tblValeurs[++i] != null)
                    EstChampsCommeDansRecherche = bool.Parse(tblValeurs[i].ToString());
                if (tblValeurs[++i] != null)
                    Enabled = bool.Parse(tblValeurs[i].ToString());
                if (tblValeurs[++i] != null)
                    _alignement = (TextAlign?)tblValeurs[i];
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
            ArrayList tblValeurs = new ArrayList();
            tblValeurs.Add(base.SaveViewState());
            tblValeurs.Add(_textBox.Text);
            tblValeurs.Add(_nombreEntiers);
            tblValeurs.Add(_nombreDecimaux);
            tblValeurs.Add(Suffixe);
            tblValeurs.Add(StyleTextBox);
            tblValeurs.Add(EstChampsCommeDansRecherche);
            tblValeurs.Add(Enabled);
            tblValeurs.Add(_alignement);
            return tblValeurs;
        }

        #region Méthodes privées

        private void ConstruireTextBoxActif(HtmlTextWriter writer)
        {
            base.Render(writer);

            // Lorsque c'est un champs de type "Like" on fait ce rendu
            if (EstChampsCommeDansRecherche)
            {
                EcrireIndicateurRechercheLike(writer);
            }
        }

        private void ConstruireTextBoxLectureSeule(HtmlTextWriter writer)
        {
            this.EcrireControleLectureSeule(writer, _textBox.Text, _textBox.CssClass, StyleTextBox);
            _suffixeControle.RenderControl(writer);
        }

        private void AjusterProprietesTextBox()
        {
            if (_nombreEntiers.HasValue)
            {
                _textBox.AjouterAttribut("NombreEntiers", NombreEntiers.ToString());
            }
            if (_nombreDecimaux.HasValue)
            {
                _textBox.AjouterAttribut("NombreDecimaux", NombreDecimaux.ToString());
            }
            if (MaxLength > 0)
            {
                _textBox.AjouterAttribut("MaxLength", MaxLength.ToString());
            }

            _textBox.TabIndex = TabIndex;
        }

        private void AjusterStyleTextBox()
        {
            if (!Height.IsEmpty)
            {
                _textBox.Height = Height;
            }
            if (Width.IsEmpty)
            {
                Width = Unit.Pixel(110);
            }
            _textBox.Width = Width;
            _textBox.Style.Value = StyleTextBox;
        }

        private void AjusterSuffixe()
        {
            _suffixeControle.Text = String.IsNullOrEmpty(Suffixe)
                                        ? string.Empty
                                        : string.Format("<span class='suffixeTextBox'>{0}</span>", Suffixe);
        }
        #endregion

    }
}
