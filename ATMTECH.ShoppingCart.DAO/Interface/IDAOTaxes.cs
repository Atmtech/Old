using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOTaxes
    {
        Taxes GetTaxes(int id);
        Taxes GetTaxesByType(string type);
    }
}
