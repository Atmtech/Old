using System.Collections.Generic;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.FishingAtWork.Services
{
    public class MessagingService : BaseService, IMessagingService
    {
        public IDAOMail DAOMail { get; set; }
        public IList<Mail> GetMail(Player player, string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            return DAOMail.GetMail(player, parametreTrie, nbEnreg, indexDebutRangee);
        }

        public int GetMailCount()
        {
            return DAOMail.GetMailCount();
        }

        public int UpdateMail(Mail mail)
        {
            return DAOMail.UpdateMail(mail);
        }
    }
}
