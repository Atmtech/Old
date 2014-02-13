using ATMTECH.Entities;

namespace ATMTECH.Atorp.Entities
{
    public class Event : BaseEntity
    {
        public Game Game { get; set; }
        public string Name { get; set; }
        public bool IsActivated { get; set; }
        
    }
}
