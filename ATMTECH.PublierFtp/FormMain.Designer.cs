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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnPublier = new System.Windows.Forms.Button();
            this.lsvFtp = new System.Windows.Forms.ListView();
            this.checkbox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ftp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.site = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.repertoireFtp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.repertoireLocal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Utilisateur = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MotDePasse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Resultat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lsvResultat = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstResultatVisible = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.ftp,
            this.site,
            this.repertoireFtp,
            this.repertoireLocal,
            this.Utilisateur,
            this.MotDePasse,
            this.Resultat});
            this.lsvFtp.ForeColor = System.Drawing.Color.White;
            this.lsvFtp.Location = new System.Drawing.Point(12, 12);
            this.lsvFtp.Name = "lsvFtp";
            this.lsvFtp.Size = new System.Drawing.Size(1145, 228);
            this.lsvFtp.TabIndex = 1;
            this.lsvFtp.UseCompatibleStateImageBehavior = false;
            this.lsvFtp.View = System.Windows.Forms.View.Details;
            // 
            // checkbox
            // 
            this.checkbox.Text = "";
            this.checkbox.Width = 20;
            // 
            // ftp
            // 
            this.ftp.Text = "FTP / IP";
            this.ftp.Width = 100;
            // 
            // site
            // 
            this.site.Text = "Site";
            this.site.Width = 300;
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
            // Utilisateur
            // 
            this.Utilisateur.Text = "Utilisateur";
            // 
            // MotDePasse
            // 
            this.MotDePasse.Text = "Mot de passe";
            // 
            // Resultat
            // 
            this.Resultat.Text = "Résultat";
            this.Resultat.Width = 200;
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
            this.lsvResultat.Size = new System.Drawing.Size(1145, 280);
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
            // columnHeader8
            // 
            this.columnHeader8.Text = "Repertoire ftp";
            this.columnHeader8.Width = 400;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Résultat";
            this.columnHeader7.Width = 200;
            // 
            // lstResultatVisible
            // 
            this.lstResultatVisible.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstResultatVisible.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lstResultatVisible.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstResultatVisible.ForeColor = System.Drawing.Color.White;
            this.lstResultatVisible.Location = new System.Drawing.Point(12, 275);
            this.lstResultatVisible.Name = "lstResultatVisible";
            this.lstResultatVisible.Size = new System.Drawing.Size(1145, 280);
            this.lstResultatVisible.TabIndex = 10;
            this.lstResultatVisible.UseCompatibleStateImageBehavior = false;
            this.lstResultatVisible.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 10;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Fichier local";
            this.columnHeader2.Width = 400;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Repertoire ftp";
            this.columnHeader3.Width = 400;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Résultat";
            this.columnHeader4.Width = 200;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1169, 567);
            this.Controls.Add(this.lstResultatVisible);
            this.Controls.Add(this.lsvResultat);
            this.Controls.Add(this.lsvFtp);
            this.Controls.Add(this.btnPublier);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Publication FTP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPublier;
        private System.Windows.Forms.ListView lsvFtp;
        private System.Windows.Forms.ColumnHeader checkbox;
        private System.Windows.Forms.ColumnHeader site;
        private System.Windows.Forms.ColumnHeader repertoireFtp;
        private System.Windows.Forms.ColumnHeader repertoireLocal;
        private System.Windows.Forms.ListView lsvResultat;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader Resultat;
        private System.Windows.Forms.ColumnHeader Utilisateur;
        private System.Windows.Forms.ColumnHeader MotDePasse;
        private System.Windows.Forms.ColumnHeader ftp;
        private System.Windows.Forms.ListView lstResultatVisible;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}

