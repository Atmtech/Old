using ATMTECH.Entities;

namespace ATMTECH.Achievement.Entities
{
    public class Jaime : BaseEntity
    {
        public const string DISCUSSION = "Discussion";
        public const string DISCUSSION_REPONSE = "DiscussionReponse";

        public Discussion Discussion { get; set; }
        public DiscussionReponse DiscussionReponse { get; set; }
        public User Utilisateur { get; set; }

    }
}
