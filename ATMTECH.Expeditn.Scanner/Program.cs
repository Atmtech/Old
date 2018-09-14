using System;
using System.Threading;
using System.Windows.Forms;

namespace ATMTECH.Expeditn.Scanner
{
    static class Program
    {
        private static Mutex mutex = null;

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
       

        static void Main()
        {

            const string appName = "Scanner";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                //app is already running! Exiting the application  
                return;
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormScanner());
        }
    }
}
