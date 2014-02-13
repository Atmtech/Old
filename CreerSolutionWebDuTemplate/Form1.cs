using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CreerSolutionWebDuTemplate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreer_Click(object sender, EventArgs e)
        {
            CopierFichierTemplateVersTemp();
        }

        private void CopierFichierTemplateVersTemp()
        {
            if (Directory.Exists(@"C:\temp\CreerSolution"))
                Directory.Delete(@"C:\temp\CreerSolution", true);
            Directory.CreateDirectory(@"C:\temp\CreerSolution");

            DirectoryCopy(@"C:\Dev\Atmtech\ATMTECH.Template.WebSite", @"C:\temp\CreerSolution\ATMTECH." + txtProjet.Text + ".WebSite", true);
            DirectoryCopy(@"C:\Dev\Atmtech\ATMTECH.Template.DAO", @"C:\temp\CreerSolution\ATMTECH." + txtProjet.Text + ".DAO", true);
            DirectoryCopy(@"C:\Dev\Atmtech\ATMTECH.Template.Entities", @"C:\temp\CreerSolution\ATMTECH." + txtProjet.Text + ".Entities", true);
            DirectoryCopy(@"C:\Dev\Atmtech\ATMTECH.Template.Tests", @"C:\temp\CreerSolution\ATMTECH." + txtProjet.Text + ".Tests", true);
            DirectoryCopy(@"C:\Dev\Atmtech\ATMTECH.Template.Views", @"C:\temp\CreerSolution\ATMTECH." + txtProjet.Text + ".Views", true);
            DirectoryCopy(@"C:\Dev\Atmtech\ATMTECH.Template.Services", @"C:\temp\CreerSolution\ATMTECH." + txtProjet.Text + ".Services", true);

            List<string> listeFichierWebSite = GetFilesRecursive(@"C:\temp\CreerSolution\ATMTECH." + txtProjet.Text + ".WebSite");
            List<string> listeFichierDAO = GetFilesRecursive(@"C:\temp\CreerSolution\ATMTECH." + txtProjet.Text + ".DAO");
            List<string> listeFichierEntities = GetFilesRecursive(@"C:\temp\CreerSolution\ATMTECH." + txtProjet.Text + ".Entities");
            List<string> listeFichierTests = GetFilesRecursive(@"C:\temp\CreerSolution\ATMTECH." + txtProjet.Text + ".Tests");
            List<string> listeFichierViews = GetFilesRecursive(@"C:\temp\CreerSolution\ATMTECH." + txtProjet.Text + ".Views");
            List<string> listeFichierServices = GetFilesRecursive(@"C:\temp\CreerSolution\ATMTECH." + txtProjet.Text + ".Services");
            Formaterfichier(listeFichierWebSite);
            Formaterfichier(listeFichierDAO);
            Formaterfichier(listeFichierEntities);
            Formaterfichier(listeFichierTests);
            Formaterfichier(listeFichierViews);
            Formaterfichier(listeFichierServices);

            MessageBox.Show("Terminé");
        }

        private void Formaterfichier(List<string> listeFichier)
        {
            RemoveReadOnly(GetFilesRecursive(@"C:\temp\CreerSolution\ATMTECH." + txtProjet.Text + ".WebSite"));

            foreach (string fichier in listeFichier)
            {
                if (!fichier.Contains("Template.db3"))
                    ReplaceInFile(fichier, "Template", txtProjet.Text);
            }
            foreach (string fichier in listeFichier)
            {
                if (!fichier.Contains("Template.db3"))
                    RenameFile(fichier);
            }
        }


        private void RenameFile(string fichier)
        {
            if (fichier.IndexOf("Template") > 0)
            {
                File.Move(fichier, fichier.Replace("Template", txtProjet.Text));
            }
        }

        private void RemoveReadOnly(List<string> test)
        {
            foreach (string s in test)
            {
                File.SetAttributes(s, FileAttributes.Normal);
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

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

    }
}
