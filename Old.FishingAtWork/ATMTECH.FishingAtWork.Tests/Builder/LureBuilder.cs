using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Tests.Builder
{
    public static class LureBuilder
    {
        public static Lure Create()
        {
            return new Lure();
        }
        public static Lure WithName(this Lure lure, string name)
        {
            lure.Name = name;
            return lure;
        }
        public static Lure WithId(this Lure lure, int id)
        {
            lure.Id = id;
            return lure;
        }
        public static Lure WithPrice(this Lure lure, double price)
        {
            lure.Price = price;
            return lure;
        }


        public static Lure CreateValid()
        {
            return new Lure().WithName("Rapala").WithPrice(10.25);
        }
    }
}
