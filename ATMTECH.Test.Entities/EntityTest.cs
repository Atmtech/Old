using System;
using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Test.Entities
{
    public class EntityTest: BaseEntity
    {
        public EntityTestSon EntityTestSon { get; set; }
        public IList<EntityTestSon> TestingIlist { get; set; }
        public string A { get; set; }
        public int B { get; set; }
        public bool C { get; set; }
        public decimal D { get; set; }
        public DateTime E { get; set; }
        public Order Order { get; set; }
    }
}
