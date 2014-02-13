using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATMTECH.Web.Controls.Base
{
    /// <summary>
    /// Classe implémentant les méthodes de webControl et TrouverControle
    /// </summary>
    public abstract class ATMTECHBaseControl : WebControl, ITrouveurControle
    {
        /// <summary>
        /// Méthode permettant d'obtenir la propriété d'un contrôle.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName">Le nom de la propriété.</param>
        /// <param name="nullValue">La valeur null.</param>
        /// <returns></returns>
        protected T GetProperty<T>(string propertyName, T nullValue)
        {
            return ViewState[propertyName] == null ? nullValue : (T) ViewState[propertyName];
        }

        /// <summary>
        /// Fixe une propriété.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName">Le nom de la propriété.</param>
        /// <param name="value">La valeur.</param>
        protected void SetProperty<T>(string propertyName, T value)
        {
            ViewState[propertyName] = value;
        }

        /// <summary>
        /// Recherche un contrôle serveur possédant le paramètre <paramref name="id"/> spécifié dans le conteneur de dénomination (naming container) en cours.
        /// </summary>
        /// <param name="id">Identificateur du contrôle à rechercher.</param>
        /// <returns>
        /// Contrôle spécifié, ou null s'il n'existe pas.
        /// </returns>
        public override Control FindControl(string id)
        {
            Control control = base.FindControl(id);
            if (control != null)
            {
                return control;
            }
            for (Control container = NamingContainer; container != null; container = container.NamingContainer)
            {
                control = container.FindControl(id);
                if (control != null)
                {
                    return control;
                }
            }

            return null;
        }

        /// <summary>
        /// Retrouver un contrôle par son ID.
        /// </summary>
        /// <param name="id">L'id du contrôle.</param>
        /// <returns></returns>
        public Control RetrouverControle(string id)
        {
            return FindControl(id);
        }
    }
}