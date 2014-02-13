using System;
using ATMTECH.Entities;

namespace ATMTECH.Atorp.Entities
{
    [Serializable]
    public class GamePlayer : BaseEntity
    {
        public Player Player { get; set; }
        public Game Game { get; set; }
    }
}
