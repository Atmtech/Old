using ATMTECH.Entities;

namespace ATMTECH.DAO.Interface
{
    public interface IDAOMessage
    {
        Message GetMessage(string innerId);
    }
}
