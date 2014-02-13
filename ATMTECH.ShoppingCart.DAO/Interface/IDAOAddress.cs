using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOAddress
    {
        Address GetAddress(int id);
        int SaveAdress(Address address);
        Address FindAddress(Address address);
    }
}
