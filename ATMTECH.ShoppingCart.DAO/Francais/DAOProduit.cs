using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Francais
{
    public class DAOProduit : BaseDao<Product, int>, IDAOProduit
    {
        public IDAOProduitFichier DAOProduitFichier { get; set; }
        public IDAOInventaire DAOInventaire { get; set; }
        public IList<Product> ObtenirListeProduitEnVente(int id)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaEnterprise = new Criteria { Column = Product.ENTERPRISE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = id.ToString() };
            Criteria criteriaSaleNotNull = new Criteria { Column = Product.SALE_PRICE, Operator = DatabaseOperator.OPERATOR_GREATER_THAN, Value = "0" };
            criterias.Add(criteriaEnterprise);
            criterias.Add(criteriaSaleNotNull);
            criterias.Add(IsActive());
            OrderOperation orderOperation = new OrderOperation { OrderByColumn = BaseEntity.ORDER_ID, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };
            IList<Product> products = GetByCriteria(criterias, pagingOperation, orderOperation);
            foreach (Product product in products)
            {
                product.ProductFiles = DAOProduitFichier.ObtenirListeFichier(product.Id);
            }
            return products;
        }
        public IList<Product> ObtenirListeProduitEstSlideShow(int id)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaEnterprise = new Criteria { Column = Product.ENTERPRISE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = id.ToString() };
            Criteria criteriaSaleNotNull = new Criteria { Column = Product.IS_SLIDE_SHOW, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = "1" };
            criterias.Add(criteriaEnterprise);
            criterias.Add(criteriaSaleNotNull);
            criterias.Add(IsActive());
            OrderOperation orderOperation = new OrderOperation { OrderByColumn = BaseEntity.ORDER_ID, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };
            IList<Product> products = GetByCriteria(criterias, pagingOperation, orderOperation);


            //(1-convert(decimal,1)/convert(decimal,10)) * 100
            foreach (Product product in products)
            {
                product.ProductFiles = DAOProduitFichier.ObtenirListeFichier(product.Id);
            }
            return products;
        }

        public IList<string> ObtenirListeMarque()
        {
            IList<string> retour = new List<string>();

            SqlConnection currentDatabaseConnection = DatabaseOperation.MsSql.CurrentDatabaseConnection;
            using (SqlConnection sqlConnection = new SqlConnection(currentDatabaseConnection.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("select distinct brand FROM product order by brand", sqlConnection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        retour.Add(reader[0].ToString());
                    }
                }
            }

            return retour;
        }

        public Product ObtenirProduit(int id)
        {
            Product product = GetById(id);
            product.ProductFiles = DAOProduitFichier.ObtenirListeFichier(product.Id);
            product.Stocks = DAOInventaire.ObtenirInventaire(product);
            return product;
        }

        public Product ObtenirProduitParIdentification(string ident)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaRecherche = new Criteria { Column = Product.IDENT, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = ident };
            criterias.Add(criteriaRecherche);
            criterias.Add(IsActive());
            OrderOperation orderOperation = new OrderOperation { OrderByColumn = BaseEntity.ORDER_ID, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };
            return GetByCriteria(criterias, pagingOperation, orderOperation).First();
        }

        public IList<Product> ObtenirProduit(string recherche)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaRecherche = new Criteria { Column = BaseEntity.SEARCH, Operator = DatabaseOperator.OPERATOR_LIKE, Value = recherche };
            criterias.Add(criteriaRecherche);
            criterias.Add(IsActive());
            OrderOperation orderOperation = new OrderOperation { OrderByColumn = BaseEntity.ORDER_ID, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };
            IList<Product> produits = GetByCriteria(criterias, pagingOperation, orderOperation);
            foreach (Product product in produits)
            {
                product.ProductFiles = DAOProduitFichier.ObtenirListeFichier(product.Id);
            }

            return produits;
        }
        public IList<Product> ObtenirProduitParMarque(string marque)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaRecherche = new Criteria { Column = Product.BRAND, Operator = DatabaseOperator.OPERATOR_LIKE, Value = marque };
            criterias.Add(criteriaRecherche);
            criterias.Add(IsActive());
            OrderOperation orderOperation = new OrderOperation { OrderByColumn = BaseEntity.ORDER_ID, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };
            IList<Product> produits = GetByCriteria(criterias, pagingOperation, orderOperation);
            foreach (Product product in produits)
            {
                product.ProductFiles = DAOProduitFichier.ObtenirListeFichier(product.Id);
            }

            return produits;
        }
        public IList<Product> ObtenirProduit()
        {
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(IsActive());
            OrderOperation orderOperation = new OrderOperation { OrderByColumn = BaseEntity.ORDER_ID, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation { PageIndex = DatabaseOperator.NO_PAGING, PageSize = DatabaseOperator.NO_PAGING };
            return GetByCriteria(criterias, pagingOperation, orderOperation);
        }
    }
}
