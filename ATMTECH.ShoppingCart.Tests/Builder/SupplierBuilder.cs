using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Tests.Builder
{
    public static class SupplierBuilder
    {
        public static Supplier Create()
        {
            return new Supplier() { Id = 1 };
        }
        public static Supplier WithName(this Supplier supplier, string name)
        {
            supplier.Name = name;
            return supplier;
        }
        public static Supplier WithId(this Supplier supplier, int id)
        {
            supplier.Id = id;
            return supplier;
        }
    }
}
