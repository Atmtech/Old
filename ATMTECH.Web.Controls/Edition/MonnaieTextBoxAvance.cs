using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using ATMTECH.Common;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Contrôle SIQ à utiliser obligatoirement au lieu du asp:TextBox normal
    /// pour tout champ restreint à de l'argent.
    /// </summary>
    /// <code><![CDATA[
    /// Exemples d'utilisation:
    /// 
    /// <tr>
    ///     <ATMTECH:MonnaieTextBoxAvance id="txtMonnaie" runat="server" Libelle="Monnaie" />
    /// </tr>
    /// ]]></code>
    //[ValidationProperty("Text")]
    public class MonnaieTextBoxAvance : TextBoxAvance
    {
        private const int NOMBRE_DECIMAL_PAR_DEFAUT = 2;

        /// <summary>
        /// Constructeur pour régler les valeurs par défaut
        /// </summary>
        public MonnaieTextBoxAvance()
        {
            NombreDecimaux = NOMBRE_DECIMAL_PAR_DEFAUT;
            AlignementParDefaut = TextAlign.Right;
        }

        private Monnaie _valeurMonnaie;

        /// <summary>
        /// Retourne le montant saisie en type natif decimal
        /// </summary>
        public decimal ValeurDecimale
        {
            get
            {
                return ObtenirValeurDecimale(Text);
            }
            set { Text = String.Format("{0}", value); }
        }

        /// <summary>
        /// Retourne le montant saisie en type monnaie
        /// </summary>
        [TypeConverter(typeof(ConvertisseurMonnaie))]
        public Monnaie ValeurMonnaie
        {
            get
            {
                Monnaie monnaie = FormatterMontant(_valeurMonnaie, NombreDecimaux.GetValueOrDefault(NOMBRE_DECIMAL_PAR_DEFAUT)) ==
                                  FormatterMontant(ObtenirValeurDecimale(Text),
                                                   NombreDecimaux.GetValueOrDefault(NOMBRE_DECIMAL_PAR_DEFAUT))
                                      ? _valeurMonnaie
                                      : ObtenirValeurDecimale(Text);

                return monnaie;
            }
            set
            {
                Text = FormatterMontant(value, NombreDecimaux.GetValueOrDefault(NOMBRE_DECIMAL_PAR_DEFAUT));
                _valeurMonnaie = value;
            }
        }
        /// <summary>
        /// Retourne le montant saisie en type monnaie
        /// </summary>
        [TypeConverter(typeof(ConvertisseurMonnaie))]
        public Monnaie ValeurMonnaieNullable
        {
            get
            {
                Monnaie monnaie =
                    FormatterMontant(_valeurMonnaie, NombreDecimaux.GetValueOrDefault(NOMBRE_DECIMAL_PAR_DEFAUT)) ==
                    FormatterMontant(ObtenirValeurDecimaleNullable(Text),NombreDecimaux.GetValueOrDefault(NOMBRE_DECIMAL_PAR_DEFAUT))
                        ? _valeurMonnaie
                        : ObtenirValeurDecimaleNullable(Text).HasValue
                              ? ObtenirValeurDecimaleNullable(Text).GetValueOrDefault()
                              : (Monnaie)null;

                return monnaie;
            }
            set
            {
                Text = FormatterMontant(value, NombreDecimaux.GetValueOrDefault(NOMBRE_DECIMAL_PAR_DEFAUT));
                _valeurMonnaie = value;
            }
        }
        /// <summary>
        /// Indique si le montant saisie doit-être que positif.
        /// </summary>
        public bool EstSeulementPositif { get; set; }

        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.PreRender"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            string css = string.Format("monnaieTextBoxAvance{0}",
                                       EstSeulementPositif ? " positifSeul" : string.Empty);
            AjouterClasseCss(css);

            // Pour formatter la valeur (Ajouter les décimaux et séparateur de millier si besoin)
            if (!string.IsNullOrEmpty(_textBox.Text))
            {
                if (ObtenirModeAffichage() == ModeAffichage.Modification && Enabled)
                {
                    _textBox.Text = FormatterMontant(ValeurDecimale, NombreDecimaux.GetValueOrDefault(NOMBRE_DECIMAL_PAR_DEFAUT));
                }
                else
                {
                    _textBox.Text = FormatterMontantLectureSeule(ValeurDecimale, NombreDecimaux.GetValueOrDefault(NOMBRE_DECIMAL_PAR_DEFAUT));
                }
            }
        }

        /// <summary>
        /// Le champ monnaie est toujours de décimal de nature
        /// </summary>
        protected override bool EstUnChampDecimal
        {
            get { return true; }
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
                    EstSeulementPositif = bool.Parse(tblValeurs[1].ToString());
                if (!string.IsNullOrEmpty((string)tblValeurs[2]))
                    ValeurMonnaie = new Monnaie(ObtenirValeurDecimale((string)tblValeurs[2]));
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
            tblValeurs.Add(EstSeulementPositif);
            tblValeurs.Add(_valeurMonnaie != null ? _valeurMonnaie.ToString(string.Empty) : null);
            return tblValeurs;
        }
        private static string FormatterMontant(decimal? montant, int nbDecimales)
        {
            // ReSharper disable FormatStringProblem
            return string.Format("{0:N" + nbDecimales + "}", montant);
            // ReSharper restore FormatStringProblem
        }
        private static string FormatterMontant(decimal montant, int nbDecimales)
        {
            // ReSharper disable FormatStringProblem
            return string.Format("{0:N" + nbDecimales + "}", montant);
            // ReSharper restore FormatStringProblem
        }

        private static string FormatterMontant(Monnaie montant, int nbDecimales)
        {
            // ReSharper disable FormatStringProblem
            return string.Format("{0:N" + nbDecimales + "}", montant);
            // ReSharper restore FormatStringProblem
        }

        private static string FormatterMontantLectureSeule(decimal montant, int nbDecimales)
        {
            return Regex.Replace(string.Format("{0:C" + nbDecimales + "}", montant), @"\s*\$\s*", "");
        }

        // Permet d'obtenir la valeur décimale, peu importe le format utilisé (avec "-" ou parenthèses pour signe négatif)
        private static decimal ObtenirValeurDecimale(string texte)
        {
            if (string.IsNullOrEmpty(texte))
            {
                return 0;
            }
            return ConvertirTexteEnDecimal(texte);
        }

        private static decimal ConvertirTexteEnDecimal(string texte)
        {
            texte = texte.Replace(".", ",");
            return texte.StartsWith("(") ? decimal.Parse(texte, NumberStyles.Currency) : decimal.Parse(texte);
        }

        // Permet d'obtenir la valeur décimale, peu importe le format utilisé (avec "-" ou parenthèses pour signe négatif)
        private static decimal? ObtenirValeurDecimaleNullable(string texte)
        {
            if (string.IsNullOrEmpty(texte))
            {
                return null;
            }
            return ConvertirTexteEnDecimal(texte);
        }
    }
}