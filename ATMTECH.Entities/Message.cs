using System;

namespace ATMTECH.Entities
{
    [Serializable]
    public partial class Message : BaseEntity
    {
        public const string INNERID = "InnerId";

        public const string MESSAGE_TYPE_SUCCESS = "Success";
        public const string MESSAGE_TYPE_ERROR = "Error";

        public string MessageType { get; set; }
        public string InnerId { get; set; }
    }
}
