using System.Collections.Generic;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;

namespace ATMTECH.DAO
{
    public class DAOMessage : BaseDao<Message, int>, IDAOMessage
    {
        public Message GetMessage(string innerId)
        {
            return GetAllOneCriteria(Message.INNERID, innerId)[0];
        }
    }
}
