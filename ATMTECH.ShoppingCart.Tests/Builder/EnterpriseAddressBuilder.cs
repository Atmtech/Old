using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Tests.Builder
{
    public static class EnterpriseAddressBuilder
    {
        public static EnterpriseAddress Create()
        {
            return new EnterpriseAddress() { Id = 1 };
        }

        public static  EnterpriseAddress WithAddress(this EnterpriseAddress enterpriseAddress, Address address)
        {
            enterpriseAddress.Address = address;
            return enterpriseAddress;
        }

        public static EnterpriseAddress WithAddressType(this EnterpriseAddress enterpriseAddress, string addressType)
        {
            enterpriseAddress.AddressType = addressType;
            return enterpriseAddress;
        }

        public static EnterpriseAddress WithEnterprise(this EnterpriseAddress enterpriseAddress, Enterprise enterprise)
        {
            enterpriseAddress.Enterprise = enterprise;
            return enterpriseAddress;
        }

    }
}
