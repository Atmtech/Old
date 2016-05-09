using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOMail
    {
        IList<Mail> GetMail(Player player, string parametreTrie, int nbEnreg, int indexDebutRangee);
        int UpdateMail(Mail mail);
        int GetMailCount();
    }
}
