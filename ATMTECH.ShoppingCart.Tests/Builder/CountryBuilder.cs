using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Tests.Builder
{
    public static class CountryBuilder
    {
        public static Country Create()
        {
            return new Country() { Id = 1 };
        }

        public static Country WithId(this Country country, int id)
        {
            country.Id = id;
            return country;
        }

        public static Country WithCode(this Country country, string code)
        {
            country.Code = code;
            return country;
        }
        public static Country WithDescription(this Country country, string description)
        {
            country.Description = description;
            return country;
        }
    }
}
