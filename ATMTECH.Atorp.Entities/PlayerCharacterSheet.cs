using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATMTECH.Entities;

namespace ATMTECH.Atorp.Entities
{
    [Serializable]
    public class PlayerCharacterSheet : BaseEntity
    {
        public Player Player { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; }
        public TemplateCharacterSheet TemplateCharacterSheet { get; set; }
    }
}
