using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class Voyage : BaseEntity
    {
        public Emplacement Emplacement { get; set; }
        //public Utilisateur ChefGroupe { get; set; }
        public IList<Utilisateur> Participants { get; set; }
    }
}
