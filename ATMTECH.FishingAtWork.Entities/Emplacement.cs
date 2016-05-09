using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class Emplacement : BaseEntity
    {
        public string Nom { get; set; }
        public string CoordonneGps { get; set; }
        public IList<Fichier> Fichiers { get; set; }
    }
}
