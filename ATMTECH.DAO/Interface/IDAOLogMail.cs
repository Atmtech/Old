using System.Net.Mail;

namespace ATMTECH.DAO.Interface
{
    public interface IDAOLogMail
    {
        void CreateLog(MailMessage mailMessage);
    }
}
