using System;

namespace ATMTECH.Common.Utils
{
    public class Math
    {
        public static decimal RoundingMoney(decimal toRound)
        {
            return System.Math.Round(toRound, 2, MidpointRounding.ToEven);
        }
    }
}
