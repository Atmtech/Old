using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.Interface;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOProductFile : BaseDao<ProductFile, int>, IDAOProductFile
    {

        public IDAOFile DAOFile { get; set; }
        
        public IList<ProductFile> GetProductFile(int idProduct)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaProduct = new Criteria { Column = ProductFile.PRODUCT, Operator = DatabaseOperator.OPERATOR_EQUAL, Value =  idProduct.ToString() };
            criterias.Add(criteriaProduct);
            criterias.Add(IsActive());
            OrderOperation orderOperation = new OrderOperation { OrderByColumn = ProductFile.PRODUCT, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };

            IList<ProductFile> productFiles = GetByCriteria(criterias, pagingOperation, orderOperation);
            foreach (ProductFile productFile in productFiles)
            {
                productFile.File = DAOFile.GetFile(productFile.File.Id);
            }
            return productFiles;
        }
        public IList<ProductFile> GetProductFile()
        {
            return GetAllActive();
        }

        public int SaveProductFile(ProductFile productFile)
        {
            return Save(productFile);
        }

        public void DeleteProductFile(ProductFile productFile)
        {
            productFile.IsActive = false;
            Save(productFile);

        }
    }
}
