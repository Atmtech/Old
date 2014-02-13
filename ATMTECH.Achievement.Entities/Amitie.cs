using ATMTECH.Entities;

namespace ATMTECH.Achievement.Entities
{
    public class Amitie : BaseEntity
    {
        public User Utilisateur { get; set; }
        public User Ami { get; set; }
        public bool EstConfirme { get; set; }
    }
}
