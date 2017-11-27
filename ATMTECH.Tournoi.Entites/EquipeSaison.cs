using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTECH.Tournoi.Entites
{
   public class EquipeSaison
    {
        public Saison Saison { get; set; }
        public Equipe Equipe { get; set; }
        public string NomEquipe { get { return Equipe.Nom; } }
        public string IdEquipe { get { return Equipe.Id.ToString(); } }
        public int NombrePartieJoue { get; set; }
        public int NombreVictoire { get; set; }
        public int NombreDefaite { get; set; }

        public bool EstPresentAujourdhui { get; set; }
        public int NombreDefaiteEnSurTemps { get; set; }

        public int NombreButPour { get; set; }
        public int NombreButContre { get; set; }
        public string PourcentageVictoire { get; set; }
        public int NombrePoint { get; set; }
    }
}
