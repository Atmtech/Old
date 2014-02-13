using System;
using System.Reflection;
using System.Security.Permissions;
using System.Web;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Grille
{
    /// <summary>
    /// Composante qui remplace les colonnes de type BoundField dans la grille.
    /// Cette composante effectue des liaisons de données intelligentes pour les
    /// propriétés de type BaseEnumeration. Lorsque la colonne détecte quel est lié à ce 
    /// type de donnée, elle se chargera elle même de récupérer la valeur de la 
    /// description de l'enum via le service de cache. Ceci afin d'améliorer la 
    /// performance de l'application.
    /// </summary>
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    public class ChampDonneeAvance : BoundField
    {
        /// <summary>
        /// Cette constante est le préfix qui sera vérifié pour déterminer
        /// si le DataField est un Enum. 
        /// </summary>
        protected const string PREFIX_ENUM = "Enum";

        /// <summary>
        /// Crée un objet ChampDonneeAvance vide
        /// </summary>
        /// <returns>ChampDonneeAvance vide</returns>
        protected override DataControlField CreateField()
        {
            return new ChampDonneeAvance();
        }

        /// <summary>
        /// Met en forme la valeur de champ spécifiée pour une cellule dans l'objet <see cref="T:System.Web.UI.WebControls.BoundField"/>.
        /// </summary>
        /// <param name="dataValue">Valeur de champ à mettre en forme.</param>
        /// <param name="encode">true pour coder la valeur ; sinon, false.</param>
        /// <returns>
        /// Valeur de champ convertie au format spécifié par <see cref="P:System.Web.UI.WebControls.BoundField.DataFormatString"/>.
        /// </returns>
        protected override string FormatDataValue(object dataValue, bool encode)
        {
            if (dataValue == null)
                return NullDisplayText;
          
            Type dataType = dataValue.GetType();

            object dataValue2 = dataType.Name.StartsWith(PREFIX_ENUM) ? ObtenirDescriptionViaCache(dataValue) : dataValue;

            return base.FormatDataValue(dataValue2, encode);
        }

        /// <summary>
        /// Obtenir la description d'un enum via la cache
        /// </summary>
        /// <param name="dataValue">La valeur de la donnée.</param>
        /// <returns></returns>
        protected object ObtenirDescriptionViaCache(object dataValue)
        {
            //Obtenir le code de l'enum
            PropertyInfo pi = dataValue.GetType().GetProperty("Code");
            //Obtenir l'enum correspondant au code récupéré plus haut.
            object enumValue = ObtenirEnum(pi.GetValue(dataValue,null).ToString(),dataValue.GetType());
            if(enumValue == null)
                return null;
            //Avec l'enum reçu, retourner la description.
            PropertyInfo pi2 = enumValue.GetType().GetProperty("Description");
            return pi2.GetValue(enumValue,null);
        }

        private object ObtenirEnum(string code, Type typeEnum)
        {
            GrilleAvance grille = Control.NamingContainer as GrilleAvance;
            if(grille == null)
                return null;

            object presenter = grille.Parent.ObtenirPresenter();

            if(presenter == null)
                return null;

            MethodInfo mi = presenter.GetType().GetMethod("ObtenirValeurEnumParCode").MakeGenericMethod(typeEnum);
            return mi.Invoke(presenter, new object[] {code});
        }
    }
}
