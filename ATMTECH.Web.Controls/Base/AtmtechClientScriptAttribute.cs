using System;

namespace ATMTECH.Web.Controls.Base
{
    /// <summary>
    /// Attribut qui définit le typage de l'objet client et le chemin d'accès 
    /// du fichier ressource qui le définit.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ATMTECHClientScriptAttribute : Attribute
    {
        private readonly string _typeObjetClient;
        private readonly string _cheminAccesRessourceClient;

        /// <summary>
        /// Obtient le type d'objet du client
        /// </summary>
        /// <value>Le type d'objet du client.</value>
        public string TypeObjetClient
        {
            get { return _typeObjetClient; }
        }

        /// <summary>
        /// Obtient le chemin d'accès pour la ressource côté client.
        /// </summary>
        /// <value>Le chemin d'accès pour la ressource.</value>
        public string CheminAccesRessourceClient
        {
            get { return _cheminAccesRessourceClient; }
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ATMTECHClientScriptAttribute"/>.
        /// </summary>
        /// <param name="typeObjetClient">Le type d'objet du client.</param>
        /// <param name="cheminAccesRessourceClient">Le chemin d'accès à la ressource du client.</param>
        public ATMTECHClientScriptAttribute(string typeObjetClient, string cheminAccesRessourceClient)
        {
            _typeObjetClient = typeObjetClient;
            _cheminAccesRessourceClient = cheminAccesRessourceClient;
        }
    }
}