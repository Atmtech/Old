using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ATMTECH.SIQ.Utilitaires;

namespace ATMTECH.SIQ.TrouverIdObjetSecurite
{
    public partial class FormTrouverObjetSecurite : Form
    {
        public FormTrouverObjetSecurite()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RemplirListeContexteDuCode();
            tabControl1.Visible = true;
        }


        private string CreerLigneFichierContexte(string contexteManquant)
        {
            string temp = string.Empty;
            temp += "<Contexte>" + Environment.NewLine;
            temp += string.Format("  <Id>{0}</Id>", contexteManquant) + Environment.NewLine;
            temp += string.Format("  <Description>{0}</Description>", contexteManquant) + Environment.NewLine;
            temp += "  <EstAccessibleEnLectureParTous>1</EstAccessibleEnLectureParTous>" + Environment.NewLine;
            temp += "  <EstAccessibleEnModificationParTous>0</EstAccessibleEnModificationParTous>" + Environment.NewLine;
            temp += "</Contexte>" + Environment.NewLine;
            return temp;
        }

        private void RemplirListeContexteDuCode()
        {
            ObjetSecurite objetSecurite = new ObjetSecurite(txtRepertoire.Text);
            lstContexteApplication.Items.Clear();
            IList<ContexteSecurite> listeContexte = objetSecurite.TrouverListeIdObjetSecurite();
            foreach (ContexteSecurite contexteSecurite in listeContexte)
            {
                ListViewItem l = new ListViewItem();
                l.Text = contexteSecurite.Contexte;
                l.SubItems.Add(contexteSecurite.Page);
                l.SubItems.Add(contexteSecurite.Projet);
                lstContexteApplication.Items.Add(l);
            }

            lblTotalApplication.Text = "Total application: " + lstContexteApplication.Items.Count.ToString();

            lstMessage.Items.Clear();
            IList<ContexteSecurite> listeContexteErreur = objetSecurite.TrouverContexteInexistantDansFichierContexte(listeContexte,
                                                                       txtRepertoire.Text + @"Contextes.xml");

            foreach (ContexteSecurite erreur in listeContexteErreur)
            {
                ListViewItem l = new ListViewItem();
                l.Text = erreur.Contexte;
                l.SubItems.Add(erreur.Page);
                l.SubItems.Add(erreur.Projet);
                lstMessage.Items.Add(l);



                txtContexteInvalide.Text += CreerLigneFichierContexte(erreur.Contexte);
            }
            lblTotalIncoherence.Text = "Total d'incohérence: " + lstMessage.Items.Count.ToString();

            treeView1.Nodes.Clear();

            TreeNode nodeSa = new TreeNode() { Text = "S@" };
            nodeSa.Expand();
            IList<ContexteFichier> listeContexteFichier = objetSecurite.ConstruireTreeview(listeContexte, txtRepertoire.Text + @"Contextes.xml");
            string temp = string.Empty;
            TreeNode treeGroup = null;

            int i = 0;
            foreach (ContexteFichier contexteFichier in listeContexteFichier)
            {

                if (temp != contexteFichier.Projet)
                {
                    if (!String.IsNullOrEmpty(temp))
                        nodeSa.Nodes.Add(treeGroup);
                    temp = contexteFichier.Projet;
                    treeGroup = new TreeNode() { Text = temp };
                }

                TreeNode treeContexte = new TreeNode() { Text = contexteFichier.Contexte };
                i += 1;
                treeGroup.Nodes.Add(treeContexte);
            }

            nodeSa.Nodes.Add(treeGroup);

            treeView1.Nodes.Add(nodeSa);


            lblTotalFichier.Text = "Total dans le fichier: " + listeContexteFichier.Count.ToString();
            lblTotalDansTreeview.Text = "Total dans l'arbre: " + i;
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            ObjetSecurite objetSecurite = new ObjetSecurite(txtRepertoire.Text);
            ContexteFichier contexte = objetSecurite.ObtenirContexteFichier(treeView1.SelectedNode.Text, txtRepertoire.Text + @"Contextes.xml");
            txtId.Text = contexte.Contexte;
            txtDescription.Text = contexte.Description;
            txtAccessibleEcriture.Text = contexte.EstAccessibleEnModificationParTous.ToString();
            txtAccessibleLecture.Text = contexte.EstAccessibleEnLectureParTous.ToString();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            ObjetSecurite objetSecurite = new ObjetSecurite(txtRepertoire.Text);
            ContexteFichier contexteFichier = new ContexteFichier()
                                                  {
                                                      Contexte = txtId.Text,
                                                      Description = txtDescription.Text,
                                                      EstAccessibleEnLectureParTous = Convert.ToInt32(txtAccessibleLecture.Text),
                                                      EstAccessibleEnModificationParTous = Convert.ToInt32(txtAccessibleEcriture.Text)
                                                  };
            objetSecurite.Enregistrer(contexteFichier, txtRepertoire.Text + @"Contextes.xml");

            MessageBox.Show("Enregistrement effectué avec succès");
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            txtAccessibleEcriture.Text = "";
            txtAccessibleLecture.Text = "";
            txtDescription.Text = "";
            txtId.Text = "";
            txtRepertoire.Text = "";
        }

        private void lblTotalApplication_Click(object sender, EventArgs e)
        {

        }

    }
}
