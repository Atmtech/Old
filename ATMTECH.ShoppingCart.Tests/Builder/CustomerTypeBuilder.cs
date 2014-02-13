using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Tests.Builder
{
    public static class CustomerTypeBuilder
    {
        public static CustomerType Create()
        {
            return new CustomerType() { Id = 1 };
        }

        public static CustomerType WithId(this CustomerType customerType, int id)
        {
            customerType.Id = id;
            return customerType;
        }

        public static  CustomerType WithCode(this CustomerType customerType, string code)
        {
            customerType.Code = code;
            return customerType;
        }

        public static CustomerType WithDescription(this CustomerType customerType, string description)
        {
            customerType.Description = description;
            return customerType;
        }


      
    }
}
