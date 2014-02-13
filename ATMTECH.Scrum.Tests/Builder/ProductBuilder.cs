using ATMTECH.Entities;
using ATMTECH.Scrum.Entities;

namespace ATMTECH.Scrum.Tests.Builder
{
   public static class ProductBuilder
    {
       public static Product Create()
       {
           return new Product();
       }
       public static Product WithDescription(this Product product, string description)
       {
           product.Description = description;
           return product;
       }
       public static Product WithProductOwner(this Product product, User user)
       {
           product.ProductOwner = user;
           return product;
       }
    }
}
