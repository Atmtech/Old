using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ATMTECH.RemplacerSIQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static List<string> GetFilesRecursive(string b)
        {
            // 1.
            // Store results in the file results list.
            List<string> result = new List<string>();

            // 2.
            // Store a stack of our directories.
            Stack<string> stack = new Stack<string>();

            // 3.
            // Add initial directory.
            stack.Push(b);

            // 4.
            // Continue while there are directories to process
            while (stack.Count > 0)
            {
                // A.
                // Get top directory
                string dir = stack.Pop();

                try
                {
                    // B
                    // Add all files at this directory to the result List.
                    result.AddRange(Directory.GetFiles(dir, "*.*"));

                    // C
                    // Add all directories at this directory.
                    foreach (string dn in Directory.GetDirectories(dir))
                    {
                        stack.Push(dn);
                    }
                }
                catch
                {
                    // D
                    // Could not open the directory
                }
            }
            return result;
        }
        public static void EffacerFichierRepertoire(string repertoireSource)
        {
            if (!Directory.Exists(repertoireSource))
                return;

            DirectoryInfo dir = new DirectoryInfo(repertoireSource);
            FileInfo[] files = dir.GetFiles();
            //progressBarMigration.Maximum = files.Count();
            foreach (FileInfo fi in files)
            {
                //AvancerStatutProgression("Supprimer fichier (" + fi.FullName + ")");
                try
                {
                    fi.Delete();
                }
                catch (Exception)
                {


                }

            }

            DirectoryInfo[] directoryInfos = dir.GetDirectories();
            // progressBarMigration.Maximum = directoryInfos.Count();
            foreach (DirectoryInfo di in directoryInfos)
            {
                //AvancerStatutProgression("Supprimer répertoire (" + di.FullName + ")");
                EffacerFichierRepertoire(di.FullName);
                try
                {
                    di.Delete();
                }
                catch (Exception)
                {


                }

            }
        }
        public static void ReplaceInFile(string filePath, string searchText, string replaceText)
        {
            if (filePath.IndexOf("suo") == -1 && filePath.IndexOf("vspscc") == -1 && filePath.IndexOf(".dll") == -1 &&
                filePath.IndexOf(".ReSharper") == -1 && filePath.IndexOf(".gpState") == -1 && filePath.IndexOf(".sln") == -1 &&
                filePath.IndexOf(".targets") == -1 && filePath.IndexOf(".jpg") == -1 && filePath.IndexOf(".png") == -1 && filePath.IndexOf(".gif") == -1)
            {
                StreamReader reader = new StreamReader(filePath);
                string content = reader.ReadToEnd();
                reader.Close();

                content = Regex.Replace(content, searchText, replaceText);

                StreamWriter writer = new StreamWriter(filePath);
                writer.Write(content);
                writer.Close();
            }
        }

        private IList<Dictionnaire> Dictionnaire()
        {
            IList<Dictionnaire> dictionnaire = new List<Dictionnaire>();
            dictionnaire.Add(new Dictionnaire("SIQ.PESA", "ATMTECH"));
            dictionnaire.Add(new Dictionnaire("siq", "ATMTECH"));
            dictionnaire.Add(new Dictionnaire("Siq", "ATMTECH"));
            dictionnaire.Add(new Dictionnaire("using Page = Microsoft.Practices.CompositeWeb.Web.UI.Page;", ""));
            dictionnaire.Add(new Dictionnaire("using ATMTECH.Commun.Constantes;", ""));
            dictionnaire.Add(new Dictionnaire("] = SiteMap.CurrentNode;", "] = 0;"));
            dictionnaire.Add(new Dictionnaire("<Import Project=\"..\\..\\..\\ATMTECH.targets\" />", ""));
            dictionnaire.Add(new Dictionnaire("using Microsoft.Practices.CompositeWeb;", ""));
            dictionnaire.Add(new Dictionnaire("Microsoft.Practices.CompositeWeb.Web.UI.", ""));
            dictionnaire.Add(new Dictionnaire("ATMTECH.Controles", "ATMTECH.Web.Controls"));
            dictionnaire.Add(new Dictionnaire("Commun.Monnaie", "Common"));
            dictionnaire.Add(new Dictionnaire("ExceptionTechnique", "BaseException"));
            dictionnaire.Add(new Dictionnaire("using ATMTECH.Commun.Exceptions;", "using ATMTECH.Exception;"));
            dictionnaire.Add(new Dictionnaire("ATMTECH.Entite;", "ATMTECH.Entities;"));
            dictionnaire.Add(new Dictionnaire("IEnum", "BaseEnumeration"));
            dictionnaire.Add(new Dictionnaire("BaseEnumerationerable", "IEnumerable"));
            dictionnaire.Add(new Dictionnaire("using ATMTECH.Commun.Utils;", "using ATMTECH.Common.Utilities;"));

            
            //dictionnaire.Add(new Dictionnaire("<Compile Include=\"Affichage\\BarreOutil.cs\">", ""));
            //dictionnaire.Add(new Dictionnaire("<Compile Include=\"Affichage\\ImageHttpHandler.cs\" />", ""));
            //dictionnaire.Add(new Dictionnaire("<Compile Include=\"Edition\\BoutonApprouverWorkflow.cs\" />", ""));
            //dictionnaire.Add(new Dictionnaire("<Compile Include=\"Edition\\BoutonRejeterWorkflow.cs\" />", ""));
            //dictionnaire.Add(new Dictionnaire("<Compile Include=\"Edition\\BoutonAnnulerWorkflow.cs\" />", ""));
            //dictionnaire.Add(new Dictionnaire("<Compile Include=\"Edition\\EventArgsAnnulerWorkflow.cs\" />", ""));
            //dictionnaire.Add(new Dictionnaire("<Compile Include=\"Edition\\FileHttpHandler.cs\" />", ""));
            //dictionnaire.Add(new Dictionnaire("<Compile Include=\"Edition\\FileUploadAvance.cs\" />", ""));
            //dictionnaire.Add(new Dictionnaire("<Compile Include=\"Edition\\TextBoxEditorAvance.cs\" />", ""));
            //dictionnaire.Add(new Dictionnaire("<Compile Include=\"Rapport\\BaseRapportPresenter.cs\" />", ""));
            //dictionnaire.Add(new Dictionnaire("<Compile Include=\"Rapport\\RapportHttpHandler.cs\" />", ""));
            //dictionnaire.Add(new Dictionnaire("<Compile Include=\"Rapport\\RapportView.cs\" />", ""));
            //dictionnaire.Add(new Dictionnaire("<Compile Include=\"Interfaces\\IDetailUserControlWorkflow.cs\" />", ""));
            //dictionnaire.Add(new Dictionnaire("<Compile Include=\"Interfaces\\IRapportView.cs\" />", ""));
            return dictionnaire;
        }
        private void ScanFichierPourChangerTerme(string fichier)
        {
            foreach (Dictionnaire dictionnaire in Dictionnaire())
            {
                ReplaceInFile(fichier, dictionnaire.AncienTerme, dictionnaire.NouveauTerme);
            }
        }
        private void RenameFile(string fichier)
        {
            if (fichier.IndexOf("siq") > 0)
            {
                File.Move(fichier, fichier.Replace("siq", "Atmtech"));
            }
            if (fichier.IndexOf("Siq") > 0)
            {
                File.Move(fichier, fichier.Replace("Siq", "Atmtech"));
            }

            if (fichier.IndexOf("SIQ.PESA") > 0)
            {
                try
                {
                    File.Move(fichier, fichier.Replace("SIQ.PESA.Controles", "ATMTECH.Web.Controls"));
                }
                catch (Exception)
                {
                }

            }


        }
        private void RemoveReadOnly(List<string> test)
        {
            foreach (string s in test)
            {
                File.SetAttributes(s, FileAttributes.Normal);
            }
        }
        private void EffacerFichier(List<string> test)
        {
            foreach (string s in test)
            {
                if (s.IndexOf("EventArgsAnnulerWorkflow.cs") > 0)
                {
                    File.Delete(s);
                }

                if (s.IndexOf("IViewBase.cs") > 0)
                {
                    File.Delete(s);
                }

                if (s.IndexOf("FileHttpHandler.cs") > 0)
                {
                    File.Delete(s);
                }
                if (s.IndexOf("ImageHttpHandler.cs") > 0)
                {
                    File.Delete(s);
                }
                if (s.IndexOf("FileUploadAvance.cs") > 0)
                {
                    File.Delete(s);
                }
                if (s.IndexOf("FileUploadAvance.js") > 0)
                {
                    File.Delete(s);
                }

                if (s.IndexOf("BoutonRejeterWorkflow.cs") > 0)
                {
                    File.Delete(s);
                }
                if (s.IndexOf("BarreOutil.cs") > 0)
                {
                    File.Delete(s);
                }
                if (s.IndexOf("IDetailUserControlWorkflow.cs") > 0)
                {
                    File.Delete(s);
                }
                if (s.IndexOf("BoutonAnnulerWorkflow.cs") > 0)
                {
                    File.Delete(s);
                }
                if (s.IndexOf("BoutonApprouverWorkflow.cs") > 0)
                {
                    File.Delete(s);
                }
                if (s.IndexOf("BaseRapportPresenter.cs") > 0)
                {
                    File.Delete(s);
                }
                if (s.IndexOf("RapportHttpHandler.cs") > 0)
                {
                    File.Delete(s);
                }
                if (s.IndexOf("RapportView.cs") > 0)
                {
                    File.Delete(s);
                }
                if (s.IndexOf("TextBoxEditorAvance.cs") > 0)
                {
                    File.Delete(s);
                }
                if (s.IndexOf("TextBoxEditorAvance.js") > 0)
                {
                    File.Delete(s);
                }

                if (s.IndexOf("ConfigurationBuilder.cs") > 0)
                {
                    File.Delete(s);
                }
                if (s.IndexOf("GestionnaireSessionHttpModule.cs") > 0)
                {
                    File.Delete(s);
                }
                if (s.IndexOf("StaticGestionnaireSession.cs") > 0)
                {
                    File.Delete(s);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            //Détruire Build
            EffacerFichierRepertoire(textBox1.Text + "\\Build\\Debug");
            EffacerFichierRepertoire(textBox1.Text + @"\ATMTECH.Test.Website\obj");

            if (!Directory.Exists(textBox1.Text + "\\SIQ.PESA.Controles"))
            {
                MessageBox.Show("Le repertoire SIQ.PESA.Controles n'existe pas");
            }
            else
            {
                Directory.Move(textBox1.Text + "\\SIQ.PESA.Controles", textBox1.Text + "\\ATMTECH.Web.Controls");
            }

            List<string> test = GetFilesRecursive(textBox1.Text);

            label1.Text = "Item: 0 de " + test.Count.ToString();

            // Effacer le readonly
            RemoveReadOnly(GetFilesRecursive(textBox1.Text));

            // Effacer les fichiers pas rapport
            EffacerFichier(GetFilesRecursive(textBox1.Text));

            int i = 0;
            foreach (string item in test)
            {
                //scanForSIq(item);

                RenameFile(item);
                i++;


                label1.Text = "Item: " + i.ToString() + " de " + test.Count.ToString();
                Application.DoEvents();

            }

            List<string> test2 = GetFilesRecursive(textBox1.Text);
            label1.Text = "Item: 0 de " + test2.Count.ToString();

            int i2 = 0;
            foreach (string item in test2)
            {
                ScanFichierPourChangerTerme(item);

                i2++;


                label1.Text = "Item: " + i2.ToString() + " de " + test2.Count.ToString();
                Application.DoEvents();

            }

            label1.Text = "Terminé";

        }

    }

    public class Dictionnaire
    {
        public Dictionnaire(string ancienTerme, string nouveauTerme)
        {
            AncienTerme = ancienTerme;
            NouveauTerme = nouveauTerme;
        }
        public string AncienTerme { get; set; }
        public string NouveauTerme { get; set; }
    }

}
