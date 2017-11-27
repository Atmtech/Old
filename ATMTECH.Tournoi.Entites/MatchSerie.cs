using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTECH.Tournoi.Entites
{
    public class MatchSerie
    {
        public int Id { get; set; }

        public Serie Serie { get; set; }
        public Equipe Local { get; set; }
        public Equipe Visiteur { get; set; }
        public int NombreButLocalMatch1 { get; set; }
        public int NombreButLocalMatch2 { get; set; }
        public int NombreButLocalMatch3 { get; set; }
        public int NombreButVisiteurMatch1 { get; set; }
        public int NombreButVisiteurMatch2 { get; set; }
        public int NombreButVisiteurMatch3 { get; set; }
        

        public string Message { get; set; }

        public int Ronde { get; set; }
    }
}
