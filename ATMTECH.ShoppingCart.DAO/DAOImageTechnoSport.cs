using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using ATMTECH.DAO;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOImageTechnoSport : BaseDao<ImageTechnoSport, int>, IDAOImageTechnoSport
    {
        public IDAOProduit DAOProduit { get; set; }
        public IList<ImageTechnoSport> ObtenirImageTechnoSport(string ident)
        {
            Product product = DAOProduit.ObtenirProduitParIdentification(ident);

            string siteTechnoSport = "https://www.technosport.com";
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(string.Format("{1}/sites/FR/WEnglish/Enterprise%20Portal/itemView.aspx?WCMP=tsc1&Item={0}#", ident, siteTechnoSport));
            myRequest.Timeout = 10000;
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), Encoding.Default);
            string result = sr.ReadToEnd();
            IList<ImageTechnoSport> imageTechnoSports = new List<ImageTechnoSport>();
            if (result.IndexOf("ItemDesc_AvailColors", StringComparison.Ordinal) > 0)
            {
                string s = result.Substring(result.IndexOf("ItemDesc_AvailColors", StringComparison.Ordinal),
                    result.IndexOf("<!-- AddThis Button BEGIN -->", StringComparison.Ordinal) - result.IndexOf("ItemDesc_AvailColors", StringComparison.Ordinal));
                s = s.Replace("ItemDesc_AvailColors\" style=\"margin: 12px 12px 12px 12px\">\r\n\t\t\t\t\t\t\t\t<a href='#' style='padding:2px;'>", "");
                string[] separators1 = { "<a href='#' style='padding:2px;'>" };

                string[] listeImage = s.Split(separators1, StringSplitOptions.RemoveEmptyEntries);

                foreach (string image in listeImage)
                {
                    string imageGarment = image.Substring(image.IndexOf("/_images/garments"), image.IndexOf("','ctl00") - image.IndexOf("/_images/garments"));
                    string imageCouleur = image.Substring(image.IndexOf("/_images/colours"), image.IndexOf("' Style='border-color:#b7b7b7") - image.IndexOf("/_images/colours"));
                    string nomCouleurFr = image.Substring(image.IndexOf("title='"), image.IndexOf("' /></a>") - image.IndexOf("title='")).Replace("title='", "").Replace("'", "").Replace("Ã©","é");
                    string nomCouleurEn = image.Substring(image.IndexOf("title='"), image.IndexOf("' /></a>") - image.IndexOf("title='")).Replace("title='", "").Replace("'", "").Replace("Ã©", "é");
                    imageTechnoSports.Add(new ImageTechnoSport { Product = product, Image = siteTechnoSport + imageGarment, ImageCouleur = siteTechnoSport + imageCouleur, NomCouleurFr = nomCouleurFr, NomCouleurEn = nomCouleurEn });
                }

             
            }
            return imageTechnoSports;
        }
    }
}
