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
                        EnregistrerSnipeNonDisponible(forfaitVacance, url);
                    }
                }
                catch (Exception)
                {
                    EnregistrerSnipeNonDisponible(forfaitVacance, url);
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

            string moinscher = string.Empty;

            foreach (
                ForfaitVacanceSnipe forfaitVacanceSnipe in
                    new BaseDAO().ObtenirSnipe().Where(x => x.Prix != "Non disponible"))
            {
            }

            // foreach (ForfaitVacanceSnipe forfaitVacanceSnipe in new BaseDAO().ObtenirSnipe())
            //{

            //}

            ForfaitVacanceSnipe forfaitVacanceSnipe1 =
                new BaseDAO().ObtenirSnipe().OrderBy(x => x.Nom).ThenBy(x => x.Date).First();

            moinscher += string.Format("[ '{0}','{1}','{2}','{3}'],{4}", forfaitVacanceSnipe1.Nom, forfaitVacanceSnipe1.Prix, forfaitVacanceSnipe1.Date, forfaitVacanceSnipe1.Url, Environment.NewLine);



            html = html.Replace("{moinscher}", moinscher);


            string fichier = AppDomain.CurrentDomain.BaseDirectory + "Snipe.html";
            if (File.Exists(fichier)) File.Delete(fichier);
            File.WriteAllText(fichier, html);
        }



        private void EnregistrerSnipeNonDisponible(ForfaitVacance forfaitVacance, string url)
        {
            new BaseDAO().EnregistrerSnipe(new ForfaitVacanceSnipe
            {
                Nom = forfaitVacance.Nom,
                Date = DateTime.Now.ToString(),
                Prix = "Non disponible",
                Url = url
            });

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Non disponible {0}", forfaitVacance.Nom);
            Console.BackgroundColor = ConsoleColor.White;

        }


    }
}
