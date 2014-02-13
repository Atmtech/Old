using System;

namespace ATMTECH.Entities
{
    [Serializable]
    public class Task : BaseEntity
    {
        public string Resolution { get; set; }
        public bool IsDone { get; set; }
    }
}
