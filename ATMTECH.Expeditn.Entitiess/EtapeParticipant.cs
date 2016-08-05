using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class EtapeParticipant : BaseEntity
    {
        public const string ETAPE = "Etape";
        public Etape Etape { get; set; }
        public User User { get; set; }
    }
}
