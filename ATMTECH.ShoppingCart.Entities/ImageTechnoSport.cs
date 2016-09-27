using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    public class ImageTechnoSport : BaseEntity
    {
        public Product Product { get; set; }
        public string Image { get; set; }
        public string ImageCouleur { get; set; }
        public string NomCouleurFr { get; set; }
        public string NomCouleurEn { get; set; }
        
    }
}
