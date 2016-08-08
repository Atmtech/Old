using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Pays : BaseEntity
    {
        public string Code { get; set; }
        public string Iso { get; set; }
        public string Type { get; set; }
    }
}