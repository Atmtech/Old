using System.Collections.Generic;
using System.IO;
using ATMTECH.Entities;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Entities.DTO;

namespace ATMTECH.Expeditn.Services.Interface
{
    public interface IExpeditionService
    {
        Expedition ObtenirExpedition(int id);
        IList<Expedition> ObtenirExpedition();
        IList<Expedition> ObtenirMesExpedition(int idUtilisateur);
        IList<Expedition> ObtenirExpeditionTop(int nombreExpeditionPrise);
        int Enregistrer(Expedition expedition);
        IList<AffichageSommeInvesti> ObtenirSommeInvesti(Expedition expedition);
        void RepartirNourriture(Expedition expedition, string idParticipant, decimal montant);
        void RepartirAutomobile(Expedition expedition, string idParticipant, decimal montant);
        void RepartirBateau(Expedition expedition, string idParticipant, decimal montant);
        void RepartirAutre(Expedition expedition, string idParticipant, decimal montant);
        IList<AffichageRepartitionMontant> ObtenirRepartitionMontant(Expedition expedition);
        IList<AffichageMontantDu> ObtenirMontantDu(Expedition expedition);
        void ObtenirMenuPdf(Expedition expedition);
    }
}
