using System;
using ATMTECH.Entities;

namespace ATMTECH.Atorp.Entities
{
    [Serializable]
    public class Game : BaseEntity
    {
        public User Master { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
    }
}
