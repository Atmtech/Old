using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class Mail : BaseEntity
    {
        public const string PLAYER_TO = "PlayerTo";
        public const string PLAYER_FROM = "PlayerFrom";
        public const string IS_UNREAD = "IsUnRead";


        public Player PlayerTo { get; set; }
        public Player PlayerFrom { get; set; }
        public string MailPost { get; set; }
        public bool IsUnRead { get; set; }
    }
}
