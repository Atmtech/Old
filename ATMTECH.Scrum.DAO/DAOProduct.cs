using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Interface;
using ATMTECH.Scrum.DAO.Interface;
using ATMTECH.Scrum.Entities;

namespace ATMTECH.Scrum.DAO
{
    public class DAOProduct : BaseDao<Product, int>, IDAOProduct
    {
        public IDAOSprint DAOSprint { get; set; }
        public IDAOStory DAOStory { get; set; }
        public IDAOUser DAOUser { get; set; }

        public IList<Product> GetAllProduct()
        {
            IList<Product> products = GetAllActive();
            foreach (Product product in products)
            {
                if (product.ProductOwner != null)
                {
                    product.ProductOwner = DAOUser.GetUser(product.ProductOwner.Id);
                }

                product.Storys = DAOStory.GetByProduct(product.Id);

                product.TotalHourRemaining = (from s in product.Storys
                                              select s.TotalHourRemaining).Sum();

                product.TotalPoint = (from s in product.Storys
                                      select s.Point).Sum();
            }

            return products;
        }

        public void UpdateProduct(Product product)
        {
            Save(product);
        }
        public int CreateProduct(Product product)
        {
            return Save(product);
        }

        public Product GetProduct(int id)
        {
            Product product = GetById(id);
            product.Storys = DAOStory.GetByProduct(id);

            product.TotalPoint = (from s in product.Storys
                                  select s.Point).Sum();

            product.TotalHourRemaining = (from s in product.Storys
                                          select s.TotalHourRemaining).Sum();

            product.Sprints = DAOSprint.GetByProduct(id);

            foreach (Sprint sprint in product.Sprints)
            {
                foreach (Story storey in product.Storys)
                {
                    if (storey.Sprint.Id == sprint.Id)
                    {
                        storey.Sprint = sprint;
                    }
                }

                sprint.TotalHourRemaining = (from s in product.Storys
                                             where s.Sprint.Id == sprint.Id
                                             select s.TotalHourRemaining).Sum();
            }

            product.ProductOwner = DAOUser.GetUser(product.ProductOwner.Id);
            return product;
        }
    }
}
