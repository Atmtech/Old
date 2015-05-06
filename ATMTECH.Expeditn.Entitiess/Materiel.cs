using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Materiel : BaseEntity
    {
        public Expedition Expedition { get; set; }
        public string Regroupement { get; set; }
        public string Nom { get; set; }
        public int Quantite { get; set; }
        public decimal Poids { get; set; }
        public decimal Cout { get; set; }
    }
}