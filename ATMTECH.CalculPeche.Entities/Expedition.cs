using System;
using ATMTECH.Entities;

namespace ATMTECH.CalculPeche.Entities
{
   public class Expedition : BaseEntity 
    {
       public string Nom { get; set; }
       public DateTime DateDebut { get; set; }
       public DateTime DateFin { get; set; }
       
       
    }
}
