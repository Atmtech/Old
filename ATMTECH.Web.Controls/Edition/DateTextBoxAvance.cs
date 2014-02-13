using System;
using System.Collections;
using System.ComponentModel;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Contrôle SIQ à utiliser obligatoirement au lieu du asp:TextBox normal
    /// pour tout champ restreint à une date sans heure.
    /// </summary>
    /// <code><![CDATA[
    /// Exemples d'utilisation:
    /// 
    /// <tr>
    ///     <ATMTECH:DateTextBoxAvance runat="server" Libelle="Date" />
    /// </tr>
    /// ]]></code>
    //[ValidationProperty("Text")]
    public class DateTextBoxAvance : TextBoxAvance
    {
        #region Membres privés

        private readonly RangeValidator _rangeValidator;
        #endregion

        /// <summary>
        /// Retourne la date saisie en type natif DateTime
        /// </summary>
        public DateTime ValeurDateTime
        {
            get { return DateTime.Parse(Text.Replace(".", ",")); }
            set { Text = string.Format("{0:yyyy-MM-dd}", value); }
        }

        public DateTime? ValeurDateTimeNullable
        {
            get { return string.IsNullOrWhiteSpace(Text) ? (DateTime?) null : ValeurDateTime; }
            set
            {
                if (value == null)
                    Text = string.Empty;
                else
                    ValeurDateTime = value.Value;
            }
        }

        /// <summary>
        /// La date maximum
        /// </summary>
        [Category("Behavior")]
        [Description("La date maximum.")]
        public string DateMinimum { get; set; }

        /// <summary>
        /// La date minimum
        /// </summary>
        [CategoryAttribute("Behavior")]
        [Description("La date minimum.")]
        public string DateMaximum { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="DateTextBoxAvance"/>.
        /// </summary>
        public DateTextBoxAvance()
        {
            DateMinimum = new DateTime(1753, 01, 01).ToString("yyyy-MM-dd");
            DateMaximum = new DateTime(9999, 12, 31).ToString("yyyy-MM-dd");

            _rangeValidator = new RangeValidator();
        }


        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.PreRender"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnPreRender(EventArgs e)
        {
            // Les dates ont toujours la même largeur
            Width = Unit.Pixel(70);

            // Le Base doit être appelé avant le bloc JS pour l'inclusion du TextBoxAvance.js
            if (ObtenirModeAffichage() == ModeAffichage.Modification && Enabled)
            {
                AjouterClasseCss(Enabled ? "dateTextBoxAvance" : "dateSansCalendrierTextBoxAvance");
                const string js = "if ($.ATMTECH == undefined) $.ATMTECH = {}; $.ATMTECH.imgCalUrl = '@@Edition.calendrier.png@@';";
                Page.IncorporerJavascript("DateTextBoxAvance", js);
            }
            if (!EstLectureSeule())
            {
                PreparerRangeValidator();
            }
            base.OnPreRender(e);
        }

        /// <summary>
        /// Déclenche l'événement CreateChildControls.
        /// </summary>
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            _rangeValidator.ID = "rangeVal";
            _rangeValidator.ControlToValidate = _textBox.ID;
            _rangeValidator.Enabled = false;
            Controls.Add(_rangeValidator);
        }

        private void PreparerRangeValidator()
        {
            _rangeValidator.Enabled = true;
            _rangeValidator.Visible = true;
            _rangeValidator.MinimumValue = DateMinimum;
            _rangeValidator.MaximumValue = DateMaximum;
            _rangeValidator.ErrorMessage = String.Format("Veuillez saisir une date valide (entre {0} et {1})", DateMinimum,
                                                         DateMaximum);
            _rangeValidator.ToolTip = _rangeValidator.ErrorMessage;
            _rangeValidator.ValidationGroup = ValidationGroup;
            _rangeValidator.Display = ValidatorDisplay.Dynamic;
            _rangeValidator.Type = ValidationDataType.Date;
            EditionUtils.CreerIndicateurErreur(_textBox, _rangeValidator);
        }

        /// <summary>
        /// Restaure les informations d'état d'affichage à partir d'une précédente requête enregistrées avec la méthode <see cref="M:System.Web.UI.WebControls.WebControl.SaveViewState"/>.
        /// </summary>
        /// <param name="savedState">Objet qui représente l'état du contrôle à restaurer.</param>
        protected override void LoadViewState(object savedState)
        {
            if (savedState.GetType() == typeof(ArrayList))
            {
                ArrayList tblValeurs = (ArrayList)savedState;
                base.LoadViewState(tblValeurs[0]);
                if (tblValeurs[1] != null)
                    DateMinimum = tblValeurs[1].ToString();
                if (tblValeurs[2] != null)
                    DateMaximum = tblValeurs[2].ToString();
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
            tblValeurs.Add(DateMinimum);
            tblValeurs.Add(DateMaximum);
            return tblValeurs;
        }
    }
}