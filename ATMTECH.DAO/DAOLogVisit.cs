using ATMTECH.DAO.Interface;
using ATMTECH.Entities;

namespace ATMTECH.DAO
{
    public class DAOLogVisit : BaseDao<LogVisit, int>, IDAOLogVisit
    {
        public int UpdateLogVisit(LogVisit logVisit)
        {
            return Save(logVisit);
        }
    }
}
