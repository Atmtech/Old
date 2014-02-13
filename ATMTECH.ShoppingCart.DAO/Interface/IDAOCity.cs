using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOCity
    {
        City GetCity(int id);
        City FindCity(string city);
        int CreateCity(City city);
    }
}
