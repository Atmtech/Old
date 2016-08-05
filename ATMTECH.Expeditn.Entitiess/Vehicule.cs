using System.CodeDom;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Vehicule : BaseEntity
    {
        public string Nom { get; set; }
        public decimal LitreAu100 { get; set; }
    }
}