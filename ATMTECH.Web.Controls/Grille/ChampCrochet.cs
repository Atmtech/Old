using System;
using System.Web.UI.WebControls;
using ATMTECH.Exception;

namespace ATMTECH.Web.Controls.Grille
{
    /// <summary>
    /// Type de colonne à lier à un booléen et qui affiche un crochet si celui-ci est vrai, ou rien si faux.
    /// </summary>
    public class ChampCrochet : BoundField
    {
        protected override DataControlField CreateField()
        {
            return new ChampCrochet();
        }

        public override void InitializeCell(DataControlFieldCell cell, DataControlCellType cellType, DataControlRowState rowState, int rowIndex)
        {
            ItemStyle.CssClass = "crochet";
            base.InitializeCell(cell, cellType, rowState, rowIndex);
        }


        protected override string FormatDataValue(object dataValue, bool encode)
        {
            bool estVrai = false;
            if (dataValue != null)
            {
                if (dataValue is bool)
                    estVrai = Convert.ToBoolean(dataValue);
                else if (dataValue is byte)
                    estVrai = Convert.ToByte(dataValue) == 1;
                else
                    throw new BaseException("ChampCrochet doit être lié à une valeur bool ou byte.");

            }
            return estVrai ? "&#x2713;" : NullDisplayText;
        }
    }
}
