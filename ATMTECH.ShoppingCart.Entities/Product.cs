using System;
using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class Product : BaseEntity
    {
        public const string PRODUCT_CATEGORY = "ProductCategory";
        public const string ENTERPRISE = "Enterprise";
        public const string IDENT = "Ident";
        public const string NAME = "Name";

        public string Ident { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal CostPrice { get; set; }
        public Enterprise Enterprise { get; set; }
        public IList<Stock> Stocks { get; set; }
        public IList<ProductFile> ProductFiles { get; set; }
        public decimal Weight { get; set; }
        public Supplier Supplier { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public string InternalIdent { get; set; }
        public bool IsNotOrderable { get; set; }

        public string ComboboxDescriptionUpdate { get { return Ident + " " + Name; } }
        public string PrincipalFileUrl
        {
            get
            {
                if (ProductFiles != null)
                {
                    foreach (ProductFile productFile in ProductFiles)
                    {
                        if (productFile.IsPrincipal)
                        {
                            return "images/product/" + productFile.File.FileName;
                        }
                    }
                }
                return "images/product/NoImageForThisProduct.jpg";
            }
        }
        public string PrincipalFileUrlWithoutDirectory
        {
            get
            {
                if (ProductFiles != null)
                {
                    foreach (ProductFile productFile in ProductFiles)
                    {
                        if (productFile.IsPrincipal)
                        {
                            return productFile.File.FileName;
                        }
                    }
                }
                return "NoImageForThisProduct.jpg";
            }
        }

    }
}
