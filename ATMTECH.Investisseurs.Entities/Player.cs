using ATMTECH.Entities;

namespace ATMTECH.Investisseurs.Entities
{

    public partial class Player : BaseEntity
    {
        public double StartingMoney { get; set; }
        public string Image { get; set; }
        public User User { get; set; }
    }
}
