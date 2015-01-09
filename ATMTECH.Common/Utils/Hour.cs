using System;
using System.Collections.Generic;

namespace ATMTECH.Common.Utils
{
    public static class Hour
    {
        public static IList<string> GetHourList()
        {

            //var hours = new List<DateTime>();
            IList<string> hours = new List<string>();

            DateTime startFloor = Convert.ToDateTime("2000-01-01");
            DateTime endFloor = Convert.ToDateTime("2000-01-02");

            for (double dblDate = startFloor.ToOADate();
                 dblDate <= endFloor.ToOADate();
                 dblDate += (1.0 / 24.0))
            {
                hours.Add(DateTime.FromOADate(dblDate).ToShortTimeString());
            }
            hours.Remove("00:00");
            return hours;
        }
    }
}
