using ATMTECH.Entities;

namespace ATMTECH.DenonceTonGros.Entities
{
    public class Pays : BaseEntity
    {
        public string NomPays { get; set; }
        public int Compte { get; set; }
    }
}
