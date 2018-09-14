using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Categorie : BaseEntity
    {
        public string Code { get; set; }
        public string Nom { get; set; }
        public string ComboboxDescriptionUpdate
        {
            get { return string.Format("{0}", Nom); }
        }
    }
}