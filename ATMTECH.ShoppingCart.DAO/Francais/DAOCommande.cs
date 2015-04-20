using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Francais
{
    public class DAOCommande : BaseDao<Order, int>, IDAOCommande
    {
        public IDAOLigneCommande DAOLigneCommande { get; set; }
        public IDAOAddress DAOAddress { get; set; }
        public IDAOInventaire DAOInventaire { get; set; }
        public IDAOProduit DAOProduit { get; set; }
        public IDAOCountry DAOCountry { get; set; }
        public IDAOClient DAOClient { get; set; }
        public IDAOEnterprise DAOEnterprise { get; set; }
        public IDAOCoupon DAOCoupon { get; set; }

        public Order ObtenirCommandeSouhaite(Customer customer)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaUser = new Criteria { Column = Order.CUSTOMER, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = customer.Id.ToString() };
            Criteria criteriaCommandeStatus = new Criteria { Column = Order.ORDER_STATUS, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = OrderStatus.IsWishList.ToString() };
            criterias.Add(criteriaUser);
            criterias.Add(criteriaCommandeStatus);
            criterias.Add(IsActive());
            IList<Order> commandes = GetByCriteria(criterias);
            foreach (Order commande in commandes)
            {
                commande.OrderLines = DAOLigneCommande.ObtenirLigneCommande(commande);
                commande.ShippingAddress = DAOAddress.GetAddress(commande.ShippingAddress.Id);
                commande.BillingAddress = DAOAddress.GetAddress(commande.BillingAddress.Id);
                if (commande.ShippingAddress != null)
                    commande.ShippingAddress.Country = DAOCountry.GetCountry(commande.ShippingAddress.Country.Id);
                if (commande.BillingAddress != null)
                    commande.BillingAddress.Country = DAOCountry.GetCountry(commande.BillingAddress.Country.Id);
                foreach (OrderLine orderLine in commande.OrderLines)
                {
                    orderLine.Stock = DAOInventaire.ObtenirInventaire(orderLine.Stock.Id);
                    orderLine.Stock.Product = DAOProduit.ObtenirProduit(orderLine.Stock.Product.Id);
                }
                commande.Coupon = DAOCoupon.GetById(commande.Coupon.Id);
            }

            return commandes.Count > 0 ? commandes[0] : null;
        }
        public Order ObtenirCommande(int id)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaOrder = new Criteria { Column = BaseEntity.ID, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = id.ToString() };
            criterias.Add(criteriaOrder);
            criterias.Add(IsActive());
            IList<Order> commandes = GetByCriteria(criterias);
            foreach (Order commande in commandes)
            {
                commande.Enterprise = DAOEnterprise.GetEnterprise(commande.Enterprise.Id);
                commande.Customer = DAOClient.ObtenirClient(commande.Customer.Id);
                commande.OrderLines = DAOLigneCommande.ObtenirLigneCommande(commande);

                commande.ShippingAddress = DAOAddress.GetAddress(commande.ShippingAddress.Id);
                commande.ShippingAddress.Country = DAOCountry.GetCountry(commande.ShippingAddress.Country.Id);
                commande.BillingAddress = DAOAddress.GetAddress(commande.BillingAddress.Id);
                commande.BillingAddress.Country = DAOCountry.GetCountry(commande.BillingAddress.Country.Id);

                foreach (OrderLine orderLine in commande.OrderLines)
                {
                    orderLine.Stock = DAOInventaire.ObtenirInventaire(orderLine.Stock.Id);
                    orderLine.Stock.Product = DAOProduit.ObtenirProduit(orderLine.Stock.Product.Id);
                }
            }

            return commandes.Count > 0 ? commandes[0] : null;
        }
        public IList<Order> ObtenirCommande(Customer customer)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaUser = new Criteria { Column = Order.CUSTOMER, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = customer.Id.ToString() };
            Criteria criteriaCommandeStatus = new Criteria { Column = Order.ORDER_STATUS, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = OrderStatus.IsOrdered.ToString() };
            criterias.Add(criteriaUser);
            criterias.Add(criteriaCommandeStatus);
            criterias.Add(IsActive());
            return GetByCriteria(criterias);
        }
    }
}
