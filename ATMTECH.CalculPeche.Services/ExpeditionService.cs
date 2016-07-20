using System.Collections.Generic;
using ATMTECH.CalculPeche.DAO.Interface;
using ATMTECH.CalculPeche.Entities;
using ATMTECH.CalculPeche.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.CalculPeche.Services
{
   public  class ExpeditionService: BaseService, IExpeditionService
    {
       public IDAOExpedition DAOExpedition { get; set; }
       public IDAOParticipantPresenceExpedition DAOParticipantPresenceExpedition { get; set; }
       public IDAOParticipantBateauExpedition DAOParticipantBateauExpedition { get; set; }
       public IDAOParticipantRepasExpedition DAOParticipantRepasExpedition { get; set; }
       public IDAOParticipantExpedition DAOParticipantExpedition { get; set; }

       public IList<Expedition> ObtenirExpedition()
       {
           return DAOExpedition.ObtenirExpedition();
       }

       public IList<ParticipantPresenceExpedition> ObtenirParticipantPresenceExpedition(int idExpedition)
       {
           return DAOParticipantPresenceExpedition.ObtenirParticipantPresenceExpedition(idExpedition);
       }

       public IList<ParticipantRepasExpedition> ObtenirParticipantRepasExpedition(int idExpedition)
       {
           return DAOParticipantRepasExpedition.ObtenirParticipantRepasExpedition(idExpedition);
       }

       public IList<ParticipantBateauExpedition> ObtenirParticipantBateauExpedition(int idExpedition)
       {
           return DAOParticipantBateauExpedition.ObtenirParticipantBateauExpedition(idExpedition);
       }

       public IList<ParticipantExpedition> ObtenirParticipantExpedition(int idExpedition)
       {
           return DAOParticipantExpedition.ObtenirParticipantExpedition(idExpedition);
       }
    }
}
