using System.Collections.Generic;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Views
{
    public class AjouterProduitAuPanierPresenter : BaseShoppingCartPresenter<IAjouterProduitAuPanierPresenter>
    {
        public IProductService ProductService { get; set; }
        public IDAOOrder DAOOrder { get; set; }
        public ICustomerService CustomerService { get; set; }
        public IOrderService OrderService { get; set; }
        public IStockService StockService { get; set; }

        public AjouterProduitAuPanierPresenter(IAjouterProduitAuPanierPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherProduit(View.IdProduit);
        }

        public void AfficherProduit(int idProduit)
        {
            View.Produit = ProductService.GetProduct(idProduit);
        }

        public void AjouterLigneCommande()
        {
            IList<Order> orderFromCustomer = DAOOrder.GetOrderFromCustomer(CustomerService.AuthenticateCustomer, OrderStatus.IsWishList);
            if (orderFromCustomer.Count == 0)
            {
                Order order = new Order
                    {
                        OrderStatus = OrderStatus.IsWishList,
                        Customer = CustomerService.AuthenticateCustomer,
                        Enterprise = CustomerService.AuthenticateCustomer.Enterprise,
                        ShippingAddress = CustomerService.AuthenticateCustomer.ShippingAddress,
                        BillingAddress = CustomerService.AuthenticateCustomer.BillingAddress,
                        OrderLines = new List<OrderLine>()
                    };

                SauvegarderAvecLigneCommande(order);
            }
            else
            {
                Order order = OrderService.GetOrder(orderFromCustomer[0].Id);
                SauvegarderAvecLigneCommande(order);
            }
        }

        private void SauvegarderAvecLigneCommande(Order order)
        {
            Order commandeObtenu = OrderService.GetOrder(OrderService.CreateOrder(order, null));
            OrderLine orderLine = new OrderLine
                {
                    Stock = StockService.GetStock(View.Inventaire),
                    Quantity = View.Quantite
                };

            OrderService.AddOrderLine(orderLine, commandeObtenu);
            OrderService.UpdateOrder(commandeObtenu, null);
        }
    }
}

