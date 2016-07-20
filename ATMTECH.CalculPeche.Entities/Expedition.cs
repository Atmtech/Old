using ATMTECH.Entities;

namespace ATMTECH.CalculPeche.Entities
{
   public class Expedition : BaseEntity 
    {
       public string Nom { get; set; }
       public int NombreSortieBateau { get; set; }
       public int NombreRepas { get; set; }
       
    }
}
