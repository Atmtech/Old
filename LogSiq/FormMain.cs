using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMTECH.DAO;
using ATMTECH.DAO.SessionManager;

namespace LogSiq
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }



        private void btnLoad_Click(object sender, EventArgs e)
        {
            DatabaseSessionManager.ConnectionString = @"data source=C:\dev\Atmtech\LogSiq\LogFile.db3";

            string[] filePaths = Directory.GetFiles(txtRepertoire.Text, "*.*");

            string total = filePaths.Count().ToString();

            int j = 0;
            foreach (string filePath in filePaths)
            {
                j++;
                lblResultat.Text = j + " de " + total;
                Application.DoEvents();
                StreamReader reader = new StreamReader(filePath, System.Text.Encoding.Default);
                string line = string.Empty;
                string writeToDatabase = string.Empty;
                int i = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    writeToDatabase += line;
                    if (string.IsNullOrEmpty(line.Trim()))
                    {
                        i++;
                        if (i == 2)
                        {
                            string time = writeToDatabase.Substring(0, 12);
                            string description = writeToDatabase.Substring(13, writeToDatabase.Length - 13).Replace("\n", "");

                            string type = string.Empty;
                            if (description.IndexOf("SIQ.PESA.Commun.Exceptions.ExceptionService") > 0)
                            {
                                type = "ExceptionService";
                            }
                            else
                            {
                                if (description.IndexOf("SIQ.PESA.Commun.Exceptions.ExceptionTechnique") > 0)
                                {
                                     type = "ExceptionTechnique";
                                }
                            }

                            Log log = new Log() { Description = description, Heure = time, Type=type };
                            BaseDao<Log, int> dao = new BaseDao<Log, int>();
                            dao.Save(log);

                            writeToDatabase = "";
                        }
                    }
                    else
                    {
                        i = 0;
                    }
                }
                reader.Close();
            }
            MessageBox.Show("Terminé");
        }
    }
}
