using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Exception;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Web.Services
{
    public class MessageService : BaseService, IMessageService
    {

        public IDAOMessage DAOMessage { get; set; }
        public ILogService LogService { get; set; }

        public void ThrowMessage(string innerId)
        {
            Message message = DAOMessage.GetMessage(innerId);
            LogService.LogException(message);
            throw new BaseException(message);
        }

        public void ThrowMessage(string innerId, string parameter)
        {
            Message message = DAOMessage.GetMessage(innerId);
            message.Description = string.Format(message.Description, parameter);
            LogService.LogException(message);
            throw new BaseException(message);
        }

        public void ThrowMessage(string innerId, System.Exception ex)
        {
            Message message = DAOMessage.GetMessage(innerId);
            LogService.LogException(message, ex);
            throw new BaseException(message);
        }


    }
}
