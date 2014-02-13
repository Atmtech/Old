using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Scrum.Entities
{
    public partial class Story : BaseEntity
    {
        public const string PRODUCT = "Product";
        public const string SPRINT = "Sprint";
        public const string PRIORITY = "Priority";

        public Product Product { get; set; }
        public string Comment { get; set; }
        public int Point { get; set; }
        public Sprint Sprint { get; set; }
        public string Status { get; set; }
        public int? Priority { get; set; }
        public IList<Task> Tasks { get; set; }
    }
}
