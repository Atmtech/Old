using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface
{
    public interface ICustomerService
    {
        Customer AuthenticateCustomer { get; }
        Customer GetCustomer(int id);
        bool CreateCustomer(Customer customer);
        void SaveCustomer(Customer customer);
        void Save(Customer customer);
        bool ConfirmCreate(int idUser);
        bool SendForgetPassword(string email);
        IList<Customer> GetCustomerByEnterprise(int idEnterprise);
        IList<Customer> GetAll();

    }
}
