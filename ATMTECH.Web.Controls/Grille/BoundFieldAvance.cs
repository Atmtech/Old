using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATMTECH.Web.Controls.Grille
{
    /// <summary>
    /// Remplace le BoundField en permettant un DataField composé.
    /// </summary>
    public class BoundFieldAvance : ChampLieBase<BoundFieldAvance>
    {
        private readonly Literal _controlTotal = new Literal();

        public enum TypeTotal
        {
            Aucun,
            Auto,
            Manuel
        }

        private decimal? _total = 0;

        /// <summary>
        /// Aucun: (Valeur par défaut) Pas de total dans le bas de la colonne
        /// Auto: Calculer et afficher le total
        /// Manuel: Afficher le total mais ne pas le calculer. On peut utiliser GrilleAvance.AssignerTotal().
        /// </summary>
        public TypeTotal AffichageTotal { get; set; }

        protected override void InitialiserChamp()
        {
            _total = 0;
            _controlTotal.Text = string.Empty;
        }

        protected override void InitialiserPied(DataControlFieldCell cell)
        {
            if (AffichageTotal != TypeTotal.Aucun)
            {
                cell.Controls.Add(_controlTotal);
                MettreAJourTotal();
            }
            else
            {
                base.InitialiserPied(cell);
            }
        }

        private void MettreAJourTotal()
        {
            _controlTotal.Text = string.IsNullOrEmpty(DataFormatString)
                                     ? _total.ToString()
                                     : string.Format(DataFormatString, _total);
        }

        protected override object GetValue(Control controlContainer)
        {
            object valeur = DataField.Contains(".")
                       ? ObtenirValeurComposee(((GridViewRow) controlContainer).DataItem)
                       : base.GetValue(controlContainer);
            if (AffichageTotal == TypeTotal.Auto)
            {
                _total += Convert.ToDecimal(valeur);
            }
            return valeur;
        }

        internal void AssignerTotal(decimal? total)
        {
            _total = total;
            MettreAJourTotal();
        }

        private object ObtenirValeurComposee(object instance)
        {
            string[] proprietes = DataField.Split('.');
            foreach (string propriete in proprietes)
            {
                instance = instance.GetType().GetProperty(propriete).GetValue(instance, null);
                if (instance == null) return null;
            }
            return instance;
        }
    }
}
