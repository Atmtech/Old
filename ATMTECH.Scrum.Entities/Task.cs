using ATMTECH.Entities;

namespace ATMTECH.Scrum.Entities
{
    public class Task : BaseEntity
    {
        public const string STORY = "Story";

        public Story Story { get; set; }
        public decimal EstimateTime { get; set; }
        public decimal TimeDone { get; set; }
        public User User { get; set; }
    }
}
