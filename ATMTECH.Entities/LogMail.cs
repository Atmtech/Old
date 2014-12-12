using System;

namespace ATMTECH.Entities
{
    [Serializable]
    public class LogMail : BaseEntity
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
