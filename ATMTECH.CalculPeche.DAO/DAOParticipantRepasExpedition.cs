using System.Collections.Generic;
using System.Linq;
using ATMTECH.CalculPeche.DAO.Interface;
using ATMTECH.CalculPeche.Entities;
using ATMTECH.DAO;

namespace ATMTECH.CalculPeche.DAO
{
    public class DAOParticipantRepasExpedition : BaseDao<ParticipantRepasExpedition, int>, IDAOParticipantRepasExpedition
    {
        public IDAOExpedition DAOExpedition { get; set; }
        public IDAOParticipant DAOParticipant { get; set; }
        public IList<ParticipantRepasExpedition> ObtenirParticipantRepasExpedition(int idExpedition)
        {
            List<ParticipantRepasExpedition> participantRepasExpeditions = GetAllOneCriteria(ParticipantRepasExpedition.EXPEDITION, idExpedition.ToString()).Where(x => x.IsActive).ToList();
            IList<Expedition> obtenirExpedition = DAOExpedition.ObtenirExpedition();
            IList<Participant> obtenirParticipant = DAOParticipant.ObtenirParticipant();
            foreach (ParticipantRepasExpedition participantRepasExpedition in participantRepasExpeditions)
            {
                participantRepasExpedition.Expedition = obtenirExpedition.FirstOrDefault(x => x.Id == participantRepasExpedition.Expedition.Id);
                participantRepasExpedition.Participant = obtenirParticipant.FirstOrDefault(x => x.Id == participantRepasExpedition.Participant.Id);
            }

            return participantRepasExpeditions;
        }

        public IList<ParticipantRepasExpedition> ObtenirParticipantRepasExpedition()
        {
            return GetAllActive();
        }

        public int Enregistrer(ParticipantRepasExpedition participantRepasExpedition)
        {
            return Save(participantRepasExpedition);
        }
    }
}
