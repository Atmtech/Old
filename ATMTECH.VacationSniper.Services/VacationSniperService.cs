using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using ATMTECH.VacationSniper.DAO;
using ATMTECH.VacationSniper.Entites;

namespace ATMTECH.VacationSniper.Services
{
    public class VacationSniperService
    {
        public IList<ForfaitVacance> ObtenirForfaitVacance()
        {
            return new BaseDAO().ObtenirForfaitVacance();
        }
        public void Snipe()
        {
            IList<ForfaitVacance> obtenirForfaitVacance = new VacationSniperService().ObtenirForfaitVacance();
            foreach (ForfaitVacance forfaitVacance in obtenirForfaitVacance)
            {
                Console.WriteLine("Obtenir le prix de: {0}", forfaitVacance.Nom);
                string url = forfaitVacance.Url.Replace("&amp;", "&");
                try
                {

                    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                    myRequest.Timeout = 10000;
                    myRequest.Method = "GET";
                    WebResponse myResponse = myRequest.GetResponse();
                    StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.Default);
                    string result = sr.ReadToEnd();

                    string prix = result.Substring(result.IndexOf(forfaitVacance.LignePourParse, StringComparison.Ordinal) + forfaitVacance.LignePourParse.Length, forfaitVacance.NombreCaractereLecture);
                    Regex digitsOnly = new Regex(@"[^\d]");
                    prix = digitsOnly.Replace(prix, "");
                    if (Regex.IsMatch(prix, @"^\d+$"))
                    {
                        new BaseDAO().EnregistrerSnipe(new ForfaitVacanceSnipe
                        {
                            Nom = forfaitVacance.Nom,
                            Date = DateTime.Now.ToString(),
                            Prix = prix,
                            Url = url
                        });
                    }
                    else
                    {
                        if (result.IndexOf("Aucune chambre n") >= 0)
                        {
                            EnregistrerSnipeAucuneChambreDisponible(forfaitVacance, url);
                        }
                        else
                        {
                            EnregistrerSnipeErreur(forfaitVacance, url);
                        }

                    }
                }
                catch (Exception)
                {
                    EnregistrerSnipeErreur(forfaitVacance, url);
                }
            }


        }
        public void ConstruireHtml(string version)
        {
            string html = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Template.html");
            html = html.Replace("{version}", version);
            string ligneForfait = string.Empty;
            foreach (ForfaitVacanceSnipe forfaitVacanceSnipe in new BaseDAO().ObtenirSnipe().OrderBy(x => x.Nom).ThenBy(x => x.Date))
            {
                ligneForfait += string.Format("[ '{0}','{1}','{2}','{3}'],{4}", forfaitVacanceSnipe.Nom, forfaitVacanceSnipe.Prix, forfaitVacanceSnipe.Date, forfaitVacanceSnipe.Url, Environment.NewLine);
            }
            html = html.Replace("{donnees}", ligneForfait);

            IList<ForfaitVacanceSnipe> listeForfaitVacanceSnipes = new BaseDAO().ObtenirSnipe().Where(x => x.Prix != "Non disponible").ToList();

            string scriptGraphique = string.Empty;
            foreach (ForfaitVacance forfaitVacance in new BaseDAO().ObtenirForfaitVacance())
            {
                List<string> list = listeForfaitVacanceSnipes.Where(x => x.Nom == forfaitVacance.Nom).Select(x => x.Prix).Distinct().ToList();

                string nomCanvas = forfaitVacance.Nom.Replace(" ", "");
                scriptGraphique += forfaitVacance.Nom;
                scriptGraphique += "   <canvas id='" + nomCanvas + "' width='1000' height='300'></canvas>" + Environment.NewLine;
                scriptGraphique += "    <script src='https://cdnjs.cloudflare.com/ajax/libs/Chart.js/1.0.2/Chart.min.js'></script>" + Environment.NewLine;
                scriptGraphique += "<script>" + Environment.NewLine;
                scriptGraphique += "    var ctx = document.getElementById('" + nomCanvas + "').getContext('2d');" + Environment.NewLine;
                scriptGraphique += "    var data = {" + Environment.NewLine;
                scriptGraphique += "labels: [";
                int i = 0;
                foreach (string test in list)
                {
                    i += 1;
                    scriptGraphique += "'" + i.ToString() + "',";
                }
                scriptGraphique += "]," + Environment.NewLine;
                //   scriptGraphique += "        labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'test',]," + Environment.NewLine;
                scriptGraphique += "        datasets: [" + Environment.NewLine;
                scriptGraphique += "            {" + Environment.NewLine;
                scriptGraphique += "                label: 'My Second dataset'," + Environment.NewLine;
                scriptGraphique += "                fillColor: 'rgba(151,187,205,0.5)'," + Environment.NewLine;
                scriptGraphique += "                strokeColor: 'rgba(151,187,205,0.8)'," + Environment.NewLine;
                scriptGraphique += "                highlightFill: 'rgba(151,187,205,0.75)'," + Environment.NewLine;
                scriptGraphique += "                highlightStroke: 'rgba(151,187,205,1)'," + Environment.NewLine;
                scriptGraphique += "data: [";
                foreach (string test in list)
                {
                    scriptGraphique += test + ",";
                }
                scriptGraphique += "]," + Environment.NewLine;

                // scriptGraphique += "                data: [28.12, 48.21, 40.1, 19, 86, 27, 90, 911]" + Environment.NewLine;
                scriptGraphique += "            }" + Environment.NewLine;
                scriptGraphique += "        ]" + Environment.NewLine;
                scriptGraphique += "    };" + Environment.NewLine;
                scriptGraphique += "    var MyNewChart = new Chart(ctx).Bar(data);" + Environment.NewLine;
                scriptGraphique += "</script>";

            }




            html = html.Replace("{graphique}", scriptGraphique);


            string fichier = AppDomain.CurrentDomain.BaseDirectory + "Snipe.html";
            if (File.Exists(fichier)) File.Delete(fichier);
            File.WriteAllText(fichier, html);
        }



        private void EnregistrerSnipeErreur(ForfaitVacance forfaitVacance, string url)
        {
            new BaseDAO().EnregistrerSnipe(new ForfaitVacanceSnipe
            {
                Nom = forfaitVacance.Nom,
                Date = DateTime.Now.ToString(),
                Prix = "Erreur url ou autre",
                Url = url
            });

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Erreur url ou autre {0}", forfaitVacance.Nom);
            Console.BackgroundColor = ConsoleColor.White;

        }

        private void EnregistrerSnipeAucuneChambreDisponible(ForfaitVacance forfaitVacance, string url)
        {
            new BaseDAO().EnregistrerSnipe(new ForfaitVacanceSnipe
            {
                Nom = forfaitVacance.Nom,
                Date = DateTime.Now.ToString(),
                Prix = "Aucune chambre disponible pour la date",
                Url = url
            });

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Aucune chambre disponible pour la date {0}", forfaitVacance.Nom);
            Console.BackgroundColor = ConsoleColor.White;

        }



    }
}
