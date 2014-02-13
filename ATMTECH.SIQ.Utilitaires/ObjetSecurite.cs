using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace ATMTECH.SIQ.Utilitaires
{
    public class ObjetSecurite
    {
        private readonly string _repertoire;
        public ObjetSecurite(string repertoire)
        {
            _repertoire = repertoire;
        }

        private IList<string> _listeFichier = new List<string>();

        public IList<string> ListeFichier
        {
            get
            {
                if (_listeFichier.Count == 0)
                {
                    _listeFichier = GetFilesRecursive(_repertoire);
                    _listeFichier = _listeFichier.Where(s => s.IndexOf(".dll") == -1).ToList();
                    _listeFichier = _listeFichier.Where(s => s.IndexOf(".pdb") == -1).ToList();
                    _listeFichier = _listeFichier.Where(s => s.IndexOf(".master.cs") == -1).ToList();
                    _listeFichier = _listeFichier.Where(s => s.IndexOf("SIQ.PESA.Controles") == -1).ToList();
                    _listeFichier = _listeFichier.Where(s => s.IndexOf("SIQ.PESA.Commun") == -1).ToList();
                    _listeFichier = _listeFichier.Where(s => s.IndexOf("SIQ.PESA.Persistence") == -1).ToList();
                    _listeFichier = _listeFichier.Where(s => s.IndexOf("SIQ.PESA.Entite") == -1).ToList();
                    _listeFichier = _listeFichier.Where(s => s.IndexOf("TRAITEMENT") == -1).ToList();
                    _listeFichier = _listeFichier.Where(s => s.IndexOf(".designer.cs") == -1).ToList();
                    _listeFichier = _listeFichier.Where(s => s.IndexOf(".Tests") == -1).ToList();
                    _listeFichier = _listeFichier.Where(s => s.IndexOf(".Test") == -1).ToList();
                    _listeFichier = _listeFichier.Where(s => s.IndexOf(".DAO") == -1).ToList();
                    _listeFichier = _listeFichier.Where(s => s.IndexOf("ModuleInitializer.cs") == -1).ToList();
                    _listeFichier = _listeFichier.Where(s => s.IndexOf("MenuSiteMapProvider.cs") == -1).ToList();
                }
                return _listeFichier;
            }
        }

        private static List<string> GetFilesRecursive(string repertoire)
        {
            List<string> result = new List<string>();
            Stack<string> stack = new Stack<string>();
            stack.Push(repertoire);
            while (stack.Count > 0)
            {
                string dir = stack.Pop();
                try
                {
                    result.AddRange(Directory.GetFiles(dir, "*.*").Where(s => s.EndsWith(".cs") || s.EndsWith(".aspx")));
                    foreach (string dn in Directory.GetDirectories(dir))
                    {
                        stack.Push(dn);
                    }
                }
                catch
                {
                }
            }
            return result;
        }

        public IList<ContexteSecurite> TrouverListeIdObjetSecurite()
        {
            IList<ContexteSecurite> retour = new List<ContexteSecurite>();

            // Filtrer la liste de fichier pour n'Mavoir que celle du website
            IList<string> liste = ListeFichier.Where(s => s.IndexOf("WebSites") != -1).ToList();
            foreach (string fichier in liste)
            {
                ContexteSecurite contexte = TrouverContexteSecurite("IdObjetSecurite", fichier);

                if (contexte != null)
                {
                    retour.Add(contexte);
                }
            }

            return retour;
        }


        private ContexteSecurite TrouverContexteSecuriteDansModule(string chaine, string fichier)
        {

            string fName = fichier;
            StreamReader testTxt = new StreamReader(fName);
            string allRead = testTxt.ReadToEnd();
            testTxt.Close();
            string regMatch = chaine;
            Match test = Regex.Match(allRead, regMatch);
            if (test.Index > 0)
            {
                string temp = allRead.Substring(test.Index, allRead.Length - test.Index - 1);
                temp = temp.Substring(chaine.Length + 2, temp.Length - chaine.Length - 2);
                temp = temp.Substring(0, temp.IndexOf(";"));
                temp = temp.Substring(temp.IndexOf('"') + 1, temp.Length - temp.IndexOf('"') - 2);
                return new ContexteSecurite() { Contexte = temp };
            }
            return null;

        }

        private ContexteSecurite TrouverContexteSecurite(string chaine, string fichier)
        {
            string fName = fichier;
            StreamReader testTxt = new StreamReader(fName);
            string allRead = testTxt.ReadToEnd();
            testTxt.Close();
            string regMatch = chaine;

            Match test = Regex.Match(allRead, regMatch);
            if (test.Index > 0)
            {
                string temp = allRead.Substring(test.Index, allRead.Length - test.Index - 1);

                ContexteSecurite contexteSecurite = new ContexteSecurite();
                contexteSecurite.Page = fichier;


                if (fichier.IndexOf(@"WebSites\PESA") > 0)
                {
                    string temp2 = fichier.Substring(fichier.IndexOf(@"WebSites\PESA") + 14, fichier.Length - fichier.IndexOf(@"WebSites\PESA") - 14);
                    if (temp2.IndexOf(@"\") == -1)
                    {
                        contexteSecurite.Projet = "Plateforme";
                    }
                    else
                    {
                        contexteSecurite.Projet = temp2.Substring(0, temp2.IndexOf(@"\"));
                    }

                }

                if ((fichier.IndexOf(".aspx.cs") > 0 || fichier.IndexOf(".ascx.cs") > 0))
                {
                    temp = temp.Substring(chaine.Length + 2, temp.IndexOf(";")).Trim();
                    temp = temp.Substring(0, temp.IndexOf(";"));

                    if (contexteSecurite.Projet != "Plateforme")
                    {
                        IList<string> listeFichier = ListeFichier.Where(s => s.IndexOf("Page") != -1 || s.IndexOf("Onglets") != -1).ToList();
                        //listeFichier = listeFichier.Where(s => s.IndexOf("Modules") != -1).ToList();

                        IList<string> listeFichierTemp1 = listeFichier.Where(s => s.IndexOf(contexteSecurite.Projet + ".") != -1).ToList();
                        IList<string> listeFichierTemp2 = listeFichier.Where(s => s.IndexOf("SIQ.PESA." + contexteSecurite.Projet) != -1).ToList();
                        listeFichier = listeFichierTemp1.Count != 0 ? listeFichierTemp1 : listeFichierTemp2;

                        foreach (string fichier2 in listeFichier)
                        {
                            ContexteSecurite contexte = TrouverContexteSecuriteDansModule(temp.Substring(temp.IndexOf(".") + 1, temp.Length - temp.IndexOf(".") - 1), fichier2);
                            if (contexte != null)
                            {
                                temp = contexte.Contexte;
                                break;
                            }
                        }
                    }
                    else
                    {
                        IList<string> listeFichier = ListeFichier.Where(s => s.IndexOf("Page") != -1 || s.IndexOf("Onglets") != -1).ToList();
                        listeFichier = ListeFichier.Where(s => s.IndexOf("WebSites") == -1).ToList();
                        foreach (string fichier2 in listeFichier)
                        {
                            ContexteSecurite contexte = TrouverContexteSecuriteDansModule(temp.Substring(temp.IndexOf(".") + 1, temp.Length - temp.IndexOf(".") - 1), fichier2);
                            if (contexte != null)
                            {
                                temp = contexte.Contexte;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    temp = temp.Substring(chaine.Length + 2, temp.Length - chaine.Length - 2);
                    temp = temp.Substring(0, temp.IndexOf('"'));
                }

                contexteSecurite.Contexte = temp.Trim();



                return contexteSecurite;
            }

            else return null;
        }

        public IList<ContexteSecurite> TrouverContexteInexistantDansFichierContexte(IList<ContexteSecurite> listeContexte, string fichierContexte)
        {
            IList<ContexteSecurite> listeMessage = new List<ContexteSecurite>();
            string fName = fichierContexte;
            StreamReader testTxt = new StreamReader(fName);
            string allRead = testTxt.ReadToEnd();
            testTxt.Close();

            foreach (ContexteSecurite contexte in listeContexte)
            {
                if (!Regex.IsMatch(allRead.ToLower(), "<id>" + contexte.Contexte.ToLower() + "</id>"))
                {
                    listeMessage.Add(contexte);
                }
            }
            return listeMessage;
        }

        public void Enregistrer(ContexteFichier contexteFichier, string fichierContexte)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fichierContexte);

            XmlNodeList contextes = doc.SelectNodes("//Contexte");

            bool estMaj = false;
            foreach (XmlNode contexte in contextes)
            {
                if (contexte.ChildNodes[0].LastChild.Value == contexteFichier.Contexte)
                {
                    // update 
                    estMaj = true;

                    foreach (XmlNode child in contexte.ChildNodes)
                    {
                        if (child.Name == "Description")
                        {
                            child.InnerText = contexteFichier.Description;
                        }

                        if (child.Name == "EstAccessibleEnLectureParTous")
                        {
                            child.InnerText = contexteFichier.EstAccessibleEnLectureParTous.ToString();
                        }

                        if (child.Name == "EstAccessibleEnModificationParTous")
                        {
                            child.InnerText = contexteFichier.EstAccessibleEnModificationParTous.ToString();
                        }
                    }
                }
            }

            if (estMaj == false)
            {
                //insert

                XmlNode sa = doc.SelectSingleNode("Sa");
                XmlNode contexte = doc.CreateNode(XmlNodeType.Element, "Contexte", null);
                XmlNode id = doc.CreateNode(XmlNodeType.Element, "Id", null);
                id.InnerText = contexteFichier.Contexte;
                XmlNode description = doc.CreateNode(XmlNodeType.Element, "Description", null);
                description.InnerText = contexteFichier.Description;
                XmlNode lecture = doc.CreateNode(XmlNodeType.Element, "EstAccessibleEnLectureParTous", null);
                lecture.InnerText = contexteFichier.EstAccessibleEnLectureParTous.ToString();
                XmlNode ecriture = doc.CreateNode(XmlNodeType.Element, "EstAccessibleEnModificationParTous", null);
                ecriture.InnerText = contexteFichier.EstAccessibleEnModificationParTous.ToString();
                contexte.AppendChild(id);
                contexte.AppendChild(description);
                contexte.AppendChild(lecture);
                contexte.AppendChild(ecriture);
                sa.AppendChild(contexte);
            }

            doc.Save(fichierContexte);
        }

        public ContexteFichier ObtenirContexteFichier(string contexteRecherche, string fichierContexte)
        {
            ContexteFichier contexteFichier = new ContexteFichier();

            XmlDocument doc = new XmlDocument();
            doc.Load(fichierContexte);
            XmlNodeList contextes = doc.SelectNodes("//Contexte");
            foreach (XmlNode contexte in contextes)
            {

                if (contexte.ChildNodes[0].LastChild.Value == contexteRecherche)
                {
                    for (int i = 0; i < contexte.ChildNodes.Count; i++)
                    {
                        if (contexte.ChildNodes[i].Name == "Id")
                        {
                            contexteFichier.Contexte = contexte.ChildNodes[i].LastChild.Value;
                        }
                        if (contexte.ChildNodes[i].Name == "Description")
                        {
                            contexteFichier.Description = contexte.ChildNodes[i].LastChild.Value;
                        }
                        if (contexte.ChildNodes[i].Name == "EstAccessibleEnLectureParTous")
                        {
                            contexteFichier.EstAccessibleEnLectureParTous = Convert.ToInt32(contexte.ChildNodes[i].LastChild.Value);
                        }
                        if (contexte.ChildNodes[i].Name == "EstAccessibleEnModificationParTous")
                        {
                            contexteFichier.EstAccessibleEnModificationParTous = Convert.ToInt32(contexte.ChildNodes[i].LastChild.Value);
                        }
                    }


                    break;
                }

            }
            XmlNodeList assignations = doc.SelectNodes("//Assignations");
            foreach (XmlNode assignation in assignations)
            {
                if (assignation.ParentNode.ChildNodes[0].InnerText == contexteFichier.Contexte)
                {

                }
            }


            return contexteFichier;
        }

        public IList<ContexteFichier> ConstruireTreeview(IList<ContexteSecurite> listeContexte, string fichierContexte)
        {
            IList<ContexteFichier> contexteFichiers = new List<ContexteFichier>();

            XmlDocument doc = new XmlDocument();
            doc.Load(fichierContexte);
            XmlNodeList contextes = doc.SelectNodes("//Contexte");
            foreach (XmlNode contexte in contextes)
            {
                ContexteFichier contexteFichier = new ContexteFichier();
                for (int i = 0; i < contexte.ChildNodes.Count; i++)
                {
                    if (contexte.ChildNodes[i].Name == "Id")
                    {
                        contexteFichier.Contexte = contexte.ChildNodes[i].LastChild.Value;

                        // Trouver dans la liste le bon projet
                        IList<ContexteSecurite> t = listeContexte.Where(s => s.Contexte == contexteFichier.Contexte).ToList();
                        if (t.Count > 0)
                        {
                            contexteFichier.Projet = t[0].Projet;
                        }

                    }
                    if (contexte.ChildNodes[i].Name == "Description")
                    {
                        contexteFichier.Description = contexte.ChildNodes[i].LastChild.Value;
                    }
                    if (contexte.ChildNodes[i].Name == "EstAccessibleEnLectureParTous")
                    {
                        contexteFichier.EstAccessibleEnLectureParTous = Convert.ToInt32(contexte.ChildNodes[i].LastChild.Value);
                    }
                    if (contexte.ChildNodes[i].Name == "EstAccessibleEnModificationParTous")
                    {
                        contexteFichier.EstAccessibleEnModificationParTous = Convert.ToInt32(contexte.ChildNodes[i].LastChild.Value);
                    }
                }

                contexteFichiers.Add(contexteFichier);
            }

            return contexteFichiers.OrderBy(s => s.Projet).ToList();
        }
    }

    public class Assignation
    {
        public string Role { get; set; }
        public string Ua { get; set; }
    }
    public class ContexteFichier
    {
        public string Contexte { get; set; }
        public string Description { get; set; }
        public int EstAccessibleEnLectureParTous { get; set; }
        public int EstAccessibleEnModificationParTous { get; set; }
        public string Projet { get; set; }
        public IList<Assignation> Assignations { get; set; }
    }

    public class ContexteSecurite
    {
        public string Contexte { get; set; }
        public string Page { get; set; }
        public string Projet { get; set; }
    }
}
