using System.CodeDom;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Vehicule : BaseEntity
    {
        public string Nom { get; set; }
        public string Fabriquant { get; set; }
        public string Annee { get; set; }
        public decimal LitreAu100 { get; set; }

        public string ComboboxDescriptionUpdate
        {
            get { return string.Format("{0} {1} ({2})", Nom,Annee, Fabriquant); }
        }
    }
}