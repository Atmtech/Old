using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Achievement.Entities
{
    public class Discussion : BaseEntity
    {
        public const string UTILISATEUR = "Utilisateur";

        public User Utilisateur { get; set; }
        public IList<DiscussionReponse> ListeDiscussionReponse { get; set; }

        public IList<Jaime> ListeJaime { get; set; }
    }

}
