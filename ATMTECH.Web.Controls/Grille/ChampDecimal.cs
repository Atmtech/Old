using System;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Base;
using ATMTECH.Web.Controls.Edition;
using TypeDeChamp = ATMTECH.Web.Controls.Edition.AlphaNumTextBoxAvance.TypeDeChamp;

namespace ATMTECH.Web.Controls.Grille
{
    public class ChampDecimal : ChampEditable<ChampDecimal, AlphaNumTextBoxAvance, decimal?>
    {
        private decimal _total;

        private readonly AlphaNumTextBoxAvance _txtFooter = new AlphaNumTextBoxAvance
                                                                {
                                                                    ModeAffichage = ModeAffichage.Consultation,
                                                                    TypeSaisie = TypeDeChamp.Decimal,
                                                                    NombreEntiers = 12
                                                                };

        public int NombreEntiers { get; set; }
        public int NombreDecimaux { get; set; }
        public bool EstSeulementPositif { get; set; }
        public bool EstObligatoire { get; set; }
        public string ValidationRegExp { get; set; }
        public string ValidationRegExpMessage { get; set; }
        public bool AfficherTotal { get; set; }
        public Unit Width { get; set; }

        protected override void InitializeCellStyle(DataControlFieldCell cell, DataControlCellType cellType)
        {
            if (cellType != DataControlCellType.Header)
                cell.HorizontalAlign = HorizontalAlign.Right;
        }

        protected override AlphaNumTextBoxAvance CreerControle()
        {
            AlphaNumTextBoxAvance textBox =
                new AlphaNumTextBoxAvance
                    {
                        NombreEntiers = this.NombreEntiers,
                        NombreDecimaux = this.NombreDecimaux,
                        TypeSaisie = EstSeulementPositif ? TypeDeChamp.DecimalPositif : TypeDeChamp.Decimal,
                        ValidationRegExp = this.ValidationRegExp,
                        ValidationRegExpMessage = this.ValidationRegExpMessage,
                        EstObligatoire = this.EstObligatoire,
                        NomChamp = HeaderText,
                        Width = this.Width
                    };
            if (AfficherTotal)
            {
                textBox.PreRender += textBox_PreRender;
            }
            return textBox;
        }

        protected override void InitializeFooterCell(DataControlFieldCell cell)
        {
            if (AfficherTotal)
                cell.Controls.Add(_txtFooter);
            else
                base.InitializeFooterCell(cell);
        }

        protected override decimal? ObtenirValeur(AlphaNumTextBoxAvance controle)
        {
            if (string.IsNullOrWhiteSpace(controle.Text))
                return null;

            return controle.ValeurDecimale;
        }

        protected override void AssignerValeur(AlphaNumTextBoxAvance controle, decimal? valeur)
        {
            if (valeur == null)
                controle.Text = string.Empty;
            else
                controle.ValeurDecimale = (decimal) valeur;
        }

        private void textBox_PreRender(object sender, EventArgs e)
        {
            AlphaNumTextBoxAvance textBox = (AlphaNumTextBoxAvance) sender;
            _total += textBox.ValeurDecimale;
            _txtFooter.NombreDecimaux = NombreDecimaux;
            _txtFooter.ValeurDecimale = _total;
        }
    }
}