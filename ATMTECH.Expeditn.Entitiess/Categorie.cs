using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Categorie : BaseEntity
    {
        public string Code { get; set; }
        public string NomFr { get; set; }
        public string NomEn { get; set; }
    }
}