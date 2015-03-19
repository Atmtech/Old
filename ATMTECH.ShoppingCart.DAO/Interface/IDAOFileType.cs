using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOFileType
    {
        IList<FileType> GetAllActive();
    }
}
