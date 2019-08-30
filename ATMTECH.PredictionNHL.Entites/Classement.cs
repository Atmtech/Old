using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTECH.PredictionNHL.Entites
{
    public class Classement
    {
        public Utilisateur Utilisateur { get; set; }
        public int Pointage { get; set; }

        public int NombreVictoire { get; set; }
        public int NombreEchec { get; set; }
        public decimal Pourcentage
        {
            get
            {
                if (NombreTotalPrediction > 0 )
                {
                    var test = Convert.ToDecimal(NombreVictoire) / Convert.ToDecimal(NombreTotalPrediction);
                    return test;
                }
                    
                return 0;
            }
        }

        public int NombreTotalPrediction { get; set; }
    }
}
