using System;
using ATMTECH.Entities;

namespace ATMTECH.Atorp.Entities
{
    [Serializable]
    public class Player : BaseEntity
    {
        public User User { get; set; }
        public string Pseudo { get; set; }
        public string Image { get; set; }
    }
}
