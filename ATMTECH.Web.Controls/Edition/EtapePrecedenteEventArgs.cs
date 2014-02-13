using System.ComponentModel;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Classe implémentant les évènements pour la l'étape précédente.
    /// </summary>
    public class EtapePrecedenteEventArgs :CancelEventArgs 
    {

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="EtapePrecedenteEventArgs"/>.
        /// </summary>
        /// <param name="userControlCourant">Le contrôle utilisateur de l'étape courante.</param>
        /// <param name="userControlPrecedente">Le contrôle utilisateur de l'étape précédante.</param>
        public EtapePrecedenteEventArgs(ATMTECHUserControlBase userControlCourant,
                                      ATMTECHUserControlBase userControlPrecedente)
        {
            _userControlCourant = userControlCourant;
            _userControlPrecedente = userControlPrecedente;
        }

        private readonly ATMTECHUserControlBase _userControlCourant;
        private readonly ATMTECHUserControlBase _userControlPrecedente;

        /// <summary>
        /// Obtient le contrôle utilisateur de l'étape courante.
        /// </summary>
        /// <value>Le contrôle utilisateur de l'étape courante.</value>
        public ATMTECHUserControlBase UserControlCourant { get { return _userControlCourant; } }

        /// <summary>
        /// Obtient le contrôle utilisateur de l'étape précédante.
        /// </summary>
        /// <value>Le contrôle utilisateur de l'étape précédante.</value>
        public ATMTECHUserControlBase UserControlPrecedente { get { return _userControlPrecedente; } }
    }
}
