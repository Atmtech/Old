using System.Collections.Generic;
using System.Linq;
using ATMTECH.CalculPeche.DAO.Interface;
using ATMTECH.CalculPeche.Entities;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;

namespace ATMTECH.CalculPeche.DAO
{
    public class DAOParticipantPresenceExpedition : BaseDao<ParticipantPresenceExpedition, int>, IDAOParticipantPresenceExpedition
    {


        public IDAOExpedition DAOExpedition { get; set; }
        public IDAOParticipant DAOParticipant { get; set; }
        public IList<ParticipantPresenceExpedition> ObtenirParticipantPresenceExpedition(int idExpedition)
        {
            List<ParticipantPresenceExpedition> participantPresenceExpeditions = GetAllOneCriteria(ParticipantPresenceExpedition.EXPEDITION, idExpedition.ToString()).Where(x => x.IsActive).ToList();
            IList<Expedition> obtenirExpedition = DAOExpedition.ObtenirExpedition();
            IList<Participant> obtenirParticipant = DAOParticipant.ObtenirParticipant();
            foreach (ParticipantPresenceExpedition participantPresenceExpedition in participantPresenceExpeditions)
            {
                participantPresenceExpedition.Expedition = obtenirExpedition.FirstOrDefault(x => x.Id == participantPresenceExpedition.Expedition.Id);
                participantPresenceExpedition.Participant = obtenirParticipant.FirstOrDefault(x => x.Id == participantPresenceExpedition.Participant.Id);
            }

            return participantPresenceExpeditions;
        }

        public IList<ParticipantPresenceExpedition> ObtenirParticipantPresenceExpedition()
        {
            return GetAllActive();
        }

        public int Enregistrer(ParticipantPresenceExpedition participantPresenceExpedition)
        {
            return Save(participantPresenceExpedition);
        }
    }
}
