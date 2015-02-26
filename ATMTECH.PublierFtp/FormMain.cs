using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ATMTECH.PublierFtp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            AjouterLignePublication("WEB16.astralinternet.com", "admin.boutiquecorpo.com", "www", @"C:\Publication\Administration", "admin", "10crevette01");
            AjouterLignePublication("WEB16.astralinternet.com", "cima-directeur.boutiquecorpo.com", "www", @"C:\Publication\ShoppingCart-Pubjl", "cima-directeur", "10crevette01");
            AjouterLignePublication("WEB16.astralinternet.com", "cima-director.boutiquecorpo.com", "www", @"C:\Publication\ShoppingCart-Pubjl", "cima-director", "10crevette01");
            AjouterLignePublication("WEB16.astralinternet.com", "cima-employe.boutiquecorpo.com", "www", @"C:\Publication\ShoppingCart-Pubjl", "cima-employe", "10crevette01");
            AjouterLignePublication("WEB16.astralinternet.com", "cima-employee.boutiquecorpo.com", "www", @"C:\Publication\ShoppingCart-Pubjl", "cima-employee", "10crevette01");
            AjouterLignePublication("WEB16.astralinternet.com", "glv-an.boutiquecorpo.com", "www", @"C:\Publication\ShoppingCart-GLV", "glv", "10crevette01");
            AjouterLignePublication("WEB16.astralinternet.com", "glv.boutiquecorpo.com", "www", @"C:\Publication\ShoppingCart-GLV", "glv-an", "10crevette01");
            AjouterLignePublication("WEB16.astralinternet.com", "lauzon.boutiquecorpo.com", "www", @"C:\Publication\Lauzon", "lauzon", "10crevette01");
            AjouterLignePublication("WEB16.astralinternet.com", "ursulines.boutiquecorpo.com", "www", @"C:\Publication\ShoppingCart-Pubjl", "ursulines", "10crevette01");
            AjouterLignePublication("108.60.212.40", "commerce.boutiquecorpo.com", "commerce.boutiquecorpo.com", @"C:\Publication\Commerce", "Administrator", "Crevette01@");
            AjouterLignePublication("108.60.212.40", "admin.boutiquecorpo.com", "admin.boutiquecorpo.com", @"C:\Publication\Administration", "Administrator", "Crevette01@");
            AjouterLignePublication("108.60.212.40", "cima-directeur.boutiquecorpo.com", "cima-directeur.boutiquecorpo.com", @"C:\Publication\ShoppingCart-Pubjl", "Administrator", "Crevette01@");
            AjouterLignePublication("108.60.212.40", "cima-director.boutiquecorpo.com", "cima-director.boutiquecorpo.com", @"C:\Publication\ShoppingCart-Pubjl", "Administrator", "Crevette01@");
            AjouterLignePublication("108.60.212.40", "cima-employe.boutiquecorpo.com", "cima-employe.boutiquecorpo.com", @"C:\Publication\ShoppingCart-Pubjl", "Administrator", "Crevette01@");
            AjouterLignePublication("108.60.212.40", "cima-employee.boutiquecorpo.com", "cima-employee.boutiquecorpo.com", @"C:\Publication\ShoppingCart-Pubjl", "Administrator", "Crevette01@");
            AjouterLignePublication("108.60.212.40", "glv-an.boutiquecorpo.com", "glv-an.boutiquecorpo.com", @"C:\Publication\ShoppingCart-GLV", "Administrator", "Crevette01@");
            AjouterLignePublication("108.60.212.40", "glv.boutiquecorpo.com", "glv.boutiquecorpo.com", @"C:\Publication\ShoppingCart-GLV", "Administrator", "Crevette01@");
            AjouterLignePublication("108.60.212.40", "lauzon.boutiquecorpo.com", "lauzon.boutiquecorpo.com", @"C:\Publication\Lauzon", "Administrator", "Crevette01@");
            AjouterLignePublication("108.60.212.40", "ursulines.boutiquecorpo.com", "ursulines.boutiquecorpo.com", @"C:\Publication\ShoppingCart-Pubjl", "Administrator", "Crevette01@");
            AjouterLignePublication("108.60.212.40", "dev.boutiquecorpo.com", "dev.boutiquecorpo.com", @"C:\Publication\ShoppingCart-Pubjl", "Administrator", "Crevette01@");
            
        }

        private void AjouterLignePublication(string ip, string site, string repertoireFtp, string repertoireLocal, string utilisateur, string motDePasse)
        {
            ListViewItem lsvItem = new ListViewItem();
            lsvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lsvItem, ip));
            lsvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lsvItem, site));
            lsvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lsvItem, repertoireFtp));
            lsvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lsvItem, repertoireLocal));
            lsvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lsvItem, utilisateur));
            lsvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lsvItem, motDePasse));
            lsvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lsvItem, ""));
            lsvFtp.Items.Add(lsvItem);
        }

        private void btnPublier_Click(object sender, EventArgs e)
        {
            ExecuterLaPublication();
        }


        private void ExecuterLaPublication()
        {
         

            foreach (var lsvFtpItems in lsvFtp.Items)
            {
                ListViewItem lsviFtp = (ListViewItem)lsvFtpItems;
                
                if (lsviFtp.Checked)
                {
                    string ftp = lsviFtp.SubItems[1].Text;
                    string nomSite = lsviFtp.SubItems[2].Text;
                    string repertoireFtp = lsviFtp.SubItems[3].Text;
                    string repertoireLocal = lsviFtp.SubItems[4].Text;
                    string utilisateur = lsviFtp.SubItems[5].Text;
                    string motDePasse = lsviFtp.SubItems[6].Text;


                    Ftp ftpClient = new Ftp(@"ftp://" + ftp, utilisateur, motDePasse);

                    lsvResultat.Items.Clear();
                    int i = lsviFtp.SubItems.Count;



                    DirectoryInfo di = new DirectoryInfo(repertoireLocal);
                    FileInfo[] files = di.GetFiles("*.config")
                                         .Where(p => p.Extension == ".config").ToArray();
                    foreach (FileInfo file in files)
                        try
                        {
                            file.Attributes = FileAttributes.Normal;
                            File.Delete(file.FullName);
                        }
                        catch { }

                    foreach (string enumerateFile in Directory.EnumerateFiles(repertoireLocal, "*.*", SearchOption.AllDirectories))
                    {
                        string nomFichier = Path.GetFileName(enumerateFile);
                        string repertoireFtpEnvoyer = repertoireFtp + enumerateFile.Replace(repertoireLocal, "").Replace("\\", "/").Replace(nomFichier, "");
                        if (nomFichier == "web.config" || repertoireFtpEnvoyer.ToLower().IndexOf("/videos") != -1 ||
                            repertoireFtpEnvoyer.ToLower().IndexOf("/ckeditor") != -1) continue;

                        AjouterLigneResultat(lsvResultat, enumerateFile, repertoireFtpEnvoyer);
                        AjouterLigneResultat(lstResultatVisible, enumerateFile, repertoireFtpEnvoyer);
                    }

                    lsviFtp.SubItems[7].Text = "0 / " + lsvResultat.Items.Count.ToString() + "      (fichiers transférés)";

                    int nombreFichierTransfere = 0;
                    foreach (var item in lsvResultat.Items)
                    {
                        ListViewItem lsviResultat = (ListViewItem)item;
                        string repertoireFtpEnvoyer = lsviResultat.SubItems[2].Text;
                        string nomFichier = Path.GetFileName(lsviResultat.SubItems[1].Text);
                        string nomFichierAvecRepertoire = lsviResultat.SubItems[1].Text;

                        

                        lsviResultat.SubItems[3].Text = EnvoyerFichierFtp(ftpClient, repertoireFtpEnvoyer, nomFichier, nomFichierAvecRepertoire);
                        lstResultatVisible.Items[0].Remove();

                        nombreFichierTransfere += 1;
                        lsviFtp.SubItems[7].Text = nombreFichierTransfere.ToString() + " / " + lsvResultat.Items.Count.ToString() + "      (fichiers transférés)";
                        WinFormUtils.DoPaintEvents();
                    }

                    int compteErreur = lsvResultat.Items.Cast<ListViewItem>().Count(lsviResultat => lsviResultat.SubItems[3].Text != "Succès");
                    lsviFtp.SubItems[7].Text = (lsvResultat.Items.Count - compteErreur).ToString() + " / " + lsvResultat.Items.Count.ToString() + "      (fichiers transférés)";
                }
            }
        }

        private void AjouterLigneResultat(ListView listview, string fichier, string repertoireFtp)
        {
            ListViewItem lsvItem = new ListViewItem();
            lsvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lsvItem, fichier));
            lsvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lsvItem, repertoireFtp));
            lsvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lsvItem, "En attente"));
            listview.Items.Add(lsvItem);
        }


        private string EnvoyerFichierFtp(Ftp client, string repertoireFtp, string fichierFtp, string fichierLocal)
        {
            return client.Upload(repertoireFtp + "/" + fichierFtp, fichierLocal);
        }
    }
}
