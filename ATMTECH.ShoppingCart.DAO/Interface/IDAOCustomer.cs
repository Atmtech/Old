using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOCustomer
    {
        Customer GetCustomer(int idCustomer);
        int CreateCustomer(Customer customer);
        int SaveCustomer(Customer customer);
        IList<Customer> GetCustomerByEnterprise(int idEnterprise);
        Customer GetCustomerFromUser(int idUser);
        IList<Customer> GetAll();
        int Save(Customer customer);
    }
}
