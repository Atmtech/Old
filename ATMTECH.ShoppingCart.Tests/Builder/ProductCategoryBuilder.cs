using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Tests.Builder
{
    public static class ProductCategoryBuilder
    {
        public static ProductCategory Create()
        {
            return new ProductCategory() { Id = 1 };
        }

        public static ProductCategory WithCode(this ProductCategory productCategory, string code)
        {
            productCategory.Code = code;
            return productCategory;
        }
        public static ProductCategory WithDescription(this ProductCategory productCategory, string description)
        {
            productCategory.Description = description;
            return productCategory;
        }
        public static ProductCategory WithLanguage(this ProductCategory productCategory, string language)
        {
            productCategory.Language = language;
            return productCategory;
        }
        public static ProductCategory WithId(this ProductCategory productCategory, int id)
        {
            productCategory.Id = id;
            return productCategory;
        }
        public static ProductCategory WithEnterprise(this ProductCategory productCategory, Enterprise enterprise)
        {
            productCategory.Enterprise = enterprise;
            return productCategory;
        }

    }
}
