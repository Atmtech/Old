using System.Web.UI.WebControls;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Pour les boutons dont le BorderWidth doit être différent de zéro.
    /// </summary>
    public class ImageButtonAvance : ImageButton
    {
        /// <summary>
        /// Réparer un bug qui fait que de base le langage rajoute un border-width:0px pour toute les images ! 
        /// </summary>
        public override Unit BorderWidth
        {
            get {
                return base.BorderWidth.IsEmpty ? Unit.Pixel(0) : base.BorderWidth;
            }
            set { base.BorderWidth = value; }
        }
    }
}