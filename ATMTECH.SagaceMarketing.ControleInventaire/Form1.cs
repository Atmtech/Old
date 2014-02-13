using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Services;
using ATMTECH.Services.Interface;
using Ionic.Zip;


namespace ATMTECH.SagaceMarketing.ControleInventaire
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void AjouterEvenement(string evenement)
        {
            lstEvenement.Items.Add(DateTime.Now.ToString() + " :: " + evenement);
            lstEvenement.SelectedIndex = lstEvenement.Items.Count - 1;
            lstEvenement.SelectedIndex = -1;
            Application.DoEvents();
        }
        public IBackupService BackupService { get; set; }
        private void btnEvaluer_Click(object sender, EventArgs e)
        {

            AjouterEvenement("Débuter traitement");

            BackupService backupService = new BackupService();
            DirectoryInfo di = new DirectoryInfo(txtRepertoire.Text);
            foreach (DirectoryInfo directoryInfo in di.GetDirectories())
            {



                AjouterEvenement("Traitement répertoire: " + directoryInfo.FullName);
                string sqliteDb = directoryInfo.FullName + "\\data.db";

                // Création de la base de donnée
                if (!File.Exists(sqliteDb))
                {

                    DatabaseSessionManager.ConnectionString = @"data source=" + sqliteDb;
                    string zipFile = directoryInfo.FullName + "\\backup.zip";
                    if (File.Exists(zipFile))
                    {
                        // Extraire tout les fichiers du zip
                        using (ZipFile zip = ZipFile.Read(zipFile))
                        {
                            foreach (ZipEntry test in zip)
                            {
                                test.Extract(directoryInfo.FullName, ExtractExistingFileAction.OverwriteSilently);
                            }
                            AjouterEvenement("Unzip: " + directoryInfo.FullName);
                        }

                        File.Delete(directoryInfo.FullName + "\\dtproperties.xml");
                        SQLiteConnection.CreateFile(sqliteDb);

                        DirectoryInfo di2 = new DirectoryInfo(directoryInfo.FullName);
                        FileInfo[] rgFiles = di2.GetFiles("*.xml");
                        foreach (FileInfo fi in rgFiles)
                        {
                            string file = fi.FullName;
                            AjouterEvenement("Traitement fichier xml: " + file);
                            backupService.RestoreXmlToSqliteDatabase(file, sqliteDb);
                        }


                        AjouterEvenement("Destruction des fichiers xml");
                        // Supprimer le garbage
                        foreach (FileInfo fileInfo in rgFiles)
                        {
                            File.Delete(fileInfo.FullName);
                        }

                        AjouterEvenement("Terminer répertoire: " + directoryInfo.FullName);
                    }
                }
            }

            // Faire l'évaluation des données si tout est valide
            // Créer la bd CheckInventaire
            // Prendre chaque table D'inventaire pour générer des tables dans une base Nommé ainsi Inventaire20100101 avec la date du répertoire avec inventaire <> 999999
            // Suite à ca on importe la derniere table de commande / ligne commande des répertoires pending et shipped
            // pour chaque transaction de commande on vérifie si la quantité au total de la journée a été déduite à l'inventaire comparativement à la journée d'avant.
            const string checkInventaire = @"C:\CheckInventaire.db";
            File.Delete(checkInventaire);
            SQLiteConnection.CreateFile(checkInventaire);
            backupService.CopyTableFromSqlite("INVENTAIRE", "INVENTAIRE1", @"C:\dev\Atmtech\ATMTECH.SagaceMarketing.ControleInventaire\RepertoireScan\2011-11-08 22_01\data.db", @"c:\CheckInventaire.db");

            //foreach (DirectoryInfo directoryInfo in di.GetDirectories())
            //{
            //    // ouvrir la bd et sortir la table Inventaire.
            //}


            AjouterEvenement("Terminer traitement");
        }


    }







}
