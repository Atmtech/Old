using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTECH.Tournoi.Entites
{
    public class Equipe
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public Saison Saison { get; set; }
    }
}
