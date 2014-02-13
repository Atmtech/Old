using ATMTECH.Entities;

namespace ATMTECH.Achievement.Entities
{
    public class AccomplissementAppuyePar : BaseEntity
    {
        public AccomplissementUtilisateur AccomplissementUtilisateur { get; set; }
        public User Utilisateur { get; set; }

    }

}
