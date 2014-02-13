using System.Collections.Generic;
using ATMTECH.Scrum.Entities;

namespace ATMTECH.Scrum.DAO.Interface
{
    public interface IDAOSprint
    {
        IList<Sprint> GetByProduct(int idProduct);
        IList<Sprint> GetAllSprint();
        Sprint GetSprint(int idSprint);
        int SaveSprint(Sprint sprint);
    }
}
