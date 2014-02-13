using System.Collections.Generic;
using ATMTECH.Scrum.Entities;

namespace ATMTECH.Scrum.Services.Interface
{
    public interface IProductService
    {
        void CreateProduct(Product product);
        Product GetProduct(int id);
        IList<Product> GetAllProduct();
        void UpdateProduct(Product product);
    }
}
