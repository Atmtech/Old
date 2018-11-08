using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTECH.StockGame.Entites
{
    public class Classement
    {
        public string Nom { get; set; }
        public int Rang { get; set; }
        public decimal Solde { get; set; }
        public decimal SoldeAction { get; set; }
    }
}
