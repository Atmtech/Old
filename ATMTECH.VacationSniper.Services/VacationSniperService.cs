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
                Console.WriteLine("Test: {0}", forfaitVacance.Nom);
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
                        new BaseDAO().EnregistrerSnipe(new ForfaitVacanceSnipe
                        {
                            Nom = forfaitVacance.Nom,
                            Date = DateTime.Now.ToString(),
                            Prix = "Non disponible",
                            Url = url
                        });
                    }
                }
                catch (Exception)
                {
                    new BaseDAO().EnregistrerSnipe(new ForfaitVacanceSnipe
                    {
                        Nom = forfaitVacance.Nom,
                        Date = DateTime.Now.ToString(),
                        Prix = "Non disponible",
                        Url = url
                    });
                }
            }

          
        }

        

        public void ConstruireHtml(string version)
        {
          


            string html = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Template.html");
            html = html.Replace("{version}", version);

            string ligneForfait = "<table class='tableau'>" +
                        "<tr class='enteteTableau'>" +
                        "<td class='celluleEnteteTableau'>Destination</td> " +
                        "<td class='celluleEnteteTableau'>Prix ($)</td> " +
                        "<td class='celluleEnteteTableau'>Date saisie</td> " +
                        "<td class='celluleEnteteTableau'>Site web</td>" +
                        "</tr>";

            foreach (ForfaitVacanceSnipe forfaitVacanceSnipe in new BaseDAO().ObtenirSnipe().OrderBy(x=>x.Nom).ThenBy(x=>x.Date))
            {
                ligneForfait += "<tr>";
                ligneForfait += string.Format("<td class='celluleTableau'>{0}</td>", forfaitVacanceSnipe.Nom);
                ligneForfait += string.Format("<td class='celluleTableau'>{0}</td>", forfaitVacanceSnipe.Prix);
                ligneForfait += string.Format("<td class='celluleTableau'>{0}</td>", forfaitVacanceSnipe.Date);
                ligneForfait += string.Format("<td class='celluleTableau'><a href='{0}'>Voir</a></td>", forfaitVacanceSnipe.Url);
                ligneForfait += "</tr>";
            }

            ligneForfait += "</table>";
            html = html.Replace("{forfait}", ligneForfait);

            string fichier = AppDomain.CurrentDomain.BaseDirectory + "Snipe.html";
            if (File.Exists(fichier)) File.Delete(fichier);
            File.WriteAllText(fichier, html);
        }
    }
}
