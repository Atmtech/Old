using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Exception;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Grille
{
    // Inspiration: http://www.codeproject.com/Articles/13629/How-to-create-custom-bound-fields-in-GridView
    public abstract class ChampEditable<TChamp, TControle, TValeur> : DataControlField
        where TChamp : DataControlField, new()
        where TControle : ControleBase
    {
        public string DataField { get; set; }
        public string Id { get; set; }

        private GrilleAvance _grilleParent;

        protected GrilleAvance Grille
        {
            get { return _grilleParent; }
        }

        protected abstract TControle CreerControle();

        protected abstract TValeur ObtenirValeur(TControle controle);
        protected abstract void AssignerValeur(TControle controle, TValeur valeur);

        protected override DataControlField CreateField()
        {
            return new TChamp();
        }

        public override bool Initialize(bool enableSorting, Control control)
        {
            _grilleParent = control.Parent as GrilleAvance;
            if (_grilleParent == null || _grilleParent.DataKeyNames.Count() != 1)
            {
                const string msg = "Un type de colonne éditable ne peut être utilisé que dans une GrilleAvance liée"
                                   + " à un objet contenant une clé unique renseignée par la propriété 'DataKeyNames'.";
                throw new BaseException(msg);
            }
            return base.Initialize(enableSorting, control);
        }

        public override void InitializeCell(DataControlFieldCell cell, DataControlCellType cellType,
                                            DataControlRowState rowState, int rowIndex)
        {
            InitializeCellStyle(cell, cellType);
            switch (cellType)
            {
                case DataControlCellType.Header:
                    InitializeHeaderCell(cell);
                    break;
                case DataControlCellType.Footer:
                    InitializeFooterCell(cell);
                    break;
                case DataControlCellType.DataCell:
                    InitializeDataCell(cell, cellType, rowState, rowIndex);
                    break;
            }
        }

        protected virtual void InitializeCellStyle(DataControlFieldCell cell, DataControlCellType cellType)
        {
        }

        protected virtual void InitializeHeaderCell(DataControlFieldCell cell)
        {
            cell.Text = HeaderText;
        }

        protected virtual void InitializeFooterCell(DataControlFieldCell cell)
        {
            cell.Text = FooterText;
        }

        public override void ExtractValuesFromCell(IOrderedDictionary dictionary, DataControlFieldCell cell,
                                                   DataControlRowState rowState, bool includeReadOnly)
        {
            dictionary[DataField] = ObtenirValeur(ObtenirControle(cell));
        }

        protected TControle ObtenirControle(DataControlFieldCell cellule)
        {
            return (TControle) cellule.Controls[0];
        }

        protected void InitializeDataCell(DataControlFieldCell cell, DataControlCellType cellType,
                                          DataControlRowState rowState, int rowIndex)
        {
            ControleBase ctl = CreerControle();
            ctl.ID = Id;
            ctl.Load += ctl_Load;
            ctl.DataBinding += ctl_DataBinding;
            cell.Controls.Add(ctl);
        }

        private void ctl_Load(object sender, EventArgs e)
        {
            ControleBase ctl = (ControleBase) sender;
            if (Control.Page.IsPostBack)
            {
                if (ctl.IdentifiantRangee != null)
                {
                    CorrigerIdControle(ctl);
                }
            }
        }

        private void ctl_DataBinding(object sender, EventArgs e)
        {
            TControle ctl = (TControle) sender;
            Control container = ctl.DataItemContainer;
            object dataItem = DataBinder.GetDataItem(container);
            TValeur dataFieldValue = ObtenirValeurEntite(dataItem, this.DataField);
            AssignerValeur(ctl, dataFieldValue);

            object identifiant = DataBinder.GetPropertyValue(dataItem, _grilleParent.DataKeyNames[0]);
            if (identifiant == null)
            {
                throw new BaseException(
                    "Identifiant null trouvé sur l'objet. Vérifiez la propriété 'DataKeyNames'.");
            }
            ctl.IdentifiantRangee = identifiant.ToString();
            CorrigerIdControle(ctl);
        }

        protected virtual TValeur ObtenirValeurEntite(object entite, string nomChamp)
        {
            return (TValeur) DataBinder.GetPropertyValue(entite, nomChamp);
        }

        private void CorrigerIdControle(ControleBase controle)
        {
            if (controle.ID == Id)
                controle.ID = Id + "_" + controle.IdentifiantRangee.Replace("-", "m");
        }
    }
}