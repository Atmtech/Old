using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTECH.Expeditn.Entities.DTO
{
    public class AffichageParticipantEtape
    {
        public int IdEtapeParticipant { get; set; }
        public int IdParticipant { get; set; }
        public Etape Etape { get; set; }
        public Expedition Expedition { get; set; }
        public string Nom { get; set; }
        public bool EstParticipantEtape { get; set; }
    }
}
