using System.Collections.Generic;
using System.Linq;
using ATMTECH.CalculPeche.DAO.Interface;
using ATMTECH.CalculPeche.Entities;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;

namespace ATMTECH.CalculPeche.DAO
{
    public class DAOParticipantAutomobileExpedition : BaseDao<ParticipantAutomobileExpedition, int>, IDAOParticipantAutomobileExpedition
    {
        public IDAOExpedition DAOExpedition { get; set; }
        public IDAOParticipant DAOParticipant { get; set; }
        public IList<ParticipantAutomobileExpedition> ObtenirParticipantAutomobileExpedition(int idExpedition)
        {
            List<ParticipantAutomobileExpedition> participantAutomobileExpeditions = GetAllOneCriteria(ParticipantAutomobileExpedition.EXPEDITION, idExpedition.ToString()).Where(x => x.IsActive).ToList();
            IList<Expedition> obtenirExpedition = DAOExpedition.ObtenirExpedition();
            IList<Participant> obtenirParticipant = DAOParticipant.ObtenirParticipant();
            foreach (ParticipantAutomobileExpedition participantAutomobileExpedition in participantAutomobileExpeditions)
            {
                participantAutomobileExpedition.Expedition = obtenirExpedition.FirstOrDefault(x => x.Id == participantAutomobileExpedition.Expedition.Id);
                participantAutomobileExpedition.Participant = obtenirParticipant.FirstOrDefault(x => x.Id == participantAutomobileExpedition.Participant.Id);
            }

            return participantAutomobileExpeditions;
        }
    }
}
