using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Services.Interface
{
    public interface IMessagingService
    {
        IList<Mail> GetMail(Player player, string parametreTrie, int nbEnreg, int indexDebutRangee);
        int UpdateMail(Mail mail);
        int GetMailCount();
    }
}
