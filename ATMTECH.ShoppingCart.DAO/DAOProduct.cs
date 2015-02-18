using System.Collections.Generic;
using System.Linq;
using ATMTECH.Common.Context;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOProduct : BaseDao<Product, int>, IDAOProduct
    {
        public IDAOEnterprise DAOEnterprise { get; set; }
        public IDAOSupplier DAOSupplier { get; set; }
        public IDAOProductCategory DAOProductCategory { get; set; }
        public IDAOProductFile DAOProductFile { get; set; }
        public IDAOStock DAOStock { get; set; }
        public IDAOGroupProduct DAOGroupProduct { get; set; }
        public IDAOFile DAOFile { get; set; }

        public string CurrentLanguage
        {
            get
            {
                return ContextSessionManager.Session["currentLanguage"] == null
                           ? "fr"
                           : ContextSessionManager.Session["currentLanguage"].ToString();
            }
        }
        public IList<Product> GetProductsWithoutStock(int id)
        {
            return
                GetBySql(
            "select Product.Id,Product.Description,Product.IsActive,Product.DateCreated,Product.DateModified,Product.Language,Product.OrderId,Product.Search,Product.ComboboxDescription,Product.Ident,Product.UnitPrice,Product.CostPrice,Product.Enterprise,Product.Weight,Product.Supplier,Product.InternalIdent,Product.DescriptionFrench,Product.DescriptionEnglish,Product.ProductCategoryFrench,Product.ProductCategoryEnglish,Product.NameFrench,Product.NameEnglish,Product.IsNotOrderable from Product Where Id not in (SELECT Product From Stock) and Enterprise = " + id);
        }
        public Product GetProduct(int id)
        {
            Product product = GetById(id);
            if (product != null)
            {
                product.Enterprise = DAOEnterprise.GetEnterprise(product.Enterprise.Id);
                product.Supplier = DAOSupplier.GetSupplier(product.Supplier.Id);
                product.ProductCategoryEnglish = DAOProductCategory.GetProductCategory(product.ProductCategoryEnglish.Id);
                product.ProductCategoryFrench = DAOProductCategory.GetProductCategory(product.ProductCategoryFrench.Id);
                product.ProductFiles = DAOProductFile.GetProductFile(product.Id);
                product.Stocks = DAOStock.GetProductStock(product.Id);    
            }
            
            return product;
        }
        public Product GetProductSimple(int id)
        {
            return GetById(id);
        }
        public IList<Product> GetProductsWithoutLanguage(int idEnterprise)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaEnterprise = new Criteria { Column = Product.ENTERPRISE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idEnterprise.ToString() };

            criterias.Add(criteriaEnterprise);
            criterias.Add(IsActive());

            OrderOperation orderOperation = new OrderOperation { OrderByColumn = Product.PRODUCT_CATEGORY_FRENCH, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };
            IList<Product> products = GetByCriteria(criterias, pagingOperation, orderOperation);
            IList<Stock> stockAll = DAOStock.GetAllStock();
            IList<ProductFile> productFiles = DAOProductFile.GetAll();
            IList<File> files = DAOFile.GetAllFile();
            foreach (ProductFile productFile in productFiles)
            {
                productFile.File = files.FirstOrDefault(x => x.Id == productFile.File.Id);
            }

            foreach (Product product in products)
            {
                product.ProductFiles = productFiles.Where(x => x.Product.Id == product.Id).ToList();
                IList<Stock> stocks = stockAll.Where(x => x.Product.Id == product.Id).ToList();
                foreach (Stock stock in stocks)
                {
                    stock.Product = product;
                }
                product.Stocks = stocks;
            }
            return products;
        }
        public IList<Product> GetProductsSimple(int idEnterprise)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaEnterprise = new Criteria { Column = Product.ENTERPRISE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idEnterprise.ToString() };

            criterias.Add(criteriaEnterprise);
            criterias.Add(IsActive());

            OrderOperation orderOperation = new OrderOperation { OrderByColumn = Product.PRODUCT_CATEGORY_FRENCH, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };
            return GetByCriteria(criterias, pagingOperation, orderOperation);
        }
        public IList<Product> GetProducts(int idEnterprise)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaEnterprise = new Criteria { Column = Product.ENTERPRISE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idEnterprise.ToString() };

            criterias.Add(criteriaEnterprise);
            criterias.Add(IsActive());

            OrderOperation orderOperation = new OrderOperation { OrderByColumn = Product.PRODUCT_CATEGORY_FRENCH, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };
            IList<Product> products = GetByCriteria(criterias, pagingOperation, orderOperation);
            
            foreach (Product product in products)
            {
                product.ProductFiles = DAOProductFile.GetProductFile(product.Id);
                IList<Stock> stocks = DAOStock.GetProductStock(product.Id);
                foreach (Stock stock in stocks)
                {
                    stock.Product = product;
                }
                product.Stocks = stocks;
            }
            return products;
        }
        public IList<Product> GetProducts(int idEnterprise, int idUser, string search)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaEnterprise = new Criteria { Column = Product.ENTERPRISE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idEnterprise.ToString() };
            Criteria criteriaProductSearch = new Criteria { Column = BaseEntity.SEARCH, Operator = DatabaseOperator.OPERATOR_LIKE, Value = search };

            criterias.Add(criteriaEnterprise);
            criterias.Add(criteriaProductSearch);
            criterias.Add(IsActive());

            OrderOperation orderOperation = new OrderOperation { OrderByColumn = Product.PRODUCT_CATEGORY_FRENCH, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };
            IList<Product> products = GetByCriteria(criterias, pagingOperation, orderOperation);
            foreach (Product product in products)
            {
                product.ProductFiles = DAOProductFile.GetProductFile(product.Id);
            }
            return FillProductWithSecurity(idUser, products);
        }
        public IList<Product> GetProducts(int idEnterprise, int idProductCategory, int idUser)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaEnterprise = new Criteria { Column = Product.ENTERPRISE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idEnterprise.ToString() };
            Criteria criteriaProductCategory = CurrentLanguage == "fr" ? new Criteria { Column = Product.PRODUCT_CATEGORY_FRENCH, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idProductCategory.ToString() } : new Criteria { Column = Product.PRODUCT_CATEGORY_ENGLISH, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idProductCategory.ToString() };
            criterias.Add(criteriaProductCategory);
            criterias.Add(criteriaEnterprise);
            criterias.Add(IsActive());
            OrderOperation orderOperation = new OrderOperation { OrderByColumn = Product.PRODUCT_CATEGORY_FRENCH, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };
            IList<Product> products = GetByCriteria(criterias, pagingOperation, orderOperation);
            foreach (Product product in products)
            {
                product.ProductFiles = DAOProductFile.GetProductFile(product.Id);
            }
            return FillProductWithSecurity(idUser, products);
        }
        public bool GetProductAccessOrderable(Product product, int idUser)
        {
            return !product.Enterprise.IsSecure || DAOGroupProduct.GetProductAccess(product, idUser).IsOrderable;
        }
        public IList<Product> GetProducts(int idEnterprise, int idProductCategory)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaEnterprise = new Criteria { Column = Product.ENTERPRISE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idEnterprise.ToString() };
            Criteria criteriaProductCategory = CurrentLanguage == "fr" ? new Criteria { Column = Product.PRODUCT_CATEGORY_FRENCH, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idProductCategory.ToString() } : new Criteria { Column = Product.PRODUCT_CATEGORY_ENGLISH, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idProductCategory.ToString() };

            criterias.Add(criteriaEnterprise);
            criterias.Add(criteriaProductCategory);
            criterias.Add(IsActive());

            OrderOperation orderOperation = new OrderOperation { OrderByColumn = Product.PRODUCT_CATEGORY_FRENCH, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };

            IList<Product> products = GetByCriteria(criterias, pagingOperation, orderOperation);

            foreach (Product product in products)
            {
                product.ProductFiles = DAOProductFile.GetProductFile(product.Id);
            }
            return products;
        }
        public int GetProductCount(int idEnterprise)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaEnterprise = new Criteria { Column = Product.ENTERPRISE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = idEnterprise.ToString() };

            criterias.Add(criteriaEnterprise);
            criterias.Add(IsActive());

           // SetLanguage(criterias, CurrentLanguage);

            IList<Product> products = GetByCriteria(criterias);
            return products.Count;
        }
        private IList<Product> FillProductWithSecurity(int idUser, IList<Product> products)
        {
            IList<Product> productsReturn = idUser != 0 ? products.Where(product => DAOGroupProduct.GetProductAccess(product, idUser).IsRead).ToList() : products;
            foreach (Product product in productsReturn)
            {
                product.ProductFiles = DAOProductFile.GetProductFile(product.Id);
            }
            return productsReturn;
        }
    }
}
