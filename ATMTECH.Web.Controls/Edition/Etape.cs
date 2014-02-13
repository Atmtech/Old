using System.ComponentModel;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using ATMTECH.Web.Controls.Affichage;

namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// Classe implémentant les étapes.
    /// </summary>
    [ControlBuilder(typeof (OngletControlBuilder)), TypeConverter(typeof (ExpandableObjectConverter)),
     ParseChildren(true, "ContenuControl"),
     AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    public class Etape : OngletElement
    {
        /// <summary>
        /// Obtient ou affecte une valeur de/à EstReaccessible indiquant si l'étape est réaccessible.
        /// </summary>
        /// <value><c>vrai</c> si [est reaccessible]; sinon, <c>faux</c>.</value>
        public bool EstReaccessible { get; set; }

        /// <summary>
        /// Obtient ou affecte une valeur de/à TypeSequence
        /// </summary>
        /// <value>Le type de la séquence.</value>
        public EnumTypeSequence TypeSequence { get; set; }

        /// <summary>
        /// Obtient ou affecte une valeur de/au groupe de validation
        /// </summary>
        /// <value>Le groupe de validation.</value>
        public string GroupeValidation { get; set; }
    }
}