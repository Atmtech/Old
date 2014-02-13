using System;
using System.Web.UI.WebControls;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Contrôle SIQ à utiliser obligatoirement au lieu du asp:TextBox normal
    /// pour tout champ restreint à une adresse courriel.
    /// </summary>
    /// <code><![CDATA[
    /// Exemples d'utilisation:
    /// 
    /// <tr>
    ///     <ATMTECH:CourrielTextBoxAvance runat="server" ID="id"  />
    /// </tr>
    /// ]]></code>
    public class CourrielTextBoxAvance : TextBoxAvance
    {
        private readonly RegularExpressionValidator _expressionValidator;

        public CourrielTextBoxAvance()
        {
            _expressionValidator = new RegularExpressionValidator();
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            _expressionValidator.Enabled = true;
            _expressionValidator.ID = "CourrielExp";
            _expressionValidator.ValidationExpression = @"\b[A-Za-z0-9._%-]+@(?:[A-Za-z0-9-]+\.)+[A-Za-z]{2,4}\b";
            _expressionValidator.ControlToValidate = _textBox.ID;
            
            if (string.IsNullOrEmpty(NomChamp))
            {
                _expressionValidator.ToolTip = "Le format de l'adresse courriel est invalide";
                _expressionValidator.ErrorMessage = "Le format de l'adresse courriel est invalide";
            }
            else
            {
                string msg = String.Format("Le format du champ \"{0}\" est invalide.", NomChamp);
                _expressionValidator.ErrorMessage = msg;
                _expressionValidator.ToolTip = msg;
            }

            _expressionValidator.Display = ValidatorDisplay.Dynamic;
            EditionUtils.CreerIndicateurErreur(this, _expressionValidator);
            Controls.Add(_expressionValidator);
        }
    }
}