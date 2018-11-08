using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceProcess;
using System.Timers;
using ATMTECH.StockGame.DAO;
using ATMTECH.StockGame.Entites;
using ATMTECH.StockGame.Services;

namespace ATMTECH.StockGame.ServiceWindows
{
    public partial class ServiceStockGame : ServiceBase
    {
        Timer timer = new Timer();

        public ServiceStockGame()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Log("Démarrage du services");
            timer.Elapsed += OnElapsedTime;
            timer.Interval = 5000;
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            Log("Services arrêté");
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            Log("Vérification si il y a des ordres");
            try
            {
                IList<Titre> vendreTitreAvecOrdre = new TitreService().VendreTitreAvecOrdre();
                if (vendreTitreAvecOrdre.Count > 0)
                {
                    foreach (Titre titre in vendreTitreAvecOrdre)
                    {
                        Log("Titre vendu: " + titre.Code + " (" + titre.Utilisateur.Affichage + ")");
                    }
                }
                else
                {
                    Log("Aucune ordre");
                }

            }
            catch (Exception exception)
            {
                Log(exception.Message);
                throw;
            }
        }

        public void Log(string message)
        {
            message = DateTime.Now + " :: " + message;
            //new BaseDAO<LogOrdre>().Enregistrer(new LogOrdre { Log = DateTime.Now + " :: " + message });
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(message);
                }
            }
        }

    }
}
