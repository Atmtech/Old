using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ATMTECH.Entities;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Entities.DTO;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Services;
using ATMTECH.Services.Interface;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.Expeditn.Services
{
    public class ExpeditionService : BaseService, IExpeditionService
    {
        public IDAOExpedition DAOExpedition { get; set; }
        public IDAOParticipant DAOParticipant { get; set; }
        public IDAONourritureParticipant DAONourritureParticipant { get; set; }
        public IDAOEtapeParticipant DAOEtapeParticipant { get; set; }
        public IDAOEtape DAOEtape { get; set; }
        public IReportService ReportService { get; set; }

        public Expedition ObtenirExpedition(int id)
        {
            return DAOExpedition.ObtenirExpedition(id);
        }
        public IList<Expedition> ObtenirExpedition()
        {
            return DAOExpedition.ObtenirExpedition();
        }
        public IList<Expedition> ObtenirExpeditionTop(int nombreExpeditionPrise)
        {
            return DAOExpedition.ObtenirExpeditionTop(nombreExpeditionPrise);
        }
        public int Enregistrer(Expedition expedition)
        {
            return DAOExpedition.Enregistrer(expedition);
        }
        public IList<Expedition> ObtenirMesExpedition(int idUtilisateur)
        {
            IList<Participant> Participant = DAOParticipant.ObtenirParticipant().Where(x => x.Utilisateur.Id == idUtilisateur).ToList();
            IList<Expedition> expeditions = new List<Expedition>();
            foreach (Participant participant in Participant)
            {
                if (participant.Utilisateur.Id == idUtilisateur)
                {
                    Expedition expedition = DAOExpedition.ObtenirExpedition(participant.Expedition.Id);
                    if (expedition.IsActive)
                        expeditions.Add(expedition);
                }
            }

            return expeditions;
        }
        public IList<AffichageSommeInvesti> ObtenirSommeInvesti(Expedition expedition)
        {
            IList<AffichageSommeInvesti> affichageSommeInvestis = new List<AffichageSommeInvesti>();

            foreach (Participant participant in expedition.Participant)
            {
                AffichageSommeInvesti affichageSommeInvesti = new AffichageSommeInvesti
                {
                    Expedition = participant.Expedition,
                    Utilisateur = participant.Utilisateur,
                    MontantNourriture = CalculerTotalNourriture(expedition.Nourriture, participant),
                    MontantEtapeAutomobile = CalculerTotalEtapeParMoyenTransport(expedition.Etape, participant, TypeVehicule.Automobile),
                    MontantEtapeAvion = CalculerTotalEtapeParMoyenTransport(expedition.Etape, participant, TypeVehicule.Avion),
                    MontantEtapeBateau = CalculerTotalEtapeParMoyenTransport(expedition.Etape, participant, TypeVehicule.Bateau),
                    MontantAutre = CalculerTotalMontantAutre(expedition.Etape, participant),
                };
                affichageSommeInvestis.Add(affichageSommeInvesti);
            }

            return affichageSommeInvestis;
        }
        public void RepartirNourriture(Expedition expedition, string idParticipant, decimal montant)
        {
            int compteNourriture = expedition.Nourriture.Count;
            if (compteNourriture > 0)
            {
                decimal montantParRepas = montant / compteNourriture;
                foreach (Nourriture nourriture in expedition.Nourriture)
                {
                    foreach (NourritureParticipant nourritureParticipant in nourriture.NourritureParticipant.Where(x => x.Participant.Id == Convert.ToInt32(idParticipant)))
                    {
                        nourritureParticipant.Montant = montantParRepas;
                        DAONourritureParticipant.Enregistrer(nourritureParticipant);
                    }
                }
            }
        }
        public void RepartirAutomobile(Expedition expedition, string idParticipant, decimal montant)
        {
            RepartirMoyenTransport(expedition, idParticipant, montant, TypeVehicule.Automobile);
        }
        public void RepartirBateau(Expedition expedition, string idParticipant, decimal montant)
        {
            RepartirMoyenTransport(expedition, idParticipant, montant, TypeVehicule.Bateau);
        }
        public void RepartirAutre(Expedition expedition, string idParticipant, decimal montant)
        {

            int compte = 0;
            foreach (Etape etape in expedition.Etape)
            {
                compte += etape.EtapeParticipant.Count(x => x.Participant.Id == Convert.ToInt32(idParticipant));
            }
            if (compte > 0)
            {
                decimal montantAutreParEtape = montant / compte;
                foreach (Etape etape in expedition.Etape)
                {
                    foreach (EtapeParticipant etapeParticipant in etape.EtapeParticipant.Where(x => x.Participant.Id == Convert.ToInt32(idParticipant)))
                    {
                        etapeParticipant.MontantAutre = montantAutreParEtape;
                        DAOEtapeParticipant.Enregistrer(etapeParticipant);
                    }
                }
            }
        }
        public IList<AffichageRepartitionMontant> ObtenirRepartitionMontant(Expedition expedition)
        {
            IList<AffichageRepartitionMontant> affichageRepartitionMontants = new List<AffichageRepartitionMontant>();

            IList<AffichageSommeInvesti> affichageSommeInvestis = ObtenirSommeInvesti(expedition);

            foreach (Participant participant in expedition.Participant)
            {
                AffichageRepartitionMontant affichageRepartitionMontant = new AffichageRepartitionMontant
                {
                    Utilisateur = participant.Utilisateur,
                    NombrePresenceEtapeAutomobile = CalculerTotalPresenceEtapeVehicule(expedition, participant.Id, TypeVehicule.Automobile),
                    NombrePresenceEtapeBateau = CalculerTotalPresenceEtapeVehicule(expedition, participant.Id, TypeVehicule.Bateau),
                    NombreRepas = CalculerNombreRepas(expedition, participant.Id),
                    MontantTotalAutomobile = affichageSommeInvestis.Sum(x => x.MontantEtapeAutomobile),
                    MontantTotalBateau = affichageSommeInvestis.Sum(x => x.MontantEtapeBateau),
                    MontantTotalNourriture = affichageSommeInvestis.Sum(x => x.MontantNourriture),
                    MontantTotalAutre = affichageSommeInvestis.Sum(x => x.MontantAutre),
                    NombreTotalParticipant = expedition.Participant.Count(),
                };

                affichageRepartitionMontants.Add(affichageRepartitionMontant);
            }

            foreach (AffichageRepartitionMontant affichageRepartitionMontant in affichageRepartitionMontants)
            {
                affichageRepartitionMontant.NombreTotalRepas = affichageRepartitionMontants.Sum(x => x.NombreRepas);
                affichageRepartitionMontant.NombreTotalEtapeAutomobile = affichageRepartitionMontants.Sum(x => x.NombrePresenceEtapeAutomobile);
                affichageRepartitionMontant.NombreTotalEtapeBateau = affichageRepartitionMontants.Sum(x => x.NombrePresenceEtapeBateau);
            }

            return affichageRepartitionMontants;
        }
        public IList<AffichageMontantDu> ObtenirMontantDu(Expedition expedition)
        {
            IList<AffichageMontantDu> affichageMontantDus = new List<AffichageMontantDu>();
            IList<AffichageSommeInvesti> affichageSommeInvestis = ObtenirSommeInvesti(expedition).OrderByDescending(x => x.MontantTotal).ToList();
            IList<AffichageRepartitionMontant> affichageRepartitionMontants = ObtenirRepartitionMontant(expedition);
            User participantAyantLePlusDepense = affichageSommeInvestis.FirstOrDefault(x => x.MontantTotal == affichageSommeInvestis.Max(z => z.MontantTotal)).Utilisateur;
            foreach (AffichageRepartitionMontant affichageRepartitionMontant in affichageRepartitionMontants)
            {
                AffichageMontantDu montantDu = new AffichageMontantDu
                {
                    Paye = participantAyantLePlusDepense,
                    Payeur = expedition.Participant.FirstOrDefault(x => x.Utilisateur.Id == affichageRepartitionMontant.Utilisateur.Id).Utilisateur,
                    Montant = affichageRepartitionMontant.MontantTotal - affichageSommeInvestis.FirstOrDefault(x => x.Utilisateur.Id == affichageRepartitionMontant.Utilisateur.Id).MontantTotal
                };

                if (montantDu.Paye.Id != montantDu.Payeur.Id)
                {
                    affichageMontantDus.Add(montantDu);
                }
            }

            return affichageMontantDus;
        }


        public void ObtenirMenuPdf(Expedition expedition)
        {
            Dictionary<string, string> dictionnaire = new Dictionary<string, string>();
            ReportParameter reportParameter = new ReportParameter
            {
                Assembly = "ATMTECH.Expeditn.Services",
                PathToReportAssembly = "ATMTECH.Expeditn.Services.Rapports.Menu.rdlc",
                ReportFormat = ReportFormat.PDF,
                Parameters = dictionnaire
            };

            reportParameter.AddDatasource("dsMenu", expedition.Nourriture.OrderBy(x => x.Date));
            ReportService.SaveReport("menu.pdf", ReportService.GetReport(reportParameter));
        }



        private int CalculerNombreRepas(Expedition expedition, int idParticipant)
        {
            int compte = 0;
            if (expedition.Nourriture != null)
            {
                foreach (Nourriture nourriture in expedition.Nourriture)
                {
                    compte += nourriture.NourritureParticipant.Count(x => x.Participant.Id == idParticipant);
                }
            }
            return compte;
        }
        private int CalculerTotalPresenceEtapeVehicule(Expedition expedition, int idParticipant, TypeVehicule typeVehicule)
        {
            int compte = 0;
            foreach (Etape etape in expedition.Etape.Where(x => x.Vehicule.EnumTypeVehicule == typeVehicule))
            {
                compte += etape.EtapeParticipant.Count(x => x.Participant.Id == idParticipant);
            }
            return compte;
        }
        private decimal CalculerTotalNourriture(IList<Nourriture> nourritures, Participant participant)
        {
            if (nourritures != null)
                return Math.Round(nourritures.Sum(nourriture => nourriture.NourritureParticipant.Where(x => x.Participant.Id == participant.Id).Sum(x => x.Montant)), 2);
            return 0;

        }
        private decimal CalculerTotalEtapeParMoyenTransport(IList<Etape> etapes, Participant participant, TypeVehicule typeVehicule)
        {
            if (etapes != null)
                return Math.Round(etapes.Where(x => x.Vehicule.EnumTypeVehicule == typeVehicule).Sum(etape => etape.EtapeParticipant.Where(x => x.Participant.Id == participant.Id).Sum(x => x.MontantVehicule)), 2);
            return 0;
        }
        private decimal CalculerTotalMontantAutre(IList<Etape> etapes, Participant participant)
        {
            if (etapes != null)
                return Math.Round(etapes.Sum(etape => etape.EtapeParticipant.Where(x => x.Participant.Id == participant.Id).Sum(x => x.MontantAutre)), 2);
            return 0;
        }
        private void RepartirMoyenTransport(Expedition expedition, string idParticipant, decimal montant, TypeVehicule typeVehicule)
        {
            int compte = 0;
            foreach (Etape etape in expedition.Etape.Where(x => x.Vehicule.EnumTypeVehicule == typeVehicule))
            {
                compte += etape.EtapeParticipant.Count(x => x.Participant.Id == Convert.ToInt32(idParticipant));
            }

            if (compte > 0)
            {
                decimal montantParVoyagement = montant / compte;
                foreach (Etape etape in expedition.Etape.Where(x => x.Vehicule.EnumTypeVehicule == typeVehicule))
                {
                    foreach (EtapeParticipant etapeParticipant in etape.EtapeParticipant.Where(x => x.Participant.Id == Convert.ToInt32(idParticipant)))
                    {
                        etapeParticipant.MontantVehicule = montantParVoyagement;
                        DAOEtapeParticipant.Enregistrer(etapeParticipant);
                    }
                }

            }
        }
    }
}
