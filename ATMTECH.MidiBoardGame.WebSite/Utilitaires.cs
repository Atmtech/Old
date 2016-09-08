using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATMTECH.MidiBoardGame.WebSite
{
    public static class Utilitaires
    {
        public static DateTime Aujourdhui()
        {
            return Convert.ToDateTime(DateTime.Now.ToShortDateString());
        }
    }
}