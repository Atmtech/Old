using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Web.UI.WebControls;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Contrôle SIQ à utiliser obligatoirement au lieu du asp:TextBox normal
    /// pour tout champ restreint à des caractères alpha numérique.
    /// </summary>
    /// <code><![CDATA[
    /// Exemples d'utilisation:
    /// 
    /// <tr>
    ///     <ATMTECH:AlphaNumTextBoxAvance runat="server" Libelle="Alpha Seul" TypeSaisie="Alpha" />
    /// </tr>
    /// <tr>
    ///     <ATMTECH:AlphaNumTextBoxAvance runat="server" Libelle="Num Seul" TypeSaisie="Numerique" />
    /// </tr>
    /// <tr>
    ///     <ATMTECH:AlphaNumTextBoxAvance runat="server" Libelle="Num Seul" TypeSaisie="Numerique" EstPrefixZero="true" />
    /// </tr>
    /// ]]></code>
    public class AlphaNumTextBoxAvance : TextBoxAvance
    {
        public enum TypeDeChamp
        {
            AlphaNumerique, Alpha, Decimal, Numerique, CodePostal, DecimalPositif, Telephone
        }

        public enum TypeDePrefixe
        {
            Aucun,
            /// <summary>
            /// Préfixer de "0" jusqu'à maxlength. La valeur zéro sera remplacée par un champ vide.
            /// </summary>
            ZeroSiDifferentDeZero,
            /// <summary>
            /// Préfixer de "0" jusqu'à maxlength. La valeur zéro est acceptée.
            /// </summary>
            ZeroSiNonVide
        }

        /// <summary>
        /// Retourne la valeur du champ en type natif int
        /// </summary>
        public int ValeurInt
        {
            get { return Int32.Parse(Text); }
            set { Text = value.ToString(); } 
        }

        public int? ValeurIntNullable
        {
            get { return string.IsNullOrWhiteSpace(Text) ? (int?) null : ValeurInt; }
            set
            {
                if (value == null)
                {
                    Text = string.Empty;
                }
                else
                {
                    ValeurInt = value.Value;
                }
            }
        }

        /// <summary>
        /// Retourne la valeur du champ en type natif decimal
        /// </summary>
        /// 
        public decimal ValeurDecimale
        {
            get { return InterpreterValeurDecimale(Text).GetValueOrDefault(); }
            set { AssignerValeurDecimale(value); }
        }

        public decimal? ValeurDecimaleNullable
        {
            get { return InterpreterValeurDecimale(Text); }
            set { AssignerValeurDecimale(value); }
        }


        private decimal? _valeurDecimale;

        private bool _estAssigneeValeurDecimale;
        
        private void AssignerValeurDecimale(decimal? valeur)
        {
            _valeurDecimale = valeur;
            _estAssigneeValeurDecimale = true;
            TransposerValeurDecimaleDansTexte();
        }
        
        private void TransposerValeurDecimaleDansTexte()
        {
            if (_estAssigneeValeurDecimale)
            {
                if (_valeurDecimale.HasValue)
                {
                    if (EstUnChampDecimal)
                    {
                        string format = "n" + NombreDecimaux;
                        base.Text = _valeurDecimale.Value.ToString(format, CultureInfo.CreateSpecificCulture("fr-CA"));
                    }
                    else
                    {
                        Text = _valeurDecimale.Value.ToString();
                    }
                }
                else
                {
                    base.Text = string.Empty;
                }
            }
        }

        private static decimal? InterpreterValeurDecimale(string texte)
        {
            return string.IsNullOrWhiteSpace(texte) ? (decimal?) null : decimal.Parse(texte.Replace(".", ","));
        }

        public override int? NombreEntiers
        {
            set
            {
                base.NombreEntiers = value;
                TransposerValeurDecimaleDansTexte();
            }
        }

        public override int? NombreDecimaux
        {
            set
            {
                base.NombreDecimaux = value;
                TransposerValeurDecimaleDansTexte();
            }
        }

        /// <summary>
        /// Gère le texte affiché dans le champ
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("Valeur du texte.")]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    base.Text = string.Empty;
                else if (EstUnChampDecimal)
                    ValeurDecimaleNullable = InterpreterValeurDecimale(value);
                else if (TypePrefixe != TypeDePrefixe.Aucun)
                    base.Text = FormaterAvecPrefixeZero(value);
                else
                    base.Text = value;
            }
        }

        private string FormaterAvecPrefixeZero(string value)
        {
            return value.PadLeft(MaxLength, '0');
        }

        /// <summary>
        /// Permet de déterminer le type de champ: Alpha, AlphaNumerique (par défaut), Decimal, Numerique...
        /// Remplace EstAlphaSeul, EstDecimalSeul, EstNumeriqueSeul
        /// </summary>
        public TypeDeChamp TypeSaisie { get; set; }

        /// <summary>
        /// Si vrai, prefixe le champ de 0 pour le remplir
        /// jusqu'à son maxLength
        /// </summary>
        [CategoryAttribute("Behavior")]
        [Description("Si vrai, prefixe le champ de 0 pour le remplir jusqu'à son maxLength")]
        public bool EstPrefixZero
        {
            get { return TypePrefixe == TypeDePrefixe.ZeroSiNonVide; }
            set { TypePrefixe = value ? TypeDePrefixe.ZeroSiNonVide : TypeDePrefixe.Aucun; }
        }

        public TypeDePrefixe TypePrefixe { get; set; }

        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.PreRender"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnPreRender(EventArgs e)
        {
            AjouterMasqueDeSaisie();
            base.OnPreRender(e);
        }

        /// <summary>
        /// Spécifie une classe CSS supplémentaire
        /// pour laquelle jQuery alphanumeric est
        /// liée.
        /// </summary>
        /// <returns></returns>
        protected void AjouterMasqueDeSaisie()
        {
            switch (TypeSaisie)
            {
                case TypeDeChamp.Alpha:
                    AjouterClasseCss("alphaTextBoxAvance");
                    break;
                case TypeDeChamp.AlphaNumerique:
                    AjouterClasseCss("alphaNumTextBoxAvance");
                    break;
                case TypeDeChamp.DecimalPositif:
                    AjouterClasseCss("positifSeul");
                    goto case TypeDeChamp.Decimal;
                case TypeDeChamp.Decimal:
                    AlignementParDefaut = TextAlign.Right;
                    AjouterClasseCss("decimalTextBoxAvance");
                    break;
                case TypeDeChamp.Numerique:
                    AlignementParDefaut = TextAlign.Right;
                    AjouterClasseCss("numTextBoxAvance");
                    break;
                case TypeDeChamp.CodePostal:
                    AjouterClasseCss("codePostalTextBox");
                    break;
                case TypeDeChamp.Telephone:
                    AjouterClasseCss("telephoneTextBox");
                    break;
            }

            switch(TypePrefixe)
            {
                case TypeDePrefixe.ZeroSiDifferentDeZero:
                    AjouterClasseCss("numZeroPrefixTextBoxAvance viderZero");
                    break;
                case TypeDePrefixe.ZeroSiNonVide:
                    AjouterClasseCss("numZeroPrefixTextBoxAvance");
                    break;
            }
        }

        /// <summary>
        /// Ce champ est considéré décimal si TypeSaisie="Decimal"
        /// </summary>
        protected override bool EstUnChampDecimal
        {
            get { return TypeSaisie == TypeDeChamp.Decimal || TypeSaisie == TypeDeChamp.DecimalPositif; }
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
                int i = -1;
                base.LoadViewState(tblValeurs[++i]);
                if (tblValeurs[++i] != null)
                {
                    TypeDeChamp type;
                    if(Enum.TryParse(tblValeurs[i].ToString(), out type))
                    {
                        TypeSaisie = type;
                    }
                }
                if (tblValeurs[++i] != null)
                {
                    TypeDePrefixe type;
                    if (Enum.TryParse(tblValeurs[i].ToString(), out type))
                    {
                        TypePrefixe = type;
                    }
                    
                }
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
            tblValeurs.Add(TypeSaisie);
            tblValeurs.Add(TypePrefixe);
            return tblValeurs;
        }
    }
}