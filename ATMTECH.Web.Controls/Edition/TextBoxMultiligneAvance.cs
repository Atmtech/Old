using System;
using System.Web.UI.WebControls;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Text box avec plusieurs ligne (textarea)
    /// </summary>
    public class TextBoxMultiligneAvance : TextBoxAvance
    {
        public bool ConvertirSautsDeLigneEnModeConsultation
        {
            get { return ConvertirSautsDeLigne; }
            set { ConvertirSautsDeLigne = value; }
        }

        /// <summary>
        /// Nombre de lignes de la boîte de texte.
        /// Peut être utilisé à la place de Height pour contrôler le nombre de lignes.
        /// </summary>
        public int Rows
        {
            get { return _textBox.Rows; }
            set { _textBox.Rows = value;  }
        }

        /// <summary>
        /// </summary>
        public TextBoxMultiligneAvance()
        {
            _textBox.TextMode = TextBoxMode.MultiLine;
        }

        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.PreRender"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            // Pour jQuery
            AjouterClasseCss("multiLigneTextBoxAvance");
        }
    }
}
