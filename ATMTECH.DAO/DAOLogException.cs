using ATMTECH.DAO.Interface;
using ATMTECH.Entities;

namespace ATMTECH.DAO
{
    public class DAOLogException : BaseDao<LogException, int>, IDAOLogException
    {
        public void CreateLog(LogException logException)
        {
            Save(logException);
        }
    }
}
