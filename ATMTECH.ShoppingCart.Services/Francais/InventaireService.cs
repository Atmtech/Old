using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.ShoppingCart.Services.Francais
{
    public class InventaireService : BaseService, IInventaireService
    {
        public IDAOInventaire DAOInventaire { get; set; }

        public IList<Stock> ObtenirInventaire()
        {
            return DAOInventaire.GetAllActive();
        }
        public int ObtenirInventaireTechnosport(string idProduit, string grandeur, string couleur)
        {
            IList<XMLInventaire> listeXMLInventaires = new List<XMLInventaire>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("http://www.technosport.com/sites/en/WEnglish/Enterprise%20Portal/stock.aspx?ref=" + idProduit);
            if (xmlDoc.DocumentElement == null) return 0;
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/Models/Style");
            if (nodeList != null)
                foreach (XMLInventaire xmlInventaire in from XmlNode node in nodeList
                                                        select new XMLInventaire
                                                        {
                                                            Ident = node.SelectSingleNode("ItemName").InnerText,
                                                            Taille = node.SelectSingleNode("Size").InnerText,
                                                            Couleur = node.SelectSingleNode("Color").InnerText,
                                                            Nombre = node.SelectSingleNode("Stock").InnerText
                                                        })
                {
                    listeXMLInventaires.Add(xmlInventaire);
                }
            XMLInventaire xmlInventaireTrouve = listeXMLInventaires.FirstOrDefault(
                x => x.Couleur == couleur && x.Taille == grandeur && Convert.ToInt32(x.Nombre) > 0);
            return xmlInventaireTrouve != null ? Convert.ToInt32(xmlInventaireTrouve.Nombre) : 0;
        }
    }

    public class XMLInventaire
    {
        public string Ident { get; set; }
        public string Taille { get; set; }
        public string Couleur { get; set; }
        public string Nombre { get; set; }
    }
}

