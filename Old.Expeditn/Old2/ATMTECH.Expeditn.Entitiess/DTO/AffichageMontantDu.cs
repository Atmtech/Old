using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities.DTO
{
    public class AffichageMontantDu
    {
        public User Payeur { get; set; }
        public decimal Montant { get; set; }
        public User Paye { get; set; }
    }
}
