using System.Text.RegularExpressions;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Contrôle SIQ à utiliser obligatoirement au lieu du asp:TextBox normal
    /// pour tout champ restreint à un numéro de téléphone
    /// </summary>
    /// <code><![CDATA[
    /// Exemples d'utilisation:
    /// 
    /// <tr>
    ///     <ATMTECH:TelephoneTextBoxAvance runat="server" ID="id"  />
    /// </tr>
    /// ]]></code>
    public class TelephoneTextBoxAvance : AlphaNumTextBoxAvance
    {
        public TelephoneTextBoxAvance()
        {
            TypeSaisie = TypeDeChamp.Telephone;
        }

        public string ValeurNoTelephone 
        {
            get { return RetirerCaracteresSpeciauxNoTelephone(base.Text); }
        }

        private string RetirerCaracteresSpeciauxNoTelephone(string noTelephoneFormate)
        {
            const string caracteresNonNumeriques = "[^0-9]+";
            return Regex.Replace(noTelephoneFormate, caracteresNonNumeriques, string.Empty);
        }
    }
}