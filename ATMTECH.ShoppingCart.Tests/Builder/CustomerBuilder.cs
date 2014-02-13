using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Tests.Builder
{
    public static class CustomerBuilder
    {
        public static Customer Create()
        {
            return new Customer() { Id = 1 };
        }

        public static Customer CreateValid()
        {
            return Create().WithUser(UserBuilder.CreateValid()).WithTaxes(TaxesBuilder.CreateValid()).WithAdress(AddressBuilder.Create()).WithEnterprise(EnterpriseBuilder.CreateValid());
        }

        public static Customer WithUser(this Customer customer, User user)
        {
            customer.User = user;   
            return customer;
        }

        public static Customer WithCustomerNumber(this Customer customer, string customerNumber)
        {
            customer.CustomerNumber = customerNumber;
            return customer;
        }

        public static Customer WithActualBudget(this Customer customer, decimal actualBudget)
        {
            customer.ActualBudget = actualBudget;
            return customer;
        }
        public static Customer WithIsPaypalAuthorized(this Customer customer, bool isPaypalAuthorized)
        {
            customer.IsPaypalAuthorized = isPaypalAuthorized;
            return customer;
        }
        public static Customer WithIsPaypalRequired(this Customer customer, bool isPaypalRequired)
        {
            customer.IsPaypalRequired = isPaypalRequired;
            return customer;
        }

        public static Customer WithCustomerType(this Customer customer, CustomerType customerType)
        {
            customer.CustomerType = customerType;
            return customer;
        }

        public static Customer WithAdress(this Customer customer, Address address)
        {
            customer.BillingAddress = address;
            customer.ShippingAddress = address;
            return customer;
        }

        public static Customer WithTaxes(this Customer customer, Taxes taxes)
        {
            customer.Taxes = taxes;
            return customer;
        }
        public static Customer WithEnterprise(this Customer customer, Enterprise enterprise)
        {
            customer.Enterprise = enterprise;
            return customer;
        }
        public static Customer WithId(this Customer customer, int id)
        {
            customer.Id = id;
            return customer;
        }
    }
}
