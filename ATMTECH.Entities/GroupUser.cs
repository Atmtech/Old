using System;

namespace ATMTECH.Entities
{
    [Serializable]
    public class GroupUser : BaseEntity
    {
        public const string USER = "User";

        public Group Group { get; set; }
        public User User { get; set; }
    }
}
