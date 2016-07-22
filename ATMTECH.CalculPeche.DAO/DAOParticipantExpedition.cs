using System.Collections.Generic;
using System.Linq;
using ATMTECH.CalculPeche.DAO.Interface;
using ATMTECH.CalculPeche.Entities;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;

namespace ATMTECH.CalculPeche.DAO
{
    public class DAOParticipantExpedition : BaseDao<ParticipantExpedition, int>, IDAOParticipantExpedition
    {
        public IDAOExpedition DAOExpedition { get; set; }
        public IDAOParticipant DAOParticipant { get; set; }
        public IList<ParticipantExpedition> ObtenirParticipantExpedition(int idExpedition)
        {
            List<ParticipantExpedition> participantExpeditions = GetAllOneCriteria(ParticipantExpedition.EXPEDITION, idExpedition.ToString()).Where(x => x.IsActive).ToList();
            IList<Expedition> obtenirExpedition = DAOExpedition.ObtenirExpedition();
            IList<Participant> obtenirParticipant = DAOParticipant.ObtenirParticipant();
            foreach (ParticipantExpedition participantExpedition in participantExpeditions)
            {
                participantExpedition.Expedition = obtenirExpedition.FirstOrDefault(x => x.Id == participantExpedition.Expedition.Id);
                participantExpedition.Participant = obtenirParticipant.FirstOrDefault(x => x.Id == participantExpedition.Participant.Id);
            }

            return participantExpeditions;
        }
    }
}
