using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities.DTO
{
    public class AffichageParticipantNourriture
    {
        public int IdNourritureParticipant { get; set; }
        public int IdParticipant { get; set; }
        public User Utilisateur { get; set; }
        public Nourriture Nourriture { get; set; }
        public Expedition Expedition { get; set; }
        public bool EstParticipantNourriture { get; set; }
    }
}
