using System;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Event custom contenant la raison d'un rejet.
    /// </summary>
    public class EventArgsRefuserWorkflow : EventArgs
    {
        /// <summary>
        /// La raison du rejet.
        /// </summary>
        public String RaisonRefus { get; set; }
    }

}
