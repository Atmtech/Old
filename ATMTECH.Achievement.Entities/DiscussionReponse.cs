using ATMTECH.Entities;

namespace ATMTECH.Achievement.Entities
{
    public class DiscussionReponse : BaseEntity
    {
        public const string DISCUSSION = "Discussion";

        public Discussion Discussion { get; set; }
        public User Utilisateur { get; set; }
    }
}
