using System.Collections.Generic;
using ATMTECH.Scrum.Entities;

namespace ATMTECH.Scrum.DAO.Interface
{
    public interface IDAOProduct
    {
        Product GetProduct(int id);
        IList<Product> GetAllProduct();
        void UpdateProduct(Product product);
        int CreateProduct(Product product);
    }
}
