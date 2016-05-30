using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ATMTECH.TransfertVideo
{
    public class DAO
    {
        public XmlNodeList ObtenirDonneesXml(string fichier)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + @"\data\" + fichier);
            if (xmlDoc.DocumentElement == null) return null;
            return xmlDoc.DocumentElement.SelectNodes("/Root/Item");
        }

        public XmlDocument ObtenirXmlDoc(string fichier)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fichier);
            return xmlDoc;
        }
        public XmlElement ObtenirSousRacine(XmlDocument xmlDocument)
        {
            return xmlDocument.CreateElement("Item");
        }
        public void EcrireNode(XmlDocument xmlDoc, XmlElement sousRacine, string valeur, string nomElement)
        {
            XmlElement appendedElementUsername = xmlDoc.CreateElement(nomElement);
            XmlText node = xmlDoc.CreateTextNode(valeur);
            appendedElementUsername.AppendChild(node);
            sousRacine.AppendChild(appendedElementUsername);
            if (xmlDoc.DocumentElement != null) xmlDoc.DocumentElement.AppendChild(sousRacine);
        }

        public void EffacerNode(XmlDocument xmlDoc, string fichier, string guid)
        {

            // XmlNode project = xmlDoc.SelectSingleNode("//Item[@Guid='" + guid + "']");

            XmlNodeList nodeList = xmlDoc.GetElementsByTagName("Item");
            foreach (XmlNode node in nodeList)
            {
                if (node.OuterXml.IndexOf(guid, StringComparison.Ordinal) >= 0)
                {
                    xmlDoc.RemoveChild(node);
                    
                }
            }

            xmlDoc.Save(fichier);
        }


        public void EcrireFilm(Film film, string fichier)
        {
            try
            {
                XmlDocument xmlDoc = ObtenirXmlDoc(fichier);
                XmlElement sousRacine = ObtenirSousRacine(xmlDoc);

                EffacerNode(xmlDoc, fichier, film.Guid);

                EcrireNode(xmlDoc, sousRacine, film.Guid, "Guid");
                EcrireNode(xmlDoc, sousRacine, film.Etudiant1, "Etudiant1");
                EcrireNode(xmlDoc, sousRacine, film.Etudiant2, "Etudiant2");
                EcrireNode(xmlDoc, sousRacine, film.Etudiant3, "Etudiant3");
                EcrireNode(xmlDoc, sousRacine, film.Etudiant4, "Etudiant4");
                EcrireNode(xmlDoc, sousRacine, film.Etudiant5, "Etudiant5");
                EcrireNode(xmlDoc, sousRacine, film.Fichier, "Fichier");
                EcrireNode(xmlDoc, sousRacine, film.Groupe, "Groupe");
                xmlDoc.Save(fichier);
            }
            catch (Exception)
            {
                // ignored
            }
        }


        public IList<Film> ObtenirListeFilm()
        {
            XmlNodeList donnees = ObtenirDonneesXml("Film.Xml");
            IList<Film> serveurs = new List<Film>();
            if (donnees == null) return serveurs;
            foreach (Film serveur in from XmlNode node in donnees
                                     select new Film
                                                         {
                                                             Guid = node.SelectSingleNode("Guid").InnerText,
                                                             Groupe = node.SelectSingleNode("Groupe").InnerText,
                                                             Fichier = node.SelectSingleNode("Fichier").InnerText,
                                                             Etudiant1 = node.SelectSingleNode("Etudiant1").InnerText,
                                                             Etudiant2 = node.SelectSingleNode("Etudiant2").InnerText,
                                                             Etudiant3 = node.SelectSingleNode("Etudiant3").InnerText,
                                                             Etudiant4 = node.SelectSingleNode("Etudiant4").InnerText,
                                                             Etudiant5 = node.SelectSingleNode("Etudiant5").InnerText,
                                                         })
            {
                serveurs.Add(serveur);
            }
            return serveurs;
        }

    }
}