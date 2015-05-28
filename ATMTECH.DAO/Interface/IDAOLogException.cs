using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.DAO.Interface
{
    public interface IDAOLogException
    {
        void CreateLog(LogException logException);
        IList<LogException> GetAllActive();
    }
}
