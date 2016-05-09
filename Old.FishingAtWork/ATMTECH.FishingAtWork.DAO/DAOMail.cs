using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOMail : BaseDao<Mail, int>, IDAOMail
    {
        public IDAOPlayer DAOPlayer { get; set; }

        public IList<Mail> GetMail(Player player, string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            IList<Mail> mails = GetAllOneCriteria(Mail.PLAYER_TO, player.Id.ToString());
            foreach (Mail mail in mails)
            {
                mail.PlayerFrom = DAOPlayer.GetPlayer(mail.PlayerFrom.Id);
                mail.PlayerTo = DAOPlayer.GetPlayer(mail.PlayerTo.Id);
            }

            return mails;
        }

        public int UpdateMail(Mail mail)
        {
            return Save(mail);
        }

        public int GetMailCount()
        {
            return GetCount();
        }
    }
}
