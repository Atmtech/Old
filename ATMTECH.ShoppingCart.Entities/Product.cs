using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class Product : BaseEntity
    {
        public const string PRODUCT_CATEGORY_FRENCH = "ProductCategoryFrench";
        public const string PRODUCT_CATEGORY_ENGLISH = "ProductCategoryEnglish";
        public const string ENTERPRISE = "Enterprise";
        public const string IDENT = "Ident";
        public const string NAME = "Name";
        public const string SALE_PRICE = "SalePrice";
        public const string IS_SLIDE_SHOW = "IsSlideShow";
        public const string BRAND = "Brand";

        public string Ident { get; set; }
        public string NameFrench { get; set; }
        public string NameEnglish { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public Enterprise Enterprise { get; set; }
        public IList<Stock> Stocks { get; set; }
        public IList<ProductFile> ProductFiles { get; set; }
        public decimal Weight { get; set; }
        public Supplier Supplier { get; set; }
        public string InternalIdent { get; set; }
        public bool IsNotOrderable { get; set; }
        public string DescriptionEnglish { get; set; }
        public string DescriptionFrench { get; set; }
        public string Brand { get; set; }
        public ProductCategory ProductCategoryEnglish { get; set; }
        public ProductCategory ProductCategoryFrench { get; set; }
        public string ComboboxDescriptionUpdate
        {
            get { return Ident + " " + NameFrench; }
        }
        public decimal PercentageSave
        {
            get
            {
                if (UnitPrice !=0)
                    return Math.Round(((UnitPrice - SalePrice) / UnitPrice) * 100, 0);
                else
                {
                    return 0;
                }
            }
        }
        public string PrincipalFileUrl
        {
            get
            {
                if (ProductFiles != null)
                {
                    foreach (ProductFile productFile in ProductFiles.Where(productFile => productFile.IsPrincipal))
                    {
                        return productFile.File != null
                                   ? "images/product/" + productFile.File.FileName
                                   : "images/product/NoImageForThisProduct.jpg";
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
                            return productFile.File != null
                                       ? productFile.File.FileName
                                       : "NoImageForThisProduct.jpg";
                        }
                    }
                }
                return "NoImageForThisProduct.jpg";
            }
        }
        public decimal SavePrice
        {
            get
            {
                return UnitPrice > SalePrice && SalePrice != 0
                           ? UnitPrice - SalePrice
                           : 0;
            }
        }
        public bool IsSlideShow { get; set; }
        public bool IsBackOrder { get; set; }
    }
}