using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATMTECH.Utils
{
    public static class Debug
    {
        public static void WriteDebug(string debugLine)
        {
            System.Diagnostics.Debug.WriteLine(debugLine);
        }
    }
}
