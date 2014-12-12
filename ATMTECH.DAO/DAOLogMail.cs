using System.Net.Mail;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;

namespace ATMTECH.DAO
{
    public class DAOLogMail : BaseDao<LogMail, int>, IDAOLogMail
    {
        public void CreateLog(MailMessage mailMessage)
        {
            LogMail logMail = new LogMail
                {
                    Body = mailMessage.Body,
                    From = mailMessage.From.Address,
                    Subject = mailMessage.Subject
                };
            foreach (MailAddress mailAddress in mailMessage.To)
            {
                logMail.To += mailAddress.Address;
            }
            
            Save(logMail);
        }
    }
}
