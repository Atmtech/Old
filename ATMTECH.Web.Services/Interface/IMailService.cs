using System.IO;

namespace ATMTECH.Web.Services.Interface
{
    public interface IMailService
    {
        bool SendEmail(string to, string from, string subject, string body);
        bool SendEmail(string to, string from, string subject, string body, Stream file, string fileName);
    }
}
