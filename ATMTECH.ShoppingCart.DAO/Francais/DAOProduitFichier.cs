using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.Interface;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Francais
{
    public class DAOProduitFichier : BaseDao<ProductFile, int>, IDAOProduitFichier
    {

        public IDAOFile DAOFile { get; set; }
        public IList<ProductFile> ObtenirListeFichier(int id)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaProduct = new Criteria { Column = ProductFile.PRODUCT, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = id.ToString() };
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

        public IList<ProductFile> ObtenirFichierProduit(Enterprise enterprise)
        {
            return GetBySql(string.Format("select * from ProductFile where Product in (SELECT id FROM PRODUCT where Enterprise = {0})", enterprise.Id));
        }
    }
}
