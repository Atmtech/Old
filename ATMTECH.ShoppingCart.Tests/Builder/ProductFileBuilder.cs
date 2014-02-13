using System.IO;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Tests.Builder
{
    public static class ProductFileBuilder
    {
        public static ProductFile Create()
        {
            return new ProductFile() { Id = 1 };
        }

        public static ProductFile WithProduct(this ProductFile productFile, Product product)
        {
            productFile.Product = product;
            return productFile;
        }

        public static ProductFile WithFile(this ProductFile productFile, ATMTECH.Entities.File file)
        {
            productFile.File = file;
            return productFile;
        }
        public static ProductFile IsPrincipal(this ProductFile productFile, bool isPrincipal)
        {
            productFile.IsPrincipal = isPrincipal;
            return productFile;
        }
        public static ProductFile WithProductLinked(this ProductFile productFile, Product product)
        {
            productFile.ProductLinked = product;
            return productFile;
        }
    }
}
