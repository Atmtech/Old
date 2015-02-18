using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.ShoppingCart.Services
{
    public class EnterpriseService : BaseService, IEnterpriseService
    {
        public IDAOEnterpriseAddress DAOEnterpriseAddress { get; set; }
        public IDAOEnterprise DAOEnterprise { get; set; }
        public IDAOEnterpriseAccess DAOEnterpriseAccess { get; set; }
        public IDAOCity DAOCity { get; set; }
        public IDAOCountry DAOCountry { get; set; }
        public IDAOEnumOrderInformation DAOEnumOrderInformation { get; set; }
        public IDAOProduct DAOProduct { get; set; }

        public IList<Enterprise> GetAll()
        {
            return DAOEnterprise.GetAll();
        }

        public int Save(Enterprise enterprise)
        {
            return DAOEnterprise.SaveEnterprise(enterprise);
        }

        public Enterprise GetEnterprise(int id)
        {
            Enterprise enterprise = DAOEnterprise.GetEnterprise(id);
            IList<City> cities = DAOCity.GetAll();
            IList<Country> countries = DAOCountry.GetAllCountries();

            foreach (Address address in enterprise.BillingAddress)
            {
                address.City = cities.FirstOrDefault(x => x.Id == address.City.Id);
                address.Country = countries.FirstOrDefault(x => x.Id == address.Country.Id);
            }

            foreach (Address address in enterprise.ShippingAddress.Where(address => address != null))
            {
                address.City = cities.FirstOrDefault(x => x.Id == address.City.Id);
                address.Country = address.Country == null
                                      ? null
                                      : countries.FirstOrDefault(x => x.Id == address.Country.Id);
            }

            return enterprise;
        }

        public IList<Enterprise> GetEnterprise()
        {
            return DAOEnterprise.GetEnterprise();
        }

        public IList<Enterprise> GetEnterpriseByAccess(User user)
        {
            IList<EnterpriseAccess> enterpriseAccesses = DAOEnterpriseAccess.GetEnterpriseAccess(user).Where(x => x.User.Id == user.Id).ToList();
            foreach (EnterpriseAccess enterpriseAccess in enterpriseAccesses)
            {
                enterpriseAccess.Enterprise = GetEnterprise(enterpriseAccess.Enterprise.Id);
            }
            return enterpriseAccesses.Select(enterprise => enterprise.Enterprise).ToList().Where(x => x.IsActive).ToList();
        }

        public void CreateEnterpriseFromAnother(int idEnterprise, string newName, User user)
        {
            Enterprise enterprise = GetEnterprise(idEnterprise);
            enterprise.Name = newName;
            enterprise.Id = 0;
            int newEnterpriseId = DAOEnterprise.SaveEnterprise(enterprise);

            Enterprise newEnterprise = DAOEnterprise.GetEnterprise(newEnterpriseId);
            DAOEnterpriseAccess.SaveEnterpriseAccess(newEnterprise, user);
            IList<Product> products = DAOProduct.GetProducts(idEnterprise);
            foreach (Product product in products)
            {
                product.Id = 0;
                product.Enterprise = newEnterprise;
                DAOProduct.Save(product);
            }
        }
    }
}
