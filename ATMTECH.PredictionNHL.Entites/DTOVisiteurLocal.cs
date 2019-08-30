using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTECH.PredictionNHL.Entites
{
    public class DTOVisiteurLocal
    {
        public int GamePrimaryKey { get; set; }
        public string Date { get; set; }
        public string NomEquipeVisiteur { get; set; }
        public string NomEquipeLocal { get; set; }

        public int PointageLocal { get; set; }
        public int PointageVisiteur { get; set; }

        public int PredictionPointageLocal { get; set; }
        public int PredictionPointageVisiteur { get; set; }

        public bool EstDejaPredit
        {
            get; set;
        }
    }
}
