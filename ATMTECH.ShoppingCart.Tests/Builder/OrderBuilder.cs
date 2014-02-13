using System;
using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Tests.Builder
{
    public static class OrderBuilder
    {
        public static Order Create()
        {
            return new Order() { Id = 1 };
        }

        public static Order CreateValid()
        {
            Order order = Create().WithGrandTotal(100).WithCustomer(CustomerBuilder.CreateValid()).WithEnterprise(EnterpriseBuilder.CreateValid());

            order.OrderLines = new List<OrderLine>();
            return order;
        }

        public static Order AddOrderLine(this Order order, OrderLine orderLine)
        {
            if (order.OrderLines == null)
            {
                order.OrderLines = new List<OrderLine>();
            }
            order.OrderLines.Add(orderLine);
            return order;
        }
        
        public static Order WithShippingTotal(this Order order, decimal shippingTotal)
        {
            order.ShippingTotal = shippingTotal;
            return order;
        }

        public static Order WithGrandTotal(this Order order, decimal grandTotal)
        {
            order.GrandTotal = grandTotal;
            return order;
        }

        public static Order WithShippingDate(this Order order, DateTime shippingDate)
        {
            order.ShippingDate = shippingDate;
            return order;
        }

        public static Order WithShippingAddress(this Order order, Address address)
        {
            order.ShippingAddress = address;
            return order;
        }

        public static Order WithBillingAddress(this Order order, Address address)
        {
            order.BillingAddress = address;
            return order;
        }

        public static Order WithOrderStatus(this Order order, int orderStatus)
        {
            order.OrderStatus = orderStatus;
            return order;
        }
        public static Order WithProject(this Order order, string project)
        {
            order.Project = project;
            return order;
        }

        public static Order WithTrackingNumber(this Order order, string trackingNumber)
        {
            order.TrackingNumber = trackingNumber;
            return order;
        }

        public static Order WithShippingAttention(this Order order, string shippingAttention)
        {
            order.ShippingAttention = shippingAttention;
            return order;
        }
        public static Order WithCountryTax(this Order order, decimal countryTax)
        {
            order.CountryTax = countryTax;
            return order;
        }

        public static Order WithRegionalTax(this Order order, decimal regionalTax)
        {
            order.RegionalTax = regionalTax;
            return order;
        }

        public static Order WithEnterprise(this Order order, Enterprise enterprise)
        {
            order.Enterprise = enterprise;
            return order;
        }
        public static Order WithCustomer(this Order order, Customer customer)
        {
            order.Customer = customer;
            return order;
        }

        public static Order WithId(this Order order, int id)
        {
            order.Id = id;
            return order;
        }
    }
}
