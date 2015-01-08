using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
            AjouterLignePublication("admin.boutiquecorpo.com", "admin.boutiquecorpo.com", @"C:\Publication\Administration");
            AjouterLignePublication("cima-directeur.boutiquecorpo.com", "cima-directeur.boutiquecorpo.com", @"C:\Publication\ShoppingCart-Pubjl");
            AjouterLignePublication("cima-director.boutiquecorpo.com", "cima-director.boutiquecorpo.com", @"C:\Publication\ShoppingCart-Pubjl");
            AjouterLignePublication("cima-employe.boutiquecorpo.com", "cima-employe.boutiquecorpo.com", @"C:\Publication\ShoppingCart-Pubjl");
            AjouterLignePublication("cima-employee.boutiquecorpo.com", "cima-employee.boutiquecorpo.com", @"C:\Publication\ShoppingCart-Pubjl");
            AjouterLignePublication("glv-an.boutiquecorpo.com", "glv-an.boutiquecorpo.com", @"C:\Publication\ShoppingCart-GLV");
            AjouterLignePublication("glv.boutiquecorpo.com", "glv.boutiquecorpo.com", @"C:\Publication\ShoppingCart-GLV");
            AjouterLignePublication("lauzon.boutiquecorpo.com", "lauzon.boutiquecorpo.com", @"C:\Publication\Lauzon");
            AjouterLignePublication("ursulines.boutiquecorpo.com", "ursulines.boutiquecorpo.com", @"C:\Publication\ShoppingCart-Pubjl");
        }

        private void AjouterLignePublication(string site, string repertoireFtp, string repertoireLocal)
        {
            ListViewItem lsvItem = new ListViewItem();
            lsvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lsvItem, site));
            lsvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lsvItem, repertoireFtp));
            lsvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lsvItem, repertoireLocal));
            lsvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lsvItem, ""));
            lsvFtp.Items.Add(lsvItem);
        }

        private void btnPublier_Click(object sender, EventArgs e)
        {
            ExecuterLaPublication();
        }


        private void ExecuterLaPublication()
        {
            Ftp ftpClient = new Ftp(@"ftp://" + txtFtpServeur.Text, txtFtpUtilisateur.Text, txtFtpMotPasse.Text);

            foreach (var lsvFtpItems in lsvFtp.Items)
            {
                ListViewItem lsviFtp = (ListViewItem)lsvFtpItems;
                if (lsviFtp.Checked)
                {
                    lsvResultat.Items.Clear();
                    int i = lsviFtp.SubItems.Count;

                    string repertoireLocal = lsviFtp.SubItems[3].Text;
                    string repertoireFtp = lsviFtp.SubItems[2].Text;

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
                        ListViewItem lsvItem = new ListViewItem();
                        lsvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lsvItem, enumerateFile));
                        lsvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lsvItem, repertoireFtpEnvoyer));
                        lsvItem.SubItems.Add(new ListViewItem.ListViewSubItem(lsvItem, "En attente"));
                        lsvResultat.Items.Add(lsvItem);
                    }

                    lsviFtp.SubItems[4].Text = "0 / " + lsvResultat.Items.Count.ToString() + "      (fichiers transférés)";

                    int nombreFichierTransfere = 0;
                    foreach (var item in lsvResultat.Items)
                    {
                        ListViewItem lsviResultat = (ListViewItem)item;
                        string repertoireFtpEnvoyer = lsviResultat.SubItems[2].Text;
                        string nomFichier = Path.GetFileName(lsviResultat.SubItems[1].Text);
                        string nomFichierAvecRepertoire = lsviResultat.SubItems[1].Text;


                        lsviResultat.SubItems[3].Text = EnvoyerFichierFtp(ftpClient, repertoireFtpEnvoyer, nomFichier, nomFichierAvecRepertoire);
                        nombreFichierTransfere += 1;
                        lsviFtp.SubItems[4].Text = nombreFichierTransfere.ToString() + " / " + lsvResultat.Items.Count.ToString() + "      (fichiers transférés)";
                        WinFormUtils.DoPaintEvents();
                    }

                    int compteErreur = lsvResultat.Items.Cast<ListViewItem>().Count(lsviResultat => lsviResultat.SubItems[3].Text != "Succès");
                    lsviFtp.SubItems[4].Text = (lsvResultat.Items.Count - compteErreur).ToString() + " / " + lsvResultat.Items.Count.ToString() + "      (fichiers transférés)";
                }
            }


        }

        private string EnvoyerFichierFtp(Ftp client, string repertoireFtp, string fichierFtp, string fichierLocal)
        {
            return client.Upload(repertoireFtp + "/" + fichierFtp, fichierLocal);
        }
    }
}
