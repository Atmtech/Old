using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Interfaces
{
    public interface IViewIdentifiant
    {
        /// <summary>
        /// L'id de la page ou du contrôle pour la sécurité
        /// </summary>
        string IdObjetSecurite { get; set; }

        /// <summary>
        /// L'id de la page ou du contrôle pour l'aide contextuelle
        /// </summary>
        string IdAideContextuelle { get; set; }
    }
}
