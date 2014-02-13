using System;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// 
    /// </summary>
    public class EtapeTermineEventArgs : EventArgs 
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="EtapeTermineEventArgs"/>.
        /// </summary>
        /// <param name="userControlCourant">Le contrôle courant.</param>
        public EtapeTermineEventArgs(ATMTECHUserControlBase userControlCourant)
        {
            _userControlCourant = userControlCourant;
           
        }

        private readonly ATMTECHUserControlBase _userControlCourant;
        /// <summary>
        /// Obtenir le contrôle courant.
        /// </summary>
        /// <value>Le contrôle courant.</value>
        public ATMTECHUserControlBase UserControlCourant { get { return _userControlCourant; } }
    }
}
