using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTECH.Tournoi.Entites
{
    public class MatchSaison
    {
        public int Id { get; set; }

        public Saison Saison { get; set; }
        public DateTime Date { get; set; }
        public Equipe Local { get; set; }
        public Equipe Visiteur { get; set; }
        public Equipe Gagnant { get; set; }
        public Equipe Perdant { get; set; }
        public int NombreButGagnant { get; set; }
        public int NombreButPerdant { get; set; }
        public int NombrePointGagnant { get; set; }
        public int NombrePointPerdant { get; set; }

        public int PerteEnSurtemps { get; set; }
        public int NombreButVisiteur { get; set; }

        public int NombreButLocal { get; set; }

        public string Message { get; set; }

    }
}
