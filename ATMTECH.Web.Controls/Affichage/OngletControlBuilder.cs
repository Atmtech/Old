using System;
using System.Collections;
using System.Web.UI;

namespace ATMTECH.Web.Controls.Affichage
{
    /// <summary>
    /// Constructeur des contrôles enfants pour le control ATMTECHOnglets.
    /// </summary>
    public class OngletControlBuilder : ControlBuilder
    {
        /// <summary>
        /// Obtient le <see cref="T:System.Type"/> du type de contrôle qui correspond à une balise enfant. Cette méthode est appelée par l'infrastructure de page ASP.NET.
        /// </summary>
        /// <param name="tagName">Nom de la balise de l'enfant.</param>
        /// <param name="attribs">Tableau des attributs contenus dans le contrôle enfant.</param>
        /// <returns>
        /// 	<see cref="T:System.Type"/> de l'enfant du contrôle spécifié.
        /// </returns>
        public override Type GetChildControlType(string tagName, IDictionary attribs)
        {
            return string.Compare(OngletElement.TAG, tagName) == 0 ? typeof (OngletElement) : null;
        }
    }
}