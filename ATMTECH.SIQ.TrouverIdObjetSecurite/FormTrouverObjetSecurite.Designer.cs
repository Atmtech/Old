namespace ATMTECH.SIQ.TrouverIdObjetSecurite
{
    partial class FormTrouverObjetSecurite
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblTotalApplication = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstContexteApplication = new System.Windows.Forms.ListView();
            this.Contexte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Page = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Projet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblTotalIncoherence = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstMessage = new System.Windows.Forms.ListView();
            this.ContexteValidation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PageValidation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProjetValidation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblTotalFichier = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAccessibleEcriture = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAccessibleLecture = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRepertoire = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtContexteInvalide = new System.Windows.Forms.TextBox();
            this.lblTotalDansTreeview = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(13, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1199, 615);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblTotalApplication);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lstContexteApplication);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1191, 589);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Liste des contextes de PESA";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblTotalApplication
            // 
            this.lblTotalApplication.AutoSize = true;
            this.lblTotalApplication.Location = new System.Drawing.Point(300, 19);
            this.lblTotalApplication.Name = "lblTotalApplication";
            this.lblTotalApplication.Size = new System.Drawing.Size(0, 13);
            this.lblTotalApplication.TabIndex = 9;
            this.lblTotalApplication.Click += new System.EventHandler(this.lblTotalApplication_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Voici la liste des contextes présents dans le code de PESA";
            // 
            // lstContexteApplication
            // 
            this.lstContexteApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstContexteApplication.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Contexte,
            this.Page,
            this.Projet});
            this.lstContexteApplication.GridLines = true;
            this.lstContexteApplication.Location = new System.Drawing.Point(9, 35);
            this.lstContexteApplication.Name = "lstContexteApplication";
            this.lstContexteApplication.Size = new System.Drawing.Size(1176, 549);
            this.lstContexteApplication.TabIndex = 7;
            this.lstContexteApplication.UseCompatibleStateImageBehavior = false;
            this.lstContexteApplication.View = System.Windows.Forms.View.Details;
            // 
            // Contexte
            // 
            this.Contexte.Text = "Contexte";
            this.Contexte.Width = 340;
            // 
            // Page
            // 
            this.Page.DisplayIndex = 2;
            this.Page.Text = "Page";
            this.Page.Width = 700;
            // 
            // Projet
            // 
            this.Projet.DisplayIndex = 1;
            this.Projet.Text = "Projet";
            this.Projet.Width = 100;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtContexteInvalide);
            this.tabPage2.Controls.Add(this.lblTotalIncoherence);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.lstMessage);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1191, 589);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Validation avec le fichier de contexte";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblTotalIncoherence
            // 
            this.lblTotalIncoherence.AutoSize = true;
            this.lblTotalIncoherence.Location = new System.Drawing.Point(288, 16);
            this.lblTotalIncoherence.Name = "lblTotalIncoherence";
            this.lblTotalIncoherence.Size = new System.Drawing.Size(41, 13);
            this.lblTotalIncoherence.TabIndex = 10;
            this.lblTotalIncoherence.Text = "label10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Liste des contextes inexistant dans le fichier de contexte";
            // 
            // lstMessage
            // 
            this.lstMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ContexteValidation,
            this.PageValidation,
            this.ProjetValidation});
            this.lstMessage.GridLines = true;
            this.lstMessage.Location = new System.Drawing.Point(9, 35);
            this.lstMessage.Name = "lstMessage";
            this.lstMessage.Size = new System.Drawing.Size(1176, 456);
            this.lstMessage.TabIndex = 8;
            this.lstMessage.UseCompatibleStateImageBehavior = false;
            this.lstMessage.View = System.Windows.Forms.View.Details;
            // 
            // ContexteValidation
            // 
            this.ContexteValidation.Text = "Contexte";
            this.ContexteValidation.Width = 340;
            // 
            // PageValidation
            // 
            this.PageValidation.DisplayIndex = 2;
            this.PageValidation.Text = "Page";
            this.PageValidation.Width = 700;
            // 
            // ProjetValidation
            // 
            this.ProjetValidation.DisplayIndex = 1;
            this.ProjetValidation.Text = "Projet";
            this.ProjetValidation.Width = 100;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblTotalDansTreeview);
            this.tabPage3.Controls.Add(this.lblTotalFichier);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.btnAjouter);
            this.tabPage3.Controls.Add(this.btnEnregistrer);
            this.tabPage3.Controls.Add(this.treeView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1191, 589);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Édition des contextes";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblTotalFichier
            // 
            this.lblTotalFichier.AutoSize = true;
            this.lblTotalFichier.Location = new System.Drawing.Point(7, 551);
            this.lblTotalFichier.Name = "lblTotalFichier";
            this.lblTotalFichier.Size = new System.Drawing.Size(41, 13);
            this.lblTotalFichier.TabIndex = 15;
            this.lblTotalFichier.Text = "label10";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(409, 228);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(764, 316);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Assignation";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAccessibleEcriture);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtAccessibleLecture);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(408, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(765, 205);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Édition du contexte";
            // 
            // txtAccessibleEcriture
            // 
            this.txtAccessibleEcriture.Location = new System.Drawing.Point(144, 109);
            this.txtAccessibleEcriture.Name = "txtAccessibleEcriture";
            this.txtAccessibleEcriture.Size = new System.Drawing.Size(42, 20);
            this.txtAccessibleEcriture.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(19, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(388, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "MasqueFilArianne = Aucun fil d\'ariane ne sera généré pour cet item";
            // 
            // txtAccessibleLecture
            // 
            this.txtAccessibleLecture.Location = new System.Drawing.Point(144, 80);
            this.txtAccessibleLecture.Name = "txtAccessibleLecture";
            this.txtAccessibleLecture.Size = new System.Drawing.Size(42, 20);
            this.txtAccessibleLecture.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(19, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(311, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "MasqueMenu = Cette item sera invisible dans le menu";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(144, 51);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(597, 20);
            this.txtDescription.TabIndex = 14;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(144, 23);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(597, 20);
            this.txtId.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Accessible en écriture";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Accessible en lecture";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Id:";
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(934, 550);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(158, 23);
            this.btnAjouter.TabIndex = 10;
            this.btnAjouter.Text = "Vide les champs";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Location = new System.Drawing.Point(1098, 550);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(75, 23);
            this.btnEnregistrer.TabIndex = 9;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(6, 16);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(396, 528);
            this.treeView1.TabIndex = 0;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Répertoire de recherche racine";
            // 
            // txtRepertoire
            // 
            this.txtRepertoire.Location = new System.Drawing.Point(170, 12);
            this.txtRepertoire.Name = "txtRepertoire";
            this.txtRepertoire.Size = new System.Drawing.Size(838, 20);
            this.txtRepertoire.TabIndex = 7;
            this.txtRepertoire.Text = "C:\\DEV\\SIQ\\S@\\Developpement\\Equipe\\Tarification\\";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1014, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Rechercher les contextes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtContexteInvalide
            // 
            this.txtContexteInvalide.Location = new System.Drawing.Point(9, 498);
            this.txtContexteInvalide.Multiline = true;
            this.txtContexteInvalide.Name = "txtContexteInvalide";
            this.txtContexteInvalide.Size = new System.Drawing.Size(1176, 85);
            this.txtContexteInvalide.TabIndex = 11;
            // 
            // lblTotalDansTreeview
            // 
            this.lblTotalDansTreeview.AutoSize = true;
            this.lblTotalDansTreeview.Location = new System.Drawing.Point(222, 555);
            this.lblTotalDansTreeview.Name = "lblTotalDansTreeview";
            this.lblTotalDansTreeview.Size = new System.Drawing.Size(41, 13);
            this.lblTotalDansTreeview.TabIndex = 16;
            this.lblTotalDansTreeview.Text = "label10";
            // 
            // FormTrouverObjetSecurite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 665);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRepertoire);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTrouverObjetSecurite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Les contextes de sécurités PESA";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lstContexteApplication;
        private System.Windows.Forms.ColumnHeader Contexte;
        private System.Windows.Forms.ColumnHeader Page;
        private System.Windows.Forms.ColumnHeader Projet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRepertoire;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstMessage;
        private System.Windows.Forms.ColumnHeader ContexteValidation;
        private System.Windows.Forms.ColumnHeader PageValidation;
        private System.Windows.Forms.ColumnHeader ProjetValidation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAccessibleEcriture;
        private System.Windows.Forms.TextBox txtAccessibleLecture;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTotalApplication;
        private System.Windows.Forms.Label lblTotalFichier;
        private System.Windows.Forms.Label lblTotalIncoherence;
        private System.Windows.Forms.TextBox txtContexteInvalide;
        private System.Windows.Forms.Label lblTotalDansTreeview;
    }
}

