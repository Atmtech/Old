using System.Collections.Generic;
using System.Linq;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.Expeditn.Services
{
    public class ExpeditionService : BaseService, IExpeditionService
    {
        public IDAOExpedition DAOExpedition { get; set; }
        public IDAOParticipant DAOParticipant { get; set; }

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
            IList<Expedition> mesExpeditions = new List<Expedition>();
            foreach (Participant participant in Participant)
            {
                mesExpeditions.Add(DAOExpedition.ObtenirExpedition(participant.Expedition.Id));
            }
            return mesExpeditions;
        }
    }
}
