namespace ATMTECH.PublierFtp
{
    partial class FormMain
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
            this.btnPublier = new System.Windows.Forms.Button();
            this.lsvFtp = new System.Windows.Forms.ListView();
            this.checkbox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.site = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.repertoireFtp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.repertoireLocal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFtpServeur = new System.Windows.Forms.TextBox();
            this.txtFtpUtilisateur = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFtpMotPasse = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lsvResultat = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnPublier
            // 
            this.btnPublier.Location = new System.Drawing.Point(12, 246);
            this.btnPublier.Name = "btnPublier";
            this.btnPublier.Size = new System.Drawing.Size(75, 23);
            this.btnPublier.TabIndex = 0;
            this.btnPublier.Text = "Publier";
            this.btnPublier.UseVisualStyleBackColor = true;
            this.btnPublier.Click += new System.EventHandler(this.btnPublier_Click);
            // 
            // lsvFtp
            // 
            this.lsvFtp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvFtp.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lsvFtp.CheckBoxes = true;
            this.lsvFtp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.checkbox,
            this.site,
            this.repertoireFtp,
            this.repertoireLocal,
            this.columnHeader1});
            this.lsvFtp.ForeColor = System.Drawing.Color.White;
            this.lsvFtp.Location = new System.Drawing.Point(12, 45);
            this.lsvFtp.Name = "lsvFtp";
            this.lsvFtp.Size = new System.Drawing.Size(1059, 195);
            this.lsvFtp.TabIndex = 1;
            this.lsvFtp.UseCompatibleStateImageBehavior = false;
            this.lsvFtp.View = System.Windows.Forms.View.Details;
            // 
            // checkbox
            // 
            this.checkbox.Text = "";
            this.checkbox.Width = 20;
            // 
            // site
            // 
            this.site.Text = "Site";
            this.site.Width = 400;
            // 
            // repertoireFtp
            // 
            this.repertoireFtp.Text = "Repertoire FTP";
            this.repertoireFtp.Width = 200;
            // 
            // repertoireLocal
            // 
            this.repertoireLocal.Text = "Répertoire local";
            this.repertoireLocal.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "FTP:";
            // 
            // txtFtpServeur
            // 
            this.txtFtpServeur.Location = new System.Drawing.Point(50, 13);
            this.txtFtpServeur.Name = "txtFtpServeur";
            this.txtFtpServeur.Size = new System.Drawing.Size(220, 20);
            this.txtFtpServeur.TabIndex = 4;
            this.txtFtpServeur.Text = "108.60.212.40";
            // 
            // txtFtpUtilisateur
            // 
            this.txtFtpUtilisateur.Location = new System.Drawing.Point(341, 12);
            this.txtFtpUtilisateur.Name = "txtFtpUtilisateur";
            this.txtFtpUtilisateur.Size = new System.Drawing.Size(220, 20);
            this.txtFtpUtilisateur.TabIndex = 6;
            this.txtFtpUtilisateur.Text = "Administrator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(279, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Utilisateur:";
            // 
            // txtFtpMotPasse
            // 
            this.txtFtpMotPasse.Location = new System.Drawing.Point(649, 12);
            this.txtFtpMotPasse.Name = "txtFtpMotPasse";
            this.txtFtpMotPasse.Size = new System.Drawing.Size(220, 20);
            this.txtFtpMotPasse.TabIndex = 8;
            this.txtFtpMotPasse.Text = "Crevette01@";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(569, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mot de passe:";
            // 
            // lsvResultat
            // 
            this.lsvResultat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvResultat.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lsvResultat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader7});
            this.lsvResultat.ForeColor = System.Drawing.Color.White;
            this.lsvResultat.Location = new System.Drawing.Point(12, 275);
            this.lsvResultat.Name = "lsvResultat";
            this.lsvResultat.Size = new System.Drawing.Size(1059, 242);
            this.lsvResultat.TabIndex = 9;
            this.lsvResultat.UseCompatibleStateImageBehavior = false;
            this.lsvResultat.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "";
            this.columnHeader5.Width = 10;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Fichier local";
            this.columnHeader6.Width = 400;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Résultat";
            this.columnHeader7.Width = 200;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Repertoire ftp";
            this.columnHeader8.Width = 400;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Résultat";
            this.columnHeader1.Width = 200;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1083, 529);
            this.Controls.Add(this.lsvResultat);
            this.Controls.Add(this.txtFtpMotPasse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFtpUtilisateur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFtpServeur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsvFtp);
            this.Controls.Add(this.btnPublier);
            this.Name = "FormMain";
            this.Text = "Publication FTP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPublier;
        private System.Windows.Forms.ListView lsvFtp;
        private System.Windows.Forms.ColumnHeader checkbox;
        private System.Windows.Forms.ColumnHeader site;
        private System.Windows.Forms.ColumnHeader repertoireFtp;
        private System.Windows.Forms.ColumnHeader repertoireLocal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFtpServeur;
        private System.Windows.Forms.TextBox txtFtpUtilisateur;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFtpMotPasse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lsvResultat;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

