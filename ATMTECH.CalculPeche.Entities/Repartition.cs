namespace ATMTECH.CalculPeche.Entities
{
    public class Repartition
    {
        public string Nom { get; set; }
        
        public double NombreRepas { get; set; }
        public double NombrePresence { get; set; }
        public double NombreBateau { get; set; }
        public double NombreAutomobile { get; set; }

        public double NombreTotalEvenement { get
        {
            return NombreRepas + NombrePresence + NombreBateau + NombreAutomobile;
        } }
        
        public double PourcentageRepas { get; set; }
        public double PourcentageAutomobile { get; set; }
        public double PourcentageBateau { get; set; }
        public double PourcentagePropane { get; set; }

        public int NombreTotalJour { get; set; }
        public int NombreTotalRepas { get; set; }
        public int NombreTotalSortieBateau { get; set; }
        public int NombreTotalAutomobile { get; set; }

        public double TotalRepas { get; set; }
        public double TotalAutomobile { get; set; }
        public double TotalBateau { get; set; }
        public double TotalPropane { get; set; }
        
        public double GrandTotal
        {
            get
            {
                return TotalAutomobile + TotalBateau + TotalPropane + TotalRepas;
            }
        }
    }
}
