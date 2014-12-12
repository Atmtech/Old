using System.Net.Mail;
using ATMTECH.Entities;

namespace ATMTECH.Web.Services.Interface
{
    public interface ILogService
    {
        void LogVisit();
        void LogException(Message message, System.Exception ex);
        void LogException(Message message);
        void LogMail(MailMessage mailMessage);
    }
}
