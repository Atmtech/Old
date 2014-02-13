using System.Collections.Generic;
using ATMTECH.Entities;


namespace ATMTECH.DAO.Interface
{
    public interface IDAOMenu
    {
        IList<Menu> GetMenu(string menuId);
    }
}
