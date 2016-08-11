using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Vehicule : BaseEntity
    {
        public string Nom { get; set; }
        public string Fabriquant { get; set; }
        public string Annee { get; set; }
        public decimal LitreAu100 { get; set; }
        public int TypeVehicule { get; set; }

        public TypeVehicule EnumTypeVehicule
        {
            get
            {
                if (TypeVehicule == 0)
                    return Entities.TypeVehicule.Avion;
                if (TypeVehicule == 1)
                    return Entities.TypeVehicule.Automobile;
                if (TypeVehicule == 2)
                    return Entities.TypeVehicule.Bateau;
                if (TypeVehicule == 3)
                    return Entities.TypeVehicule.Train;
                return Entities.TypeVehicule.Automobile;
            }
        }

        public string ComboboxDescriptionUpdate
        {
            get { return string.Format("{0} {1} ({2})", Nom, Annee, Fabriquant); }
        }
    }

    public enum TypeVehicule
    {
        Avion = 0,
        Automobile = 1,
        Bateau = 2,
        Train = 3
    }
}