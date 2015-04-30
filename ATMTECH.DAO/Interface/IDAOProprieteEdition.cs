using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.DAO.Interface
{
    public interface IDAOProprieteEdition
    {
        IList<ProprieteEdition> GetAllActive();
    }
}
