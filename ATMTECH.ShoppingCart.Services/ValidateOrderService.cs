using System.Linq;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Services
{
    public class ValidateOrderService : BaseService, IValidateOrderService
    {
        public IMessageService MessageService { get; set; }
        public IStockService StockService { get; set; }
        public IProductService ProductService { get; set; }
        public IDAOStockTransaction DAOStockTransaction { get; set; }

        public void IsValidOrder(Order order)
        {
            if (order == null)
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_ORDER_NULL);
            }

            IsValidOrderLine(order);
            IsValidOrderStatus(order);
            IsValidEnterprise(order);
            IsValidCustomer(order);
            IsValidStock(order);
        }

        public void IsValidIfOrderInformationIsEnabled(Order order)
        {
            if (order.Enterprise.IsManageOrderInformation1 && order.Enterprise.IsManageOrderInformation2)
            {
                if (string.IsNullOrEmpty(order.OrderInformation1) || string.IsNullOrEmpty(order.OrderInformation2))
                {
                    MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_IF_ORDER_INFORMATION_MANAGED_CANT_BE_EMPTY);
                }
            }
        }
        private void IsValidStock(Order order)
        {
            foreach (OrderLine orderLine in order.OrderLines)
            {
                if (!StockService.ValidateStockQuantity(orderLine.Stock, orderLine.Quantity) && orderLine.Stock.IsWithoutStock == false)
                {

                    string productDescription = string.Format("{0} :: {1}",
                                                              ProductService.GetProduct(orderLine.Stock.Product.Id).ComboboxDescription,
                                                              orderLine.Stock.FeatureFrench + "<br>" + orderLine.Stock.FeatureEnglish);

                    string parameter = string.Format("{0} - {1}", productDescription,
                                                     DAOStockTransaction.GetCurrentStockStatus(orderLine.Stock));

                    MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_STOCK_INSUFICIENT, parameter);
                    break;
                }
            }
        }

        private void IsValidCustomer(Order order)
        {
            if (order.Customer == null)
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_NO_CUSTOMER_LINKED_TO_ORDER);
            }

            if (order.Customer != null && order.Customer.Taxes == null)
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_NO_TAXE_TYPE);
            }
        }
        private void IsValidEnterprise(Order order)
        {
            if (order.Enterprise == null)
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_ENTERPRISE_NULL_ORDER);
            }
            if (order.Enterprise != null && order.Enterprise.IsOrderPossible == false)
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_ENTERPRISE_CANT_ORDER);
            }
        }
        private void IsValidOrderStatus(Order order)
        {
            if (order.OrderStatus != OrderStatus.IsWishList && order.OrderStatus != OrderStatus.IsOrdered && order.OrderStatus != OrderStatus.IsShipped)
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_ORDERSTATUS_UNKNOWN);
            }
        }
        public void IsValidAddress(Order order)
        {
            if (order.ShippingAddress == null)
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_SHIPPING_ADDRESS_NULL);
            }

            if (order.BillingAddress == null)
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_BILLING_ADDRESS_NULL);
            }
        }
        private void IsValidOrderLine(Order order)
        {
            if (order.OrderLines == null)
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_ORDERLINE_NULL);
            }

            if (order.OrderLines != null && order.OrderLines.Count == 0)
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_ORDERLINE_COUNT_ZERO);
            }

            if (order.OrderLines != null && order.OrderLines.Any(orderLine => orderLine.Stock.Product.Id == 0))
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_ORDERLINE_PRODUCT_ID_ZERO);
            }
        }
    }
}
