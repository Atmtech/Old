using System.Collections.Generic;
using ATMTECH.Scrum.DAO.Interface;
using ATMTECH.Scrum.Entities;
using ATMTECH.Scrum.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.Scrum.Services
{
    public class ProductService : BaseService, IProductService
    {
        public IDAOProduct DaoProduct { get; set; }
        
        public void CreateProduct(Product product)
        {
            DaoProduct.CreateProduct(product);
        }

        public Product GetProduct(int id)
        {
            return DaoProduct.GetProduct(id);
        }

        public IList<Product> GetAllProduct()
        {
            return DaoProduct.GetAllProduct();
        }

        public void UpdateProduct(Product product)
        {
            DaoProduct.UpdateProduct(product);
        }
    }
}
