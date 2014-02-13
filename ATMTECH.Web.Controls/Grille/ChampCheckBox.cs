using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Base;
using ATMTECH.Web.Controls.Edition;

namespace ATMTECH.Web.Controls.Grille
{
    public class ChampCheckBox : ChampEditable<ChampCheckBox, CheckBoxAvance, bool>
    {
        public Unit Width { get; set; }
        public string ContexteCoche { get; set; }
        public string ContexteVide { get; set; }

        public bool PermettreToutCocher { get; set; }

        protected override void InitializeCellStyle(DataControlFieldCell cell, DataControlCellType cellType)
        {
            if (cellType != DataControlCellType.Header)
                cell.HorizontalAlign = HorizontalAlign.Center;
        }

        protected override void InitializeHeaderCell(DataControlFieldCell cell)
        {
            if (PermettreToutCocher && Grille.ModeAffichage == ModeAffichage.Modification)
            {
                cell.Controls.Add(GenererToutCocher());
            }
            else
            {
                base.InitializeHeaderCell(cell);
            }
        }

        private Control GenererToutCocher()
        {
            Literal lit = new Literal();
            string id = "chkToutCocher" + Guid.NewGuid().ToString().Replace("-", "");
            string s = "<span class='toutCocher' title='Tout cocher/décocher'>";
            s += string.Format("<input type='checkbox' id='{0}' /><label for='{0}'>{1}</label></span>",
                id, HttpUtility.HtmlEncode(HeaderText));
            lit.Text = s;
            return lit;
        }

        protected override CheckBoxAvance CreerControle()
        {
            CheckBoxAvance checkBox =
                new CheckBoxAvance
                    {
                        NomChamp = HeaderText,
                        Width = this.Width,
                        ContexteCoche = this.ContexteCoche,
                        ContexteVide = this.ContexteVide
                    };
            return checkBox;
        }

        protected override bool ObtenirValeur(CheckBoxAvance controle)
        {
            return controle.Checked;
        }

        protected override void AssignerValeur(CheckBoxAvance controle, bool valeur)
        {
            controle.Checked = valeur;
        }

        protected override bool ObtenirValeurEntite(object entite, string nomChamp)
        {
            object valeur = DataBinder.GetPropertyValue(entite, nomChamp);
            if (valeur is byte)
            {
                return ((byte)valeur) == 1;
            }
            return (bool) valeur;
        }
    }
}