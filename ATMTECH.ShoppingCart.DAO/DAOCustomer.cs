using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOCustomer : BaseDao<Customer, int>, IDAOCustomer
    {
        public IDAOUser DAOUser { get; set; }
        public IDAOEnterprise DAOEnterprise { get; set; }
        public IDAOTaxes DAOTaxes { get; set; }

        public IList<Customer> GetCustomerByEnterprise(int idEnterprise)
        {
            IList<Customer> customers = GetAllOneCriteria(Customer.ENTERPRISE, idEnterprise.ToString());
            foreach (Customer customer in customers)
            {
                customer.User = DAOUser.GetUser(customer.User.Id);
            }
            return customers;
        }

        public Customer GetCustomerFromUser(int idUser)
        {
            IList<Customer> customers = GetAllOneCriteria(Customer.USER, idUser.ToString());
            if (customers.Count > 0)
            {
                Customer customer = customers[0];
                customer.User = DAOUser.GetUser(customer.User.Id);
                customer.Enterprise = DAOEnterprise.GetEnterprise(customer.Enterprise.Id);

                // Pour l'instant on calcul la taxe pour QBC seulement. On verra plus tard si on en a besoin
                customer.Taxes = DAOTaxes.GetTaxesByType("QBC");
                return customer;
            }

            return null;
        }

        public Customer GetCustomer(int idCustomer)
        {
            IList<Customer> customers = GetAllOneCriteria(BaseEntity.ID, idCustomer.ToString());
            if (customers.Count > 0)
            {
                Customer customer = customers[0];
                customer.User = DAOUser.GetUser(customer.User.Id);
                customer.Enterprise = DAOEnterprise.GetEnterprise(customer.Enterprise.Id);

                // Pour l'instant on calcul la taxe pour QBC seulement. On verra plus tard si on en a besoin
                customer.Taxes = DAOTaxes.GetTaxesByType("QBC");
                return customer;
            }

            return null;

        }

        public int CreateCustomer(Customer customer)
        {
            int rtn = Save(customer);
            return rtn;
        }

        public int SaveCustomer(Customer customer)
        {
            int rtn = Save(customer);
            DAOUser.UpdateUser(customer.User);
            return rtn;
        }
    }
}
