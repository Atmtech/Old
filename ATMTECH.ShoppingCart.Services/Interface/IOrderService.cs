using System;
using System.Collections.Generic;
using System.IO;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.DTO;
using ATMTECH.ShoppingCart.Services.Reports.DTO;

namespace ATMTECH.ShoppingCart.Services.Interface
{
    public interface IOrderService
    {
        int CreateOrder(Order order, ShippingParameter shippingParameter);
        Order GetOrder(int idOrder);
        int UpdateOrder(Order order, ShippingParameter shippingParameter);
        Order GetWishListFromCustomer(Customer customer);
        IList<Order> GetOrdersFromCustomer(Customer customer, int orderStatus);
        int FinalizeOrder(Order order, ShippingParameter shippingParameter);
        Order AddOrderLine(OrderLine orderLine, Order order);
        IList<Order> GetOrderToReport(int idOrder);
        IList<OrderLine> GetOrderLineToReport(int idOrder);
        decimal GetShippingTotal(Order order, ShippingParameter shippingParameter);
        void FinalizeOrderPaypal(Order order, ShippingParameter shippingParameter);
        void PrintOrder(Order order);
        Stream ReturnOrderReport(Order order);
        void ConfirmOrder(int idOrder);
        IList<SalesReportLine> GetSalesReportLine(Enterprise enterprise, DateTime dateStart, DateTime dateEnd);
        IList<Product> GetFavoriteProductFromOrder(Enterprise enterprise, int take);
        IList<ProductBySale> GetProductBySale(Enterprise enterprise);
        IList<Order> GetOrder(int idEnterprise, int pageIndex);
        string GetOrderWithFormat(int idOrder);

        IList<ProductPriceHistoryReportLine> GetProductPriceHistoryReportLine(Enterprise enterprise,
                                                                              DateTime dateStart,
                                                                              DateTime dateEnd);

        IList<SalesByMonthReportLine> GetSalesByMonthReportLine(Enterprise enterprise, DateTime dateStart,
                                                                DateTime dateEnd);

        IList<EnumOrderInformation> GetOrderInformation(Enterprise enterprise, string group);
        IList<SalesByOrderInformationReportLine> GetSalesByOrderInformationReportLine(Enterprise enterprise, DateTime dateStart, DateTime dateEnd);
        void UpdateOrderLine(OrderLine orderLine);
    }
}
