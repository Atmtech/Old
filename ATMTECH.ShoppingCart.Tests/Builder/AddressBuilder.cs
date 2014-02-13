using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Tests.Builder
{
    public static class AddressBuilder
    {

        public static Address Create()
        {
            return new Address() {Id = 1};
        }

        public static Address CreateValid()
        {
            return Create()
                    .WithNo("10")
                    .WithWayType("rue")
                    .WithWay("Nom de la rue");
        }


        public static Address WithWayType(this Address address, string wayType)
        {
            address.WayType = wayType;
            return address;
        }

        public static Address WithNo(this Address address, string no)
        {
            address.No = no;
            return address;
        }

        public static Address WithWay(this Address address, string way)
        {
            address.Way = way;
            return address;
        }

        public static Address WithPostalCase(this Address address, string postalCase)
        {
            address.PostalCase = postalCase;
            return address;
        }

        public static Address WithPostalCode(this Address address, string postalCode)
        {
            address.PostalCode = postalCode;
            return address;
        }

        public static Address WithId(this Address address, int id)
        {
            address.Id = id;
            return address;
        }

        public static Address WithCity(this Address address, City city)
        {
            address.City = city;
            return address;
        }

        public static  Address WithCountry(this Address address, Country country)
        {
            address.Country = country;
            return address;
        }

        //public static Address CreateAddress(string way, string no, string postalCode)
        //{
        //    return new Address()
        //               {
        //                   WayType = "Rue",
        //                   No = no,
        //                   Way = way,
        //                   PostalCase = "1",
        //                   PostalCode = postalCode
        //               };
        //}
    }
}
