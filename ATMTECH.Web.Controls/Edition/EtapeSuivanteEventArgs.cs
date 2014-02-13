using System.ComponentModel;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Argument de l'évênement OnEtapeSuivante du Wizard.
    /// </summary>
    public class EtapeSuivanteEventArgs : CancelEventArgs
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="EtapeSuivanteEventArgs"/>.
        /// </summary>
        /// <param name="userControlCourant">Le contrôle utilisateur de l'étape courante.</param>
        /// <param name="userControlSuivant">Le contrôle utilisateur de l'étape suivante.</param>
        public EtapeSuivanteEventArgs(ATMTECHUserControlBase userControlCourant,
                                      ATMTECHUserControlBase userControlSuivant)
        {
            _userControlCourant = userControlCourant;
            _userControlSuivant = userControlSuivant;
        }

        private readonly ATMTECHUserControlBase _userControlCourant;
        private readonly ATMTECHUserControlBase _userControlSuivant;

        /// <summary>
        /// Obtient le contrôle utilisateur de l'étape courante.
        /// </summary>
        /// <value>Le contrôle utilisateur de l'étape courante.</value>
        public ATMTECHUserControlBase UserControlCourant { get { return _userControlCourant; } }
        /// <summary>
        /// Obtient le contrôle utilisateur de l'étape suivante.
        /// </summary>
        /// <value>Le contrôle utilisateur de l'étape suivante.</value>
        public ATMTECHUserControlBase UserControlSuivant { get { return _userControlSuivant; } }
    }
}
