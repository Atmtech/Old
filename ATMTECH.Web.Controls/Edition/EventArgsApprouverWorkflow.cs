using System;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Event custom contenant la raison d'une approbation.
    /// </summary>
    public class EventArgsApprouverWorkflow : EventArgs
    {
        /// <summary>
        /// La raison de l'approbation.
        /// </summary>
        public String RaisonApprobation { get; set; }
    }
}
