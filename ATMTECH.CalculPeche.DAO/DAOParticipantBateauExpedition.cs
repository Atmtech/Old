using System.Collections.Generic;
using System.Linq;
using ATMTECH.CalculPeche.DAO.Interface;
using ATMTECH.CalculPeche.Entities;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;

namespace ATMTECH.CalculPeche.DAO
{
    public class DAOParticipantBateauExpedition : BaseDao<ParticipantBateauExpedition, int>, IDAOParticipantBateauExpedition
    {
        public IDAOExpedition DAOExpedition { get; set; }
        public IDAOParticipant DAOParticipant { get; set; }
        public IList<ParticipantBateauExpedition> ObtenirParticipantBateauExpedition(int idExpedition)
        {
            List<ParticipantBateauExpedition> participantBateauExpeditions = GetAllOneCriteria(ParticipantBateauExpedition.EXPEDITION, idExpedition.ToString()).Where(x => x.IsActive).ToList();
            IList<Expedition> obtenirExpedition = DAOExpedition.ObtenirExpedition();
            IList<Participant> obtenirParticipant = DAOParticipant.ObtenirParticipant();
            foreach (ParticipantBateauExpedition participantBateauExpedition in participantBateauExpeditions)
            {
                participantBateauExpedition.Expedition = obtenirExpedition.FirstOrDefault(x => x.Id == participantBateauExpedition.Expedition.Id);
                participantBateauExpedition.Participant = obtenirParticipant.FirstOrDefault(x => x.Id == participantBateauExpedition.Participant.Id);
            }

            return participantBateauExpeditions;
        }
    }
}
