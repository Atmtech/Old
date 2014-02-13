using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Tests.Builder
{
    public static class CityBuilder
    {
        public static City Create()
        {
            return new City() { Id = 1 };
        }

        public static City WithId(this City city, int id)
        {
            city.Id = id;
            return city;
        }

        public static City WithCode(this City city, string code)
        {
            city.Code = code;
            return city;
        }
        public static City WithDescription(this City city, string description)
        {
            city.Description = description;
            return city;
        }
    }
}
