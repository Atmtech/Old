using System;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities.DTO
{
    public class AffichageRepartitionMontant
    {
        public User Utilisateur { get; set; }

        public decimal NombreTotalEtapeAutomobile { get; set; }
        public decimal NombrePresenceEtapeAutomobile { get; set; }
        public decimal PourcentagePresenceEtapeAutomobile
        {
            get
            {
                if (NombreTotalEtapeAutomobile > 0)
                    return Math.Round(NombrePresenceEtapeAutomobile / NombreTotalEtapeAutomobile, 2);
                return 0;
            }
        }
        public decimal MontantTotalAutomobile { get; set; }
        public decimal MontantAvecPourcentageDuTotalAutomobile
        {
            get { return Math.Round(MontantTotalAutomobile * (NombrePresenceEtapeAutomobile / NombreTotalEtapeAutomobile), 2); }
        }

        public decimal NombreTotalEtapeBateau { get; set; }
        public decimal NombrePresenceEtapeBateau { get; set; }
        public decimal PourcentagePresenceEtapeBateau
        {

            get
            {
                if (NombreTotalEtapeBateau > 0)
                    return Math.Round(NombrePresenceEtapeBateau / NombreTotalEtapeBateau, 2);
                return 0;
            }
        }
        public decimal MontantTotalBateau { get; set; }
        public decimal MontantAvecPourcentageDuTotalBateau
        {
            get { return Math.Round(MontantTotalBateau * (NombrePresenceEtapeBateau / NombreTotalEtapeBateau), 2); }
        }

        public decimal NombreTotalRepas { get; set; }
        public decimal NombreRepas { get; set; }
        public decimal PourcentageRepas
        {

            get
            {
                if (NombreTotalRepas > 0)
                    return Math.Round(NombreRepas / NombreTotalRepas, 2);
                return 0;
            }
        }
        public decimal MontantTotalNourriture { get; set; }
        public decimal MontantAvecPourcentageDesRepas
        {
            get { return Math.Round(MontantTotalNourriture * (NombreRepas / NombreTotalRepas), 2); }
        }

        public int NombreTotalParticipant { get; set; }
        public decimal MontantTotalAutre { get; set; }
        public decimal MontantAvecPourcentageAutres
        {
            get { return Math.Round(MontantTotalAutre / NombreTotalParticipant, 2); }
        }

        public decimal MontantTotal
        {
            get
            {
                return MontantAvecPourcentageDesRepas + MontantAvecPourcentageDuTotalAutomobile + MontantAvecPourcentageDuTotalBateau + MontantAvecPourcentageAutres;
            }
        }
    }
}
