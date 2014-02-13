using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Ionic.Zip;

namespace SendToFtp
{
    public partial class FormMain : Form
    {
        private String[] _files;
        public String[] AllFiles
        {
            get
            {
                return ReturnAllFile(txtDirectory.Text, "*.*");
            }
            set { _files = value; }

        }

        private String[] _trxFiles;
        public String[] TrxFiles
        {
            get
            {
                return ReturnAllFile(txtDirectory.Text, "*.trx");
            }
            set { _trxFiles = value; }

        }

        private String[] _pdbFiles;
        public String[] PdbFiles
        {
            get
            {
                return ReturnAllFile(txtDirectory.Text, "*.pdb");
            }
            set { _pdbFiles = value; }

        }

        private String[] _xmlFiles;
        public String[] XmlFiles
        {
            get
            {
                return ReturnAllFile(txtDirectory.Text, "*.xml");
            }
            set { _xmlFiles = value; }

        }

        private String[] _dllFiles;
        public String[] DllFiles
        {
            get
            {
                return ReturnAllFile(txtDirectory.Text, "*.dll");
            }
            set { _dllFiles = value; }

        }

        private String[] _binFiles;
        public String[] BinFiles
        {
            get
            {
                return ReturnAllFile(txtDirectory.Text, "*.bin");
            }
            set { _binFiles = value; }

        }

        public FormMain()
        {
            InitializeComponent();
        }

        private String[] ReturnAllFile(string directory, string extension)
        {
            return Directory.GetFiles(directory, extension, SearchOption.AllDirectories);
        }


        private String[] GetAllDirectory(string directory)
        {
            return Directory.GetDirectories(directory,"obj",SearchOption.AllDirectories);
        }
        private int _totalFile = 0;
        private void btnSendToFtp_Click(object sender, EventArgs e)
        {
            lblResult.Text = "Delete directory";
            Application.DoEvents();
            String[] repertoire = GetAllDirectory(txtDirectory.Text);
            foreach (string rep  in repertoire)
            {
                if (rep.EndsWith("obj"))
                {
                    Directory.Delete(rep,true);
                }
            }
            
            lblResult.Text = "Delete dll";
            Application.DoEvents();
            foreach (string file in DllFiles)
            {
                if (file.ToLower().IndexOf("library") == -1)
                {
                    if (file.ToLower().IndexOf("sendtoftp") == -1)
                    {
                        File.Delete(file);
                    }

                }
            }

            lblResult.Text = "Delete pdb";
            Application.DoEvents();
            foreach (string file in PdbFiles)
            {

                File.Delete(file);
            }

            lblResult.Text = "Delete trx";
            Application.DoEvents();
            foreach (string file in TrxFiles)
            {

                File.Delete(file);
            }

            lblResult.Text = "Delete xml";
            Application.DoEvents();
            foreach (string file in XmlFiles)
            {

                File.Delete(file);
            }

            lblResult.Text = "Delete bin";
            Application.DoEvents();
            foreach (string file in BinFiles)
            {

                File.Delete(file);
            }

            foreach (string file in AllFiles)
            {
                _totalFile++;
            }
            
            string zipFile = "Atmtech" + DateTime.Now.Year.ToString() + string.Format("{0:d2}", DateTime.Now.Month) + string.Format("{0:d2}", DateTime.Now.Day) +  ".zip";
            if (File.Exists(txtDirectory.Text + "\\" + zipFile))
            {
                File.Delete(txtDirectory.Text + "\\" + zipFile);
            }

            // creer le fichier Zip
            using (ZipFile zip = new ZipFile())
            {
                lblResult.Text = "Add to zip";
                Application.DoEvents();
                zip.AddDirectory(txtDirectory.Text);
                lblResult.Text = "Save to zip";
                Application.DoEvents();
                zip.Save("C:\\Dev\\" + zipFile);
            }

            lblResult.Text = "Finished to " + "C:\\Dev\\" + zipFile;

        }
    }
}
