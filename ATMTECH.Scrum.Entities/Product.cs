using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Scrum.Entities
{
    public partial class Product : BaseEntity   
    {
        public User ProductOwner { get; set; }
        public IList<Story> Storys { get; set; }
        public IList<Sprint> Sprints { get; set; }
    }
}
