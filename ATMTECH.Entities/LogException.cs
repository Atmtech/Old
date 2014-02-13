using System;

namespace ATMTECH.Entities
{
    [Serializable]
    public class LogException : BaseEntity
    {
        public string InnerId { get; set; }
        public User User { get; set; }
        public string Page { get; set; }
        public string StackTrace { get; set; }
    }
}
