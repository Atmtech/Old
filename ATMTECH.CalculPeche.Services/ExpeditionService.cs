using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.CalculPeche.DAO.Interface;
using ATMTECH.CalculPeche.Entities;
using ATMTECH.CalculPeche.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.CalculPeche.Services
{
    public class ExpeditionService : BaseService, IExpeditionService
    {
        public IDAOExpedition DAOExpedition { get; set; }
        public IDAOParticipant DAOParticipant { get; set; }
        public IDAOParticipantPresenceExpedition DAOParticipantPresenceExpedition { get; set; }
        public IDAOParticipantBateauExpedition DAOParticipantBateauExpedition { get; set; }
        public IDAOParticipantRepasExpedition DAOParticipantRepasExpedition { get; set; }
        public IDAOParticipantExpedition DAOParticipantExpedition { get; set; }
        public IDAOParticipantAutomobileExpedition DAOParticipantAutomobileExpedition { get; set; }

        public IList<Expedition> ObtenirExpedition()
        {
            return DAOExpedition.ObtenirExpedition();
        }

        public IList<Participant> ObtenirParticipant()
        {
            return DAOParticipant.ObtenirParticipant();
        }

        public IList<ParticipantPresenceExpedition> ObtenirParticipantPresenceExpedition(int idExpedition)
        {
            return DAOParticipantPresenceExpedition.ObtenirParticipantPresenceExpedition(idExpedition);
        }

        public IList<ParticipantPresenceExpedition> ObtenirParticipantPresenceExpedition()
        {
            return DAOParticipantPresenceExpedition.ObtenirParticipantPresenceExpedition();
        }

        public IList<ParticipantRepasExpedition> ObtenirParticipantRepasExpedition(int idExpedition)
        {
            return DAOParticipantRepasExpedition.ObtenirParticipantRepasExpedition(idExpedition);
        }

        public IList<ParticipantRepasExpedition> ObtenirParticipantRepasExpedition()
        {
            return DAOParticipantRepasExpedition.ObtenirParticipantRepasExpedition();
        }

        public IList<ParticipantBateauExpedition> ObtenirParticipantBateauExpedition(int idExpedition)
        {
            return DAOParticipantBateauExpedition.ObtenirParticipantBateauExpedition(idExpedition);
        }

        public IList<ParticipantBateauExpedition> ObtenirParticipantBateauExpedition()
        {
            return DAOParticipantBateauExpedition.ObtenirParticipantBateauExpedition();
        }

        public IList<ParticipantAutomobileExpedition> ObtenirParticipantAutomobileExpedition()
        {
            return DAOParticipantAutomobileExpedition.ObtenirParticipantAutomobileExpedition();
        }

        public IList<ParticipantExpedition> ObtenirParticipantExpedition(int idExpedition)
        {
            return DAOParticipantExpedition.ObtenirParticipantExpedition(idExpedition).OrderByDescending(x => x.Total).ToList();
        }

        public IList<ParticipantExpedition> ObtenirParticipantExpedition()
        {
            return DAOParticipantExpedition.ObtenirParticipantExpedition();
        }

        public IList<ParticipantAutomobileExpedition> ObtenirParticipantAutomobileExpedition(int idExpedition)
        {
            return DAOParticipantAutomobileExpedition.ObtenirParticipantAutomobileExpedition(idExpedition);
        }
        public IList<Repartition> ObtenirRepartition(int idExpedition)
        {
            IList<Repartition> repartitions = new List<Repartition>();
            Expedition expedition = ObtenirExpedition().FirstOrDefault(x => x.Id == idExpedition);
            IList<ParticipantExpedition> obtenirParticipantExpedition = ObtenirParticipantExpedition(idExpedition);
            IList<ParticipantBateauExpedition> obtenirParticipantBateauExpedition = ObtenirParticipantBateauExpedition(idExpedition);
            IList<ParticipantAutomobileExpedition> obtenirParticipantAutomobileExpedition = ObtenirParticipantAutomobileExpedition(idExpedition);
            IList<ParticipantPresenceExpedition> obtenirParticipantPresenceExpedition = ObtenirParticipantPresenceExpedition(idExpedition);
            IList<ParticipantRepasExpedition> obtenirParticipantRepasExpedition = ObtenirParticipantRepasExpedition(idExpedition);

            int nombreTotalJour = obtenirParticipantPresenceExpedition.Select(x => x.DateParticipation).Distinct().Count();
            int nombreTotalRepas = obtenirParticipantRepasExpedition.Sum(x => x.NombreRepas);

            List<DateTime> dateTimes = obtenirParticipantBateauExpedition.Select(x => x.DateParticipation).OrderBy(x => x.Date).Distinct().ToList();
            int nombreTotalSortieBateau = 0;
            int nombreTotalAutomobile = 0;
            foreach (DateTime dateTime in dateTimes)
            {
                if (obtenirParticipantBateauExpedition.Count(x => x.DateParticipation == dateTime && x.EstBateau) > 0)
                {
                    nombreTotalSortieBateau += 1;
                }

                if (obtenirParticipantAutomobileExpedition.Count(x => x.DateParticipation == dateTime && x.EstAutomobile) > 0)
                {
                    nombreTotalAutomobile += 1;
                }
            }

            double montantTotalNourriture = obtenirParticipantExpedition.Sum(x => x.MontantNourriture);
            double montantTotalPropane = obtenirParticipantExpedition.Sum(x => x.MontantPropane);
            double montantTotalAutomobile = obtenirParticipantExpedition.Sum(x => x.MontantAutomobile);
            double montantTotalBateau = obtenirParticipantExpedition.Sum(x => x.MontantBateau);

            foreach (ParticipantExpedition participantExpedition in obtenirParticipantExpedition)
            {
                Repartition repartition = new Repartition
                {
                    Nom = participantExpedition.Participant.Nom,
                    NombreRepas = obtenirParticipantRepasExpedition.Where(x => x.Participant.Nom == participantExpedition.Participant.Nom).Sum(x => x.NombreRepas),
                    NombrePresence = obtenirParticipantPresenceExpedition.Count(x => x.Participant.Nom == participantExpedition.Participant.Nom && x.EstPresence),
                    NombreBateau = obtenirParticipantBateauExpedition.Count(x => x.Participant.Nom == participantExpedition.Participant.Nom && x.EstBateau),
                    NombreAutomobile = obtenirParticipantAutomobileExpedition.Count(x => x.Participant.Nom == participantExpedition.Participant.Nom && x.EstAutomobile),
                    NombreTotalJour = nombreTotalJour,
                    NombreTotalRepas = nombreTotalRepas,
                    NombreTotalSortieBateau = nombreTotalSortieBateau,
                    NombreTotalAutomobile = nombreTotalAutomobile
                };

                if (expedition != null) repartition.PourcentageRepas = repartition.NombreRepas / nombreTotalRepas;
                if (nombreTotalAutomobile > 0)
                {
                    if (expedition != null) repartition.PourcentageAutomobile = repartition.NombreAutomobile / nombreTotalAutomobile;
                }

                if (expedition != null) repartition.PourcentageBateau = repartition.NombreBateau / nombreTotalSortieBateau;
                if (expedition != null) repartition.PourcentagePropane = repartition.NombrePresence / nombreTotalJour;

                if (repartition.NombreTotalEvenement != 0)
                {
                    repartitions.Add(repartition);
                }

            }

            foreach (Repartition repartition in repartitions)
            {
                repartition.TotalRepas = (repartition.PourcentageRepas * montantTotalNourriture) / repartitions.Sum(x => x.PourcentageRepas);
                repartition.TotalPropane = (repartition.PourcentagePropane * montantTotalPropane) / repartitions.Sum(x => x.PourcentagePropane);
                repartition.TotalAutomobile = (repartition.PourcentageAutomobile * montantTotalAutomobile) / repartitions.Sum(x => x.PourcentageAutomobile);
                repartition.TotalBateau = (repartition.PourcentageBateau * montantTotalBateau) / repartitions.Sum(x => x.PourcentageBateau);

            }

            return repartitions;
        }

        public IList<MontantDu> ObtenirMontantDu(int idExpedition)
        {
            IList<Repartition> obtenirRepartition = ObtenirRepartition(idExpedition);
            IList<ParticipantExpedition> obtenirParticipantExpedition = ObtenirParticipantExpedition(idExpedition);
            IList<MontantDu> montantDus = new List<MontantDu>();
            Participant participantAyantLePlusDepense = obtenirParticipantExpedition.FirstOrDefault(x => x.Total == obtenirParticipantExpedition.Max(z => z.Total)).Participant;
            foreach (Repartition repartition in obtenirRepartition)
            {
                MontantDu montantDu = new MontantDu
                {
                    ParticipantPaye = participantAyantLePlusDepense,
                    ParticipantPayeur = obtenirParticipantExpedition.FirstOrDefault(x => x.Participant.Nom == repartition.Nom).Participant,
                    Montant = repartition.GrandTotal - obtenirParticipantExpedition.FirstOrDefault(x => x.Participant.Nom == repartition.Nom).Total
                };

                if (montantDu.ParticipantPaye.Nom != montantDu.ParticipantPayeur.Nom)
                {
                    montantDus.Add(montantDu);
                }
            }
            return montantDus.OrderByDescending(x => x.Montant).ToList();
        }

        public void CreerExpedition(string nom, string dateDebut, string dateFin)
        {
            DAOExpedition.CreerExpedition(nom, dateDebut, dateFin);
        }

        public void RemettreSearch()
        {
            foreach (Expedition expedition in DAOExpedition.ObtenirExpedition().Where(x=>string.IsNullOrEmpty(x.Search)))
            {
                DAOExpedition.Enregistrer(expedition);

                foreach (ParticipantAutomobileExpedition participantAutomobileExpedition in DAOParticipantAutomobileExpedition.ObtenirParticipantAutomobileExpedition(expedition.Id).Where(x => string.IsNullOrEmpty(x.Search)))
                {
                    DAOParticipantAutomobileExpedition.Enregistrer(participantAutomobileExpedition);
                }

                foreach (ParticipantBateauExpedition participantBateauExpedition in DAOParticipantBateauExpedition.ObtenirParticipantBateauExpedition(expedition.Id).Where(x => string.IsNullOrEmpty(x.Search)))
                {
                    DAOParticipantBateauExpedition.Enregistrer(participantBateauExpedition);
                }

                foreach (ParticipantRepasExpedition participantRepasExpedition in DAOParticipantRepasExpedition.ObtenirParticipantRepasExpedition(expedition.Id).Where(x => string.IsNullOrEmpty(x.Search)))
                {
                    DAOParticipantRepasExpedition.Enregistrer(participantRepasExpedition);
                }

                foreach (ParticipantPresenceExpedition participantPresenceExpedition in DAOParticipantPresenceExpedition.ObtenirParticipantPresenceExpedition(expedition.Id).Where(x => string.IsNullOrEmpty(x.Search)))
                {
                    DAOParticipantPresenceExpedition.Enregistrer(participantPresenceExpedition);
                }

                foreach (ParticipantExpedition participantExpedition in DAOParticipantExpedition.ObtenirParticipantExpedition(expedition.Id).Where(x => string.IsNullOrEmpty(x.Search)))
                {
                    DAOParticipantExpedition.Enregistrer(participantExpedition);
                }

            }

            foreach (Participant participant in DAOParticipant.ObtenirParticipant().Where(x => string.IsNullOrEmpty(x.Search)))
            {
                DAOParticipant.Enregistrer(participant);
            }


        }

        public void InitialiserTable(int idExpedition)
        {

        }
    }
}
