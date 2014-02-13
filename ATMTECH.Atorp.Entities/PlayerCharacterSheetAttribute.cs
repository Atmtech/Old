using ATMTECH.Entities;

namespace ATMTECH.Atorp.Entities
{
    public class PlayerCharacterSheetAttribute : BaseEntity
    {
        public PlayerCharacterSheet PlayerCharacterSheet { get; set; }
        public string Attribute { get; set; }
        public string Value { get; set; }
    }
}
