using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Interfaces
{
    public interface IControleAvecModeAffichage
    {
        /// <summary>
        /// Permet d'obtenir le mode d'affichage du contrôle, sans aller voir dans les parents.
        /// </summary>
        ModeAffichage ModeAffichageControle { get; }

        /// <summary>
        /// Permet d'obtenir le mode d'affichage du contrôle, en remontant aux parents au besoin.
        /// Permet d'assigner le mode d'affichage.
        /// </summary>
        ModeAffichage ModeAffichage { get; set; }
    }
}
