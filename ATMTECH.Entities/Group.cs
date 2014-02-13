using System;

namespace ATMTECH.Entities
{
    [Serializable]
    public class Group : BaseEntity
    {
        public string Name { get; set; }

        public string SearchUpdate { get { return Name; } }
        public string ComboboxDescriptionUpdate {get { return Name; }}

    }
}
