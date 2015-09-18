using ATMTECH.Entities;

namespace ATMTECH.XWingCampaign.Entities
{
    public class IntelligenceArtificiel : BaseEntity
    {
        public const string MOUVEMENT_TOUT_DROIT = "TD";
        public const string MOUVEMENT_LEGER_DROITE = "LD";
        public const string MOUVEMENT_LEGER_GAUCHE = "LG";
        public const string MOUVEMENT_SERRER_DROITE = "SD";
        public const string MOUVEMENT_SERRER_GAUCHE = "SG";
        public const string MOUVEMENT_RETOURNEMENT = "R";

        public const string POSITION_R1 = "R1";
        public const string POSITION_R2_CLOSING = "R2C";
        public const string POSITION_R2_FLEEING = "R2F";
        public const string POSITION_R3 = "R3";

        public const string QUADRAN_NORD = "N";
        public const string QUADRAN_NORD_EST = "NE";
        public const string QUADRAN_EST = "E";
        public const string QUADRAN_SUD_EST = "SE";
        public const string QUADRAN_SUD = "S";

        public const string VAISSEAU = "Vaisseau";
        public const string MOUVEMENT = "Mouvement";
        public const string NOMBRE_MOUVEMENT = "NombreMouvement";
        public const string DE_REQUIS = "DeRequis";
        public const string POSITION_VAISSEAU = "PositionVaisseau";
        public const string QUADRAN = "Quadran";

        public Vaisseau Vaisseau { get; set; }
        public string Mouvement { get; set; }
        public string NombreMouvement { get; set; }
        public string DeRequis { get; set; }
        public string PositionVaisseau { get; set; }
        public string Quadran { get; set; }
        public bool Stress { get; set; }
    }

    

    //public enum Mouvement
    //{
    //    ToutDroit,
    //    LegerDroite,
    //    LegerGauche,
    //    SerrerDroite,
    //    SerrerGauche,
    //    Retournement
    //}

    //public enum PositionVaisseau
    //{
    //    Rapprochement,
    //    Fuite
    //}

    //public enum Quadran
    //{
    //    Nord, NordEst, Est, SudEst, Sud
    //}
}

