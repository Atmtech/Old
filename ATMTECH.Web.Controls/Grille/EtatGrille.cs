using System.Web.UI.WebControls;

namespace ATMTECH.Web.Controls.Grille
{
    /// <summary>
    /// Permet d'enregistrer l'état de la grille.
    /// </summary>
    internal class EtatGrille
    {
        internal int PageIndex { get; set; }
        internal string SortExpression { get; set; }
        internal object ValeurSelectionnee { get; set; }
        internal SortDirection SortDirection { get; set; }

        public EtatGrille(GridView grille, object valeurSelectionnee)
        {
            PageIndex = grille.PageIndex;
            SortExpression = grille.SortExpression;
            this.SortDirection = grille.SortDirection;
            ValeurSelectionnee = valeurSelectionnee;
        }
    }
}
