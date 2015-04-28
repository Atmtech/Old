using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Administration.DAO.Interface
{
    public interface IDAOProprieteEdition
    {
        IList<ProprieteEdition> GetAllActive();
    }
}
