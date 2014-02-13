using System;

namespace ATMTECH.Web.Controls.Base
{
    /// <summary>
    /// Identifie une propriété d'un control qui hérite de ATMTECHScriptBaseControl 
    /// qu'elle doit se retrouver aussi dans la version client.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ATMTECHScriptPropertyAttribute : Attribute
    {
        private readonly string _nomProprieteClient;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ATMTECHScriptPropertyAttribute"/>.
        /// </summary>
        /// <param name="nomProprieteClient">Le nom de la propriété du client.</param>
        public ATMTECHScriptPropertyAttribute(string nomProprieteClient)
        {
            _nomProprieteClient = nomProprieteClient;
        }

        /// <summary>
        /// Obtient le nom de la propriété du client
        /// </summary>
        /// <value>The nom propriete client.</value>
        public string NomProprieteClient
        {
            get { return _nomProprieteClient; }
        }
    }
}