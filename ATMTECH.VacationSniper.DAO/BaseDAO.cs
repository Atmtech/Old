using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using ATMTECH.VacationSniper.Entites;

namespace ATMTECH.VacationSniper.DAO
{
    public class BaseDAO
    {
        public XmlNodeList ObtenirDonneesXml(string fichier)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + @"data\" + fichier);
            if (xmlDoc.DocumentElement == null) return null;
            return xmlDoc.DocumentElement.SelectNodes("/Root/Item");
        }
        public IList<ForfaitVacance> ObtenirForfaitVacance()
        {
            XmlNodeList donnees = ObtenirDonneesXml("ForfaitVacance.Xml");
            IList<ForfaitVacance> forfaitVacances = new List<ForfaitVacance>();
            if (donnees == null) return forfaitVacances;
            foreach (ForfaitVacance serveur in from XmlNode node in donnees
                                               select new ForfaitVacance
                                        {
                                            Nom = node.SelectSingleNode("Nom").InnerText,
                                            Url = node.SelectSingleNode("Url").InnerText,
                                            LignePourParse = node.SelectSingleNode("LignePourParse").InnerText,
                                            NombreCaractereLecture = Convert.ToInt32(node.SelectSingleNode("NombreCaractereLecture").InnerText),
                                        })
            {
                forfaitVacances.Add(serveur);
            }
            return forfaitVacances;
        }

        public IList<ForfaitVacanceSnipe> ObtenirSnipe()
        {
            XmlNodeList donnees = ObtenirDonneesXml("ForfaitVacanceSnipe.xml");
            IList<ForfaitVacanceSnipe> forfaitVacances = new List<ForfaitVacanceSnipe>();
            if (donnees == null) return forfaitVacances;
            foreach (ForfaitVacanceSnipe serveur in from XmlNode node in donnees
                                                    select new ForfaitVacanceSnipe
                                               {
                                                   Nom = node.SelectSingleNode("Nom").InnerText,
                                                   Url = node.SelectSingleNode("Url").InnerText,
                                                   Prix = node.SelectSingleNode("Prix").InnerText,
                                                   Date = node.SelectSingleNode("Date").InnerText,
                                               })
            {
                forfaitVacances.Add(serveur);
            }
            return forfaitVacances;
        }


        public void EnregistrerSnipe(ForfaitVacanceSnipe forfaitVacanceSnipe)
        {
            string fichier = AppDomain.CurrentDomain.BaseDirectory + @"data\ForfaitVacanceSnipe.xml";
            if (string.IsNullOrEmpty(fichier))
            {
                string repertoire = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string repertoireLog = string.Format(@"{0}\Data\", repertoire);
                if (!Directory.Exists(repertoireLog)) Directory.CreateDirectory(repertoireLog);
            }

            try
            {
                InitialiserFichierXml(fichier);
                XmlDocument xmlDoc = ObtenirXmlDoc(fichier);
                XmlElement sousRacine = ObtenirSousRacine(xmlDoc);
                EcrireNode(xmlDoc, sousRacine, forfaitVacanceSnipe.Nom, "Nom");
                EcrireNode(xmlDoc, sousRacine, DateTime.Now.ToString(), "Date");
                EcrireNode(xmlDoc, sousRacine, forfaitVacanceSnipe.Prix, "Prix");
                EcrireNode(xmlDoc, sousRacine, forfaitVacanceSnipe.Url, "Url");
                xmlDoc.Save(fichier);
            }
            catch (Exception)
            {
                // ignored
            }


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


        public void InitialiserFichierXml(string fichier)
        {
            if (!File.Exists(fichier))
            {
                XmlTextWriter textWritter = new XmlTextWriter(fichier, null);
                textWritter.WriteStartDocument();
                textWritter.WriteStartElement("Root");
                textWritter.WriteEndElement();
                textWritter.Close();
            }
        }

        static void EcrireNode(XmlDocument xmlDoc, XmlElement sousRacine, string valeur, string nomElement)
        {
            XmlElement appendedElementUsername = xmlDoc.CreateElement(nomElement);
            XmlText node = xmlDoc.CreateTextNode(valeur);
            appendedElementUsername.AppendChild(node);
            sousRacine.AppendChild(appendedElementUsername);
            if (xmlDoc.DocumentElement != null) xmlDoc.DocumentElement.AppendChild(sousRacine);
        }


    }
}
