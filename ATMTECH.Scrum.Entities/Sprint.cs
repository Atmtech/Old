using System;
using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Scrum.Entities
{
    public partial class Sprint : BaseEntity
    {
        public const string PRODUCT = "Product";
        public const string START = "Start";

        public Product Product { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public IList<Story> Storys { get; set; }
    }
}
