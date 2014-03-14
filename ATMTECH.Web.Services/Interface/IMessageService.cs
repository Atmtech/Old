using ATMTECH.Entities;

namespace ATMTECH.Web.Services.Interface
{
    public interface IMessageService
    {
        void ThrowMessage(string innerId);
        void ThrowMessage(string innerId, string parameter);
        void ThrowMessage(string innerId, System.Exception ex);
        Message GetMessage(string innerId);
    }
}
