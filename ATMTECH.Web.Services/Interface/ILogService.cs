using ATMTECH.Entities;

namespace ATMTECH.Web.Services.Interface
{
    public interface ILogService
    {
        LogVisit LogVisit();
        void LogException(Message message, System.Exception ex);
        void LogException(Message message);
    }
}
