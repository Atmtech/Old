using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATMTECH.Web.Controls.Grille
{
    /// <summary>
    /// Colonne de sélection d'une grille. La norme UX demande que cette colonne
    /// soit la première colonne. La colonne consiste à une case à cocher qui 
    /// permet de sélectionner la ligne.
    /// 
    /// Si vous voulez afficher des données de type booléen à l'aide d'une case
    /// à cocher. Veuillez utiliser "CheckBoxField" à la place.
    /// </summary>
    public class ChampSelection : BoundField 
    {

        /// <summary>
        /// Obtient ou affecture une valeur de/à estMultiSelection.
        /// </summary>
        /// <value><c>Vrai</c> si [est multi selection]; sinon, <c>faux</c>.</value>
        public bool EstMultiSelection { get; set; }

        /// <summary>
        /// En cas de substitution dans une classe dérivée, crée un objet dérivé de <see cref="T:System.Web.UI.WebControls.DataControlField"/> vide.
        /// </summary>
        /// <returns>
        /// Objet dérivé de <see cref="T:System.Web.UI.WebControls.DataControlField"/> vide.
        /// </returns>
        protected override DataControlField CreateField()
        {
            return new ChampSelection();
        }


        /// <summary>
        /// Ajoute du texte ou des contrôles à la collection de contrôles d'une cellule.
        /// </summary>
        /// <param name="cell"><see cref="T:System.Web.UI.WebControls.DataControlFieldCell"/> qui contient le texte ou les contrôles du <see cref="T:System.Web.UI.WebControls.DataControlField"/>.</param>
        /// <param name="cellType">Une des valeurs de <see cref="T:System.Web.UI.WebControls.DataControlCellType"/>.</param>
        /// <param name="rowState">Une des valeurs <see cref="T:System.Web.UI.WebControls.DataControlRowState"/> spécifiant l'état de la ligne qui contient <see cref="T:System.Web.UI.WebControls.DataControlFieldCell"/>.</param>
        /// <param name="rowIndex">Index de la ligne contenant <see cref="T:System.Web.UI.WebControls.DataControlFieldCell"/>.</param>
        public override void InitializeCell(DataControlFieldCell cell, 
                                            DataControlCellType cellType,
                                            DataControlRowState rowState, 
                                            int rowIndex)
        {
            if(cellType == DataControlCellType.DataCell)
            {
                CheckBox chkSelection = new CheckBox();
                chkSelection.CssClass = "ChampSelection";

                if (!EstMultiSelection){
                   
                    chkSelection.Attributes.Add("onclick", "CheckOne(this)");
                }

                cell.Controls.Add(chkSelection);
            }
        }

        /// <summary>
        /// Évènement Databind du champs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        protected override void OnDataBindField(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            Control namingContainer = control.NamingContainer;
            object dataValue = GetValue(namingContainer);
            
            if(control is CheckBox && dataValue is bool)
            {
                CheckBox chk = (CheckBox) control;
                chk.Checked = Convert.ToBoolean(dataValue);
            }
        }

    }
}
