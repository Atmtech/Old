using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Grille
{
    public abstract class ChampLieBase<TChamp> : BoundField
        where TChamp : ChampLieBase<TChamp>, new()
    {
        private GrilleAvance _grilleParent;

        protected GrilleAvance Grille
        {
            get { return _grilleParent; }
        }

        protected override DataControlField CreateField()
        {
            return new TChamp();
        }

        public override bool Initialize(bool enableSorting, Control control)
        {
            _grilleParent = control.Parent as GrilleAvance;
            InitialiserChamp();
            return base.Initialize(enableSorting, control);
        }

        protected virtual void InitialiserChamp()
        {
        }

        public override void InitializeCell(DataControlFieldCell cell, DataControlCellType cellType,
                                            DataControlRowState rowState, int rowIndex)
        {
            InitialiserStyleCellule(cell, cellType);
            switch (cellType)
            {
                case DataControlCellType.Header:
                    InitialiserEnTete(cell);
                    break;
                case DataControlCellType.Footer:
                    InitialiserPied(cell);
                    break;
                case DataControlCellType.DataCell:
                    InitialiserCellule(cell, cellType, rowState, rowIndex);
                    break;
            }
        }

        protected virtual void InitialiserStyleCellule(DataControlFieldCell cell, DataControlCellType cellType)
        {
        }

        protected virtual void InitialiserEnTete(DataControlFieldCell cell)
        {
            cell.Text = HeaderText;
        }

        protected virtual void InitialiserPied(DataControlFieldCell cell)
        {
            cell.Text = FooterText;
        }

        protected virtual void InitialiserCellule(
            DataControlFieldCell cell, DataControlCellType cellType, DataControlRowState rowState, int rowIndex)
        {
            base.InitializeDataCell(cell, rowState);
        }
    }
}